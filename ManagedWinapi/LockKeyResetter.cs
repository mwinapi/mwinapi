/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2006 Michael Schierl
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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ManagedWinapi
{
    /// <summary>
    /// Utility class that can be used to create key events with all current 
    /// locking keys (like Caps Lock) disabled. Other modifier keys (like Ctrl or Shift)
    /// are also ignored if they are currently pressed on the "real" keyboard.
    /// </summary>
    /// <example>
    /// <code>
    /// using (new LockKeysResetter()) {
    ///     SendKeys.Send("Hello");
    /// }
    /// </code>
    /// </example>
    public class LockKeyResetter :IDisposable
    {

        bool capslock;

        /// <summary>
        /// Reset all modifier keys and remember in this object which modifier keys
        /// have been set.
        /// </summary>
        public LockKeyResetter()
        {
            int capslockstate = GetKeyState((short)Keys.CapsLock);
            capslock = ((capslockstate & 0x01) == 0x01);
            if (capslock)
            {
                // press caps lock
                keybd_event(0x14, 0x0, 0x0, new UIntPtr(0x0));
                keybd_event(0x14, 0x0, 0x2, new UIntPtr(0x0));
                Application.DoEvents();
                if ((GetKeyState((short)Keys.CapsLock) & 0x01) == 0x01)
                {
                    // press shift
                    keybd_event(0x10, 0x0, 0x0, new UIntPtr(0x0));
                    keybd_event(0x10, 0x0, 0x2, new UIntPtr(0x0));
                }
                Application.DoEvents();
                if ((GetKeyState((short)Keys.CapsLock) & 0x01) == 0x01)
                {
                    throw new Exception("Cannot disable caps lock.");
                }
            }
            //TODO: disable all other modifier keys.
            SendKeys.Send("A{Backspace}");
        }

        /// <summary>
        /// Set all modifier keys that have been set before. Since this class implements
        /// <see cref="IDisposable"/>, you can use the <c>using</c> 
        /// keyword in C# to automatically set modifier keys when you have finished.
        /// </summary>
        public void Dispose()
        {
            if (capslock) {
                // press caps lock
                keybd_event(0x14, 0x0, 0x0, new UIntPtr(0x0));
                keybd_event(0x14, 0x0, 0x2, new UIntPtr(0x0));
                Application.DoEvents();
                if ((GetKeyState((short)Keys.CapsLock) & 0x01) != 0x01)
                    throw new Exception("Cannot enable caps lock.");
            }
        }


        /// <summary>
        /// Convenience method to send keys with all modifiers disabled.
        /// </summary>
        /// <param name="keys">The keys to send</param>
        public static void Send(String keys)
        {
            using (new LockKeyResetter())
            {
                SendKeys.Send(keys);
            }
        }

        /// <summary>
        /// Convenience method to send keys and wait for them (like 
        /// <see cref="SendKeys.SendWait">SendKeys.SendWait</see>) with all modifiers disabled.
        /// </summary>
        /// <param name="keys"></param>
        public static void SendWait(String keys)
        {
            using (new LockKeyResetter())
            {
                SendKeys.SendWait(keys);
            }
        }


        #region PInvoke Declarations

        [DllImport("user32.dll")]
        private static extern short GetKeyState(short nVirtKey);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
           UIntPtr dwExtraInfo);
        #endregion
    }
}
