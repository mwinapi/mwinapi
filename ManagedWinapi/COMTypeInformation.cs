/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2008 Michael Schierl
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
using System.Text;
using System.Runtime.InteropServices.ComTypes;
using ComTypes = System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace ManagedWinapi
{
    /// <summary>
    /// This class contains methods to identify type name, functions and variables
    /// of a wrapped COM object (that appears as System.__COMObject in the debugger).
    /// </summary>
    public class COMTypeInformation
    {
        IDispatch dispatch;
        ITypeInfo typeInfo;

        /// <summary>
        /// Create a new COMTypeInformation object for the given COM Object.
        /// </summary>
        public COMTypeInformation(object comObject)
        {
            dispatch = comObject as IDispatch;
            if (dispatch == null) throw new Exception("Object is not a COM Object");
            int typeInfoCount;
            int hr = dispatch.GetTypeInfoCount(out typeInfoCount);
            if (hr < 0) throw new COMException("GetTypeInfoCount failed", hr);
            if (typeInfoCount != 1) throw new Exception("No TypeInfo present");
            hr = dispatch.GetTypeInfo(0, LCID_US_ENGLISH, out typeInfo);
            if (hr < 0) throw new COMException("GetTypeInfo failed", hr);
        }

        /// <summary>
        /// The type name of the COM object.
        /// </summary>
        public string TypeName
        {
            get
            {
                string name, dummy1, dummy3;
                int dummy2;
                typeInfo.GetDocumentation(-1, out name, out dummy1, out dummy2, out dummy3);
                return name;
            }
        }

        /// <summary>
        /// The names of the exported functions of this COM object.
        /// </summary>
        public IList<string> FunctionNames
        {
            get
            {
                List<string> result = new List<String>();
                for (int jj = 0; ; jj++)
                {
                    IntPtr fncdesc;
                    try
                    {
                        typeInfo.GetFuncDesc(jj, out fncdesc);
                    }
                    catch (COMException) { break; }
                    ComTypes.FUNCDESC fd = (ComTypes.FUNCDESC)Marshal.PtrToStructure(fncdesc, typeof(ComTypes.FUNCDESC));
                    string[] tmp = new string[1];
                    int cnt;
                    typeInfo.GetNames(fd.memid, tmp, tmp.Length, out cnt);
                    if (cnt == 1)
                        result.Add(tmp[0]);
                    typeInfo.ReleaseFuncDesc(fncdesc);
                }
                return result;
            }
        }

        /// <summary>
        /// The names of the exported variables of this COM object.
        /// </summary>
        public IList<string> VariableNames
        {
            get
            {
                List<string> result = new List<String>();
                for (int jj = 0; ; jj++)
                {
                    IntPtr vardesc;
                    try
                    {
                        typeInfo.GetVarDesc(jj, out vardesc);
                    }
                    catch (COMException) { break; }
                    ComTypes.VARDESC vd = (ComTypes.VARDESC)Marshal.PtrToStructure(vardesc, typeof(ComTypes.VARDESC));
                    string[] tmp = new string[1];
                    int cnt;
                    typeInfo.GetNames(vd.memid, tmp, tmp.Length, out cnt);
                    if (cnt == 1)
                        result.Add(tmp[0]);
                    typeInfo.ReleaseFuncDesc(vardesc);
                }
                return result;
            }
        }

        #region PInvoke Declarations

        private const int LCID_US_ENGLISH = 0x409;

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
        private interface IDispatch
        {
            [PreserveSig]
            int GetTypeInfoCount(out int count);
            [PreserveSig]
            int GetTypeInfo(int index, int lcid, [MarshalAs(UnmanagedType.Interface)] out ITypeInfo pTypeInfo);
        }
        #endregion
    }
}
