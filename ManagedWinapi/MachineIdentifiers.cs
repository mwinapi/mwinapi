/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2006, 2007 Michael Schierl
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; see the file COPYING. if not, visit
 * http://www.gnu.org/licenses/lgpl.html or write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */
using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace ManagedWinapi
{
    /// <summary>
    /// Contains utility functions to determine values that are (almost)
    /// unique on each computer. These values can be useful for locking
    /// software to a machine.
    /// </summary>
    public static class MachineIdentifiers
    {

        const uint POLICY_VIEW_LOCAL_INFORMATION = 0x00000001,
                PolicyAccountDomainInformation = 5;

        [StructLayout(LayoutKind.Explicit)]
        private struct POLICY_ACCOUNT_DOMAIN_INFO
        {
            [FieldOffset(8)]
            public IntPtr DomainSid;
        }

        [DllImport("advapi32.dll", SetLastError = true, PreserveSig = false)]
        private static extern void LsaOpenPolicy(
           IntPtr /* ref LSA_UNICODE_STRING */ SystemName,
           ref int /* LSA_OBJECT_ATTRIBUTES */ ObjectAttributes,
           uint DesiredAccess, out IntPtr PolicyHandle
        );

        [DllImport("advapi32.dll", SetLastError = true, PreserveSig = false)]
        private static extern void LsaQueryInformationPolicy(
            IntPtr PolicyHandle, uint InformationClass,
            out IntPtr /* out ref POLICY_ACCOUNT_DOMAIN_INFO */ Buffer);

        [DllImport("advapi32.dll", SetLastError = true, PreserveSig = false)]
        private static extern void LsaFreeMemory(ref POLICY_ACCOUNT_DOMAIN_INFO pBuffer);

        [DllImport("advapi32.dll", SetLastError = true, PreserveSig = false)]
        private static extern void LsaClose(IntPtr ObjectHandle);

        [DllImport("netapi32.dll", CharSet = CharSet.Auto)]
        private static extern int NetWkstaGetInfo(string server,
            int level,
            out WKSTA_INFO_100 info);

        [DllImport("netapi32.dll")]
        private static extern int NetApiBufferFree(WKSTA_INFO_100 info);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class WKSTA_INFO_100
        {
            public int wki100_platform_id;
            public string wki100_computername;
            public string wki100_langroup;
            public int wki100_ver_major;
            public int wki100_ver_minor;
        }

        /// <summary>
        /// The security identifier of this machine. This id is generated at 
        /// installation time (or when running tools like SysPrep or NewSid) 
        /// and is used to generate security identifiers of local users and to 
        /// authenticate the machine in a domain.
        /// </summary>
        public static SecurityIdentifier MachineSID
        {
            get
            {
                int objectAttributes = 0;
                IntPtr policyHandle;
                IntPtr pInfo;
                POLICY_ACCOUNT_DOMAIN_INFO info;
                LsaOpenPolicy(IntPtr.Zero, ref objectAttributes, POLICY_VIEW_LOCAL_INFORMATION,
                    out policyHandle);
                LsaQueryInformationPolicy(policyHandle, PolicyAccountDomainInformation, out pInfo);
                info = (POLICY_ACCOUNT_DOMAIN_INFO)Marshal.PtrToStructure(pInfo, typeof(POLICY_ACCOUNT_DOMAIN_INFO));
                SecurityIdentifier sid = new SecurityIdentifier(info.DomainSid);
                LsaFreeMemory(ref info);
                LsaClose(policyHandle);
                return sid;
            }
        }

        /// <summary>
        /// The NetBIOS name of the domain to which this machine is joined, or the LAN workgroup name if not. 
        /// For the Active Directory DNS domain name, see <see cref="DnsDomainName"/>.
        /// </summary>
        public static string DomainName
        {
            get
            {
                WKSTA_INFO_100 wkstaInfo;
                int result  = NetWkstaGetInfo(null, 100, out wkstaInfo);
                if (result != 0)
                    throw new Win32Exception(result);
                string domainName = wkstaInfo.wki100_langroup;
                NetApiBufferFree(wkstaInfo);
                return domainName;
            }
        }

        /// <summary>
        /// The Active Directory DNS domain of which this machine is a member. 
        /// For the NetBIOS domain name see <see cref="DomainName"/>.
        /// </summary>
        public static string DnsDomainName
        {
            get
            {
                IPGlobalProperties ipGlobalProps = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
                return ipGlobalProps.DomainName;
            }
        }

        /// <summary>
        /// The DNS host name of this machine. Can be easily changed.
        /// </summary>
        public static string HostName
        {
            get { return Dns.GetHostName(); }
        }

        /// <summary>
        /// The NetBIOS name of this machine. Can be easily changed; having two 
        /// machines with same name on the same network can cause trouble with 
        /// shared folders, though.
        /// </summary>
        public static string MachineName
        {
            get { return Environment.MachineName; }
        }

        /// <summary>
        /// The Media Access Control addresses of all network adapters. Note 
        /// that these values are the addresses loaded from the driver, and thus 
        /// could have been set by the user.
        /// Having two network cards with same MAC connected to the same physical 
        /// network segment will lead into trouble. Usually MAC addresses are 
        /// burned into the PROM of a NIC, so this is no problem unless someone 
        /// changes his MAC deliberately (for example) to bypass access 
        /// restrictions.
        /// </summary>
        public static string[] MacAddresses
        {
            get
            {
                List<string> result = new List<string>();
                foreach (ManagementObject mo in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        result.Add(mo["MacAddress"].ToString());
                    }
                }
                return result.ToArray();
            }
        }

        /// <summary>
        /// Get all network interfaces. Use them to get MAC addresses or IP 
        /// addresses, or the MAC address that is used for connecting to a 
        /// specific IP address.
        /// </summary>
        public static NetworkInterface[] NetworkInterfaces
        {
            get
            {
                return NetworkInterface.GetAllNetworkInterfaces();
            }
        }

        /// <summary>
        /// Get the Volume Serial Numbers from all hard disk partitions.
        /// These values are part of the filesystem, and were originally intended
        /// to detect floppy swaps where the same floppy has been removed
        /// and inserted again (because, in this case, unwritten data may still
        /// be written). Today these are easily tweakable and of no real use,
        /// except for badly-designed software licensing schemes.
        /// </summary>
        public static Dictionary<string, string> VolumeSerialNumbers
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (string drive in Directory.GetLogicalDrives())
                {
                    ManagementObject disk =
                        new ManagementObject("win32_logicaldisk.deviceid=\"" +
                        drive.Substring(0, 2) + "\"");
                    disk.Get();
                    result.Add(drive, disk["VolumeSerialNumber"] == null ? null :
                        disk["VolumeSerialNumber"].ToString());
                }
                return result;
            }
        }

        /// <summary>
        /// Return the ID of all CPUs in this machine. Depending on BIOS configuration,
        /// CPU IDs might not be readable.
        /// </summary>
        public static string[] CPUIDs
        {
            get
            {
                List<string> result = new List<string>();
                foreach (ManagementObject mo in new ManagementClass("Win32_Processor").GetInstances())
                {
                    result.Add(mo.Properties["ProcessorId"].Value.ToString());
                }
                return result.ToArray();
            }
        }
    }
}