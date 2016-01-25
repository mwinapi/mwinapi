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
using Accessibility;
using ManagedWinapi.Windows;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedWinapi.Accessibility
{
    /// <summary>
    /// Provides access to the Active Accessibility API. Every <see cref="SystemWindow"/>
    /// has one ore more AccessibleObjects attached that provide information about the
    /// window to visually impaired people. This information is mainly used by screen 
    /// readers and other accessibility software..
    /// </summary>
    public class SystemAccessibleObject
    {
        private IAccessible iacc;
        private int childID;

        /// <summary>
        /// The IAccessible instance of this object (if <see cref="ChildID"/> is zero)
        /// or its parent.
        /// </summary>
        public IAccessible IAccessible { get { return iacc; } }

        /// <summary>
        /// The underlying child ID
        /// </summary>
        public int ChildID { get { return childID; } }

        /// <summary>
        /// Create an accessible object from an IAccessible instance and a child ID.
        /// </summary>
        public SystemAccessibleObject(IAccessible iacc, int childID)
        {
            if (iacc == null) throw new ArgumentNullException();
            //if (childID < 0) throw new ArgumentException();
            if (childID != 0)
            {
                try
                {
                    object realChild = iacc.get_accChild(childID);
                    if (realChild != null)
                    {
                        iacc = (IAccessible)realChild;
                        childID = 0;
                    }
                }
                //catch (ArgumentException) { }
                //catch (InvalidCastException) { }
                catch (Exception) { } // general error handling, e.g. IBM/Lotus Notes otherwise crashes with COMException here
            }
            this.iacc = iacc;
            this.childID = childID;
        }

        /// <summary>
        /// Gets an accessibility object for given screen coordinates.
        /// </summary>
        public static SystemAccessibleObject FromPoint(int x, int y)
        {
            IAccessible iacc;
            object ci;
            IntPtr result = AccessibleObjectFromPoint(new ManagedWinapi.Windows.POINT(x, y), out iacc, out ci);
            if (result != IntPtr.Zero) throw new Exception("AccessibleObjectFromPoint returned " + result.ToInt32());
            return new SystemAccessibleObject(iacc, (int)(ci ?? 0));
        }

        /// <summary>
        /// Gets an accessibility object for a given window.
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="objectID">Which accessibility object to get</param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static SystemAccessibleObject FromWindow(SystemWindow window, AccessibleObjectID objectID)
        {
            IAccessible iacc = (IAccessible)AccessibleObjectFromWindow(window == null ? IntPtr.Zero : window.HWnd, (uint)objectID, new Guid("{618736E0-3C3D-11CF-810C-00AA00389B71}"));
            return new SystemAccessibleObject(iacc, 0);
        }

        /// <summary>
        /// Gets the automation object for a given window. 
        /// This is a COM object implementing the IDispatch interface, commonly 
        /// available from Microsoft Office windows.
        /// </summary>
        /// <param name="window">The window</param>
        public static object COMObjectFromWindow(SystemWindow window)
        {
            return AccessibleObjectFromWindow(window == null ? IntPtr.Zero : window.HWnd, OBJID_NATIVEOM, new Guid("{00020400-0000-0000-C000-000000000046}"));
        }

        /// <summary>
        /// Gets an accessibility object for the mouse cursor.
        /// </summary>
        public static SystemAccessibleObject MouseCursor
        {
            get
            {
                return FromWindow(null, AccessibleObjectID.OBJID_CURSOR);
            }
        }

        /// <summary>
        /// Gets an accessibility object for the input caret, or
        /// <b>null</b> if there is none.
        /// </summary>
        public static SystemAccessibleObject Caret
        {
            get
            {
                try
                {
                    return FromWindow(null, AccessibleObjectID.OBJID_CARET);
                }
                catch (COMException)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Convert a role number to a localized string.
        /// </summary>
        public static string RoleToString(int roleNumber)
        {
            StringBuilder sb = new StringBuilder(1024);
            uint result = GetRoleText((uint)roleNumber, sb, 1024);
            if (result == 0) throw new Exception("Invalid role number");
            return sb.ToString();
        }

        /// <summary>
        /// Convert a state number (which may include more than one state bit)
        /// to a localized string.
        /// </summary>
        public static String StateToString(int stateNumber)
        {
            if (stateNumber == 0) return "None";
            int lowBit = stateNumber & -stateNumber;
            int restBits = stateNumber - lowBit;
            String s1 = StateBitToString(lowBit);
            if (restBits == 0) return s1;
            return StateToString(restBits) + ", " + s1;
        }

        /// <summary>
        /// Convert a single state bit to a localized string.
        /// </summary>
        public static string StateBitToString(int stateBit)
        {
            StringBuilder sb = new StringBuilder(1024);
            uint result = GetStateText((uint)stateBit, sb, 1024);
            if (result == 0) throw new Exception("Invalid role number");
            return sb.ToString();
        }

        /// <summary>
        /// The description of this accessible object.
        /// </summary>
        public string Description
        {
            get
            {
                try
                {
                    return iacc.get_accDescription(childID);
                }
                catch (NotImplementedException)
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// The name of this accessible object.
        /// </summary>
        public string Name
        {
            get
            {
                return iacc.get_accName(childID);
            }
            set
            {
                iacc.set_accName(childID, value);
            }

        }

        /// <summary>
        /// The role of this accessible object. This can either be an int
        /// (for a predefined role) or a string.
        /// </summary>
        public object Role
        {
            get
            {
                return iacc.get_accRole(childID);
            }
        }

        /// <summary>
        /// The role of this accessible object, as an integer. If this role
        /// is not predefined, -1 is returned.
        /// </summary>
        public int RoleIndex
        {
            get
            {
                object role = Role;
                if (role is int)
                {
                    return (int)role;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// The role of this accessible object, as a localized string.
        /// </summary>
        public string RoleString
        {
            get
            {
                object role = Role;
                if (role is int)
                {
                    return RoleToString((int)role);
                }
                else if (role is string)
                {
                    return (string)role;
                }
                else
                {
                    return role.ToString();
                }
            }
        }

        /// <summary>
        /// The location of this accessible object on screen. This rectangle
        /// is the smallest rectangle that includes the whole object, but not
        /// every point in the rectangle must be part of the object.
        /// </summary>
        public Rectangle Location
        {
            get
            {
                try
                {
                    int x, y, w, h;
                    iacc.accLocation(out x, out y, out w, out h, childID);
                    return new Rectangle(x, y, w, h);
                }
                catch { return Rectangle.Empty; }
            }
        }

        /// <summary>
        /// The value of this accessible object.
        /// </summary>
        public string Value
        {
            get
            {
                try
                {
                    return iacc.get_accValue(childID);
                }
                catch (COMException)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    iacc.set_accValue(childID, value);
                }
                catch (COMException) { }
            }
        }

        /// <summary>
        /// The state of this accessible object.
        /// </summary>
        public int State
        {
            get
            {
                try
                {
                    return (int)iacc.get_accState(childID);
                }
                catch (COMException)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// A string representation of the state of this accessible object.
        /// </summary>
        public string StateString
        {
            get
            {
                return StateToString(State);
            }
        }

        /// <summary>
        /// Whether this accessibile object is visible.
        /// </summary>
        public bool Visible
        {
            get
            {
                return (State & 0x8000) == 0;
            }
        }

        /// <summary>
        /// The parent of this accessible object, or <b>null</b> if none exists.
        /// </summary>
        public SystemAccessibleObject Parent
        {
            get
            {
                try
                {
                    // Internet Explorer recognition sometimes is stuck (permanently returning RPC_E_SERVERFAULT) 
                    // after requesting SAO that corresponds to a frame of an HTML frameset.
                    // Such a frame is a RoleSystemClient with Name=<URI> and Description="MSAAHTML Registered Handler".
                    // The child is a RoleSystemPane with Value=<URI>. 
                    // Hence stop requesting for parent when RoleSystemPane with URI value is found
                    //
                    // see also:
                    // About IE crashes after querying "MSAAHTML Registered Handler":
                    // http://community.nvda-project.org/changeset/96cd890c7878fd4f8805409dd83f3dde5c996b4f
                    // Some hint to ignore "MSAAHTML Registered Handler" in accessible ancestry:
                    // http://community.nvda-project.org/changeset/88c491d954743a6a02f14b1f144e234587f68430
                    // similar special case handling and ignoring of "MSAAHTML Registered Handler":
                    // http://www.projky.com/dotnet/4.5.1/MS/Internal/AutomationProxies/Accessible.cs.html

                    Uri uri = null;
                    if (RoleIndex == (int)AccRoles.ROLE_SYSTEM_PANE && Uri.TryCreate(Value, UriKind.Absolute, out uri)
                        && string.Equals(Window.Process.ProcessName, "iexplore", StringComparison.OrdinalIgnoreCase))
                    {
                        // do not call parent
                        return null;
                    }
                }
                catch { }
                if (childID != 0) return new SystemAccessibleObject(iacc, 0);
                IAccessible p = (IAccessible)iacc.accParent;
                if (p == null) return null;
                return new SystemAccessibleObject(p, 0);
            }
        }

        /// <summary>
        /// The keyboard shortcut of this accessible object.
        /// </summary>
        public string KeyboardShortcut
        {
            get
            {
                try
                {
                    return iacc.get_accKeyboardShortcut(childID);
                }
                catch (ArgumentException) { return ""; }
                catch (NotImplementedException) { return ""; }
                catch (COMException) { return null; }
            }
        }

        /// <summary>
        /// A string describing the default action of this accessible object.
        /// For a button, this might be "Press".
        /// </summary>
        public string DefaultAction
        {
            get
            {
                try
                {
                    return iacc.get_accDefaultAction(childID);
                }
                catch (COMException) { return null; }
            }
        }

        /// <summary>
        /// Perform the default action of this accessible object.
        /// </summary>
        public void DoDefaultAction()
        {
            iacc.accDoDefaultAction(ChildID);
        }

        /// <summary>
        /// Get all objects of this accessible object that are selected.
        /// </summary>
        public SystemAccessibleObject[] SelectedObjects
        {
            get
            {
                if (childID != 0) return new SystemAccessibleObject[0];
                object sel;
                try
                {
                    sel = iacc.accSelection;
                }
                catch (NotImplementedException)
                {
                    return new SystemAccessibleObject[0];
                }
                catch (COMException)
                {
                    return new SystemAccessibleObject[0];
                }
                if (sel == null) return new SystemAccessibleObject[0];
                if (sel is IEnumVARIANT)
                {
                    IEnumVARIANT e = (IEnumVARIANT)sel;
                    e.Reset();
                    List<SystemAccessibleObject> retval = new List<SystemAccessibleObject>();
                    object[] tmp = new object[1];
                    while (e.Next(1, tmp, IntPtr.Zero) == 0)
                    {
                        if (tmp[0] is int && (int)tmp[0] < 0) break;
                        retval.Add(ObjectToSAO(tmp[0]));
                    }
                    return retval.ToArray();
                }
                else
                {
                    if (sel is int && (int)sel < 0)
                    {
                        return new SystemAccessibleObject[0];
                    }
                    return new SystemAccessibleObject[] { ObjectToSAO(sel) };
                }
            }
        }

        private SystemAccessibleObject ObjectToSAO(object obj)
        {
            if (obj is int)
            {
                return new SystemAccessibleObject(iacc, (int)obj);
            }
            else
            {
                return new SystemAccessibleObject((IAccessible)obj, 0);
            }
        }

        /// <summary>
        /// Get the SystemWindow that owns this accessible object.
        /// </summary>
        public SystemWindow Window
        {
            get
            {
                IntPtr hwnd;
                WindowFromAccessibleObject(iacc, out hwnd);
                return new SystemWindow(hwnd);
            }
        }

        /// <summary>
        /// Get all child accessible objects.
        /// </summary>
        public SystemAccessibleObject[] Children
        {
            get
            {
                // ID-referenced objects cannot have children
                if (childID != 0) return new SystemAccessibleObject[0];

                int cs = iacc.accChildCount, csReal;
                object[] children = new object[cs];

                uint result = AccessibleChildren(iacc, 0, cs, children, out csReal);
                if (result != 0 && result != 1)
                    return new SystemAccessibleObject[0];
                if (csReal == 1 && children[0] is int && (int)children[0] < 0)
                    return new SystemAccessibleObject[0];
                List<SystemAccessibleObject> values = new List<SystemAccessibleObject>();
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != null)
                    {
                        try
                        {
                            values.Add(ObjectToSAO(children[i]));
                        }
                        catch (InvalidCastException) { }
                    }
                }
                return values.ToArray();
            }
        }

        /// <summary>
        /// Highlight the accessible object with a red border.
        /// </summary>
        public void Highlight()
        {
            Rectangle objectLocation = Location;
            SystemWindow window = Window;
            Rectangle windowLocation = window.Rectangle;
            using (WindowDeviceContext windowDC = window.GetDeviceContext(false))
            {
                using (Graphics g = windowDC.CreateGraphics())
                {
                    g.DrawRectangle(new Pen(Color.Red, 4), objectLocation.X - windowLocation.X, objectLocation.Y - windowLocation.Y, objectLocation.Width, objectLocation.Height);
                }
            }
        }

        #region Equals and HashCode

        ///
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            SystemAccessibleObject sao = obj as SystemAccessibleObject;
            return Equals(sao);
        }

        ///
        public bool Equals(SystemAccessibleObject sao)
        {
            if ((object)sao == null)
            {
                return false;
            }
            return childID == sao.childID && DeepEquals(iacc, sao.iacc);
        }

        private static bool DeepEquals(IAccessible ia1, IAccessible ia2)
        {
            if (ia1.Equals(ia2)) return true;
            if (Marshal.GetIUnknownForObject(ia1) == Marshal.GetIUnknownForObject(ia2)) return true;
            try
            {
                if (ia1.accChildCount != ia2.accChildCount) return false;
                SystemAccessibleObject sa1 = new SystemAccessibleObject(ia1, 0);
                SystemAccessibleObject sa2 = new SystemAccessibleObject(ia2, 0);
                if (sa1.Window.HWnd != sa2.Window.HWnd) return false;
                if (sa1.Location != sa2.Location) return false;
                if (sa1.DefaultAction != sa2.DefaultAction) return false;
                if (sa1.Description != sa2.Description) return false;
                if (sa1.KeyboardShortcut != sa2.KeyboardShortcut) return false;
                if (sa1.Name != sa2.Name) return false;
                if (!sa1.Role.Equals(sa2.Role)) return false;
                if (sa1.State != sa2.State) return false;
                if (sa1.Value != sa2.Value) return false;
                if (sa1.Visible != sa2.Visible) return false;
                if (ia1.accParent == null && ia2.accParent == null) return true;
                if (ia1.accParent == null || ia2.accParent == null) return false;
            }
            catch (COMException)
            {
                return false;
            }
            bool de = DeepEquals((IAccessible)ia1.accParent, (IAccessible)ia2.accParent);
            return de;
        }

        ///
        public override int GetHashCode()
        {
            return childID ^ iacc.GetHashCode();
        }

        /// <summary>
        /// Compare two instances of this class for equality.
        /// </summary>
        public static bool operator ==(SystemAccessibleObject a, SystemAccessibleObject b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.iacc == b.iacc && a.childID == b.childID;
        }

        /// <summary>
        /// Compare two instances of this class for inequality.
        /// </summary>
        public static bool operator !=(SystemAccessibleObject a, SystemAccessibleObject b)
        {
            return !(a == b);
        }

        ///
        public override string ToString()
        {
            try
            {
                return Name + " [" + RoleString + "]";
            }
            catch
            {
                return "??";
            }
        }

        #endregion

        #region PInvoke Declarations

        const uint OBJID_NATIVEOM = 0xFFFFFFF0;

        [DllImport("oleacc.dll")]
        private static extern IntPtr AccessibleObjectFromPoint(POINT pt, [Out, MarshalAs(UnmanagedType.Interface)] out IAccessible accObj, [Out] out object ChildID);
        [DllImport("oleacc.dll")]
        private static extern uint GetRoleText(uint dwRole, [Out] StringBuilder lpszRole, uint cchRoleMax);

        [DllImport("oleacc.dll", ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        private static extern object AccessibleObjectFromWindow(
            IntPtr hwnd,
            uint dwObjectID,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

        [DllImport("oleacc.dll")]
        private static extern uint GetStateText(uint dwStateBit, [Out] StringBuilder lpszStateBit, uint cchStateBitMax);

        [DllImport("oleacc.dll")]
        private static extern uint WindowFromAccessibleObject(IAccessible pacc, out IntPtr phwnd);

        [DllImport("oleacc.dll")]
        private static extern uint AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [Out] object[] rgvarChildren, out int pcObtained);

        #endregion
    }

    /// <summary>
    /// This enumeration lists all kinds of accessible objects that can
    /// be directly assigned to a window.
    /// </summary>
    [CLSCompliant(false)]
    public enum AccessibleObjectID : uint
    {
        /// <summary>
        /// The window itself.
        /// </summary>
        OBJID_WINDOW = 0x00000000,

        /// <summary>
        /// The system menu.
        /// </summary>
        OBJID_SYSMENU = 0xFFFFFFFF,

        /// <summary>
        /// The title bar.
        /// </summary>
        OBJID_TITLEBAR = 0xFFFFFFFE,

        /// <summary>
        /// The menu.
        /// </summary>
        OBJID_MENU = 0xFFFFFFFD,

        /// <summary>
        /// The client area.
        /// </summary>
        OBJID_CLIENT = 0xFFFFFFFC,

        /// <summary>
        /// The vertical scroll bar.
        /// </summary>
        OBJID_VSCROLL = 0xFFFFFFFB,

        /// <summary>
        /// The horizontal scroll bar.
        /// </summary>
        OBJID_HSCROLL = 0xFFFFFFFA,

        /// <summary>
        /// The size grip (part in the lower right corner that
        /// makes resizing the window easier).
        /// </summary>
        OBJID_SIZEGRIP = 0xFFFFFFF9,

        /// <summary>
        /// The caret (text cursor).
        /// </summary>
        OBJID_CARET = 0xFFFFFFF8,

        /// <summary>
        /// The mouse cursor. There is only one mouse
        /// cursor and it is not assigned to any window.
        /// </summary>
        OBJID_CURSOR = 0xFFFFFFF7,

        /// <summary>
        /// An alert window.
        /// </summary>
        OBJID_ALERT = 0xFFFFFFF6,

        /// <summary>
        /// A sound this window is playing.
        /// </summary>
        OBJID_SOUND = 0xFFFFFFF5
    }

    /// <summary>
    /// This enumeration lists all kinds of accessible roles as returned by IAccessible::get_accRole()
    /// Constants for MSAA accessibility roles from oleacc.h
    /// </summary>
    public enum AccRoles
    {
        /// <summary>
        /// The object represents an alert or a condition that a user should be notified about. This role is used only for objects that embody an alert but are not associated with another user interface element, such as a message box, graphic, text, or sound.
        /// </summary>
        ROLE_SYSTEM_ALERT = 8,

        /// <summary>
        /// The object represents an animation control whose content changes over time, such as a control that displays a series of bitmap frames. Animation controls are displayed when files are copied or when some other time-consuming task is performed.
        /// </summary>
        ROLE_SYSTEM_ANIMATION = 54,

        /// <summary>
        /// The object represents a main window for an application.
        /// </summary>
        ROLE_SYSTEM_APPLICATION = 14,

        /// <summary>
        /// The object represents a window border. The entire border is represented by a single object rather than by separate objects for each side.
        /// </summary>
        ROLE_SYSTEM_BORDER = 19,

        /// <summary>
        /// The object represents a button that expands a list of items.
        /// </summary>
        ROLE_SYSTEM_BUTTONDROPDOWN = 56,

        /// <summary>The object represents a button that expands a grid.
        /// </summary>
        ROLE_SYSTEM_BUTTONDROPDOWNGRID = 58,

        /// <summary>
        /// The object represents a button that expands a menu.
        /// </summary>
        ROLE_SYSTEM_BUTTONMENU = 57,

        /// <summary>
        /// The object represents the system caret.
        /// </summary>
        ROLE_SYSTEM_CARET = 7,

        /// <summary>
        /// The object represents a cell within a table.
        /// </summary>
        ROLE_SYSTEM_CELL = 29,

        /// <summary>
        /// The object represents a cartoon-like graphic object, such as Microsoft Office Assistant, which is displayed to provide help to users of an application.
        /// </summary>
        ROLE_SYSTEM_CHARACTER = 32,

        /// <summary>
        /// The object represents a graphical image used to chart data.
        /// </summary>
        ROLE_SYSTEM_CHART = 17,

        /// <summary>
        /// The object represents a check box control: an option that is selected or cleared independently of other options.
        /// </summary>
        ROLE_SYSTEM_CHECKBUTTON = 44,

        /// <summary>
        /// The object represents a window's client area. Microsoft Active Accessibility uses this role as a default if there is a question about the role of a UI element.
        /// </summary>
        ROLE_SYSTEM_CLIENT = 10,

        /// <summary>The object represents a control that displays time.
        /// </summary>
        ROLE_SYSTEM_CLOCK = 61,

        /// <summary>
        /// The object represents a column of cells within a table.
        /// </summary>
        ROLE_SYSTEM_COLUMN = 27,

        /// <summary>
        /// The object represents a column header, providing a visual label for a column in a table.
        /// </summary>
        ROLE_SYSTEM_COLUMNHEADER = 25,

        /// <summary>
        /// The object represents a combo box: an edit control with an associated list box that provides a set of predefined choices.
        /// </summary>
        ROLE_SYSTEM_COMBOBOX = 46,

        /// <summary>
        /// The object represents the system's mouse pointer.
        /// </summary>
        ROLE_SYSTEM_CURSOR = 6,

        /// <summary>
        /// The object represents a graphical image that is used to diagram data.
        /// </summary>
        ROLE_SYSTEM_DIAGRAM = 53,

        /// <summary>
        /// The object represents a dial or knob.
        /// </summary>
        ROLE_SYSTEM_DIAL = 49,

        /// <summary>
        /// The object represents a dialog box or message box.
        /// </summary>
        ROLE_SYSTEM_DIALOG = 18,

        /// <summary>
        /// The object represents a document window. A document window is always contained within an application window. This role applies only to MDI windows and refers to the object that contains the MDI title bar.
        /// </summary>
        ROLE_SYSTEM_DOCUMENT = 15,

        /// <summary>
        /// The object represents the calendar control, SysDateTimePick32. The Microsoft Active Accessibility runtime component uses this role to indicate that either a date or a calendar control has been found.
        /// </summary>
        ROLE_SYSTEM_DROPLIST = 47,

        /// <summary>
        /// The object represents a mathematical equation.
        /// </summary>
        ROLE_SYSTEM_EQUATION = 55,

        /// <summary>
        /// The object represents a picture.
        /// </summary>
        ROLE_SYSTEM_GRAPHIC = 40,

        /// <summary>
        /// The object represents a special mouse pointer that allows a user to manipulate user interface elements such as windows. One example of this involves resizing a window by dragging its lower-right corner.
        /// </summary>
        ROLE_SYSTEM_GRIP = 4,

        /// <summary>
        /// The object logically groups other objects. There is not always a parent-child relationship between the grouping object and the objects it contains.
        /// </summary>
        ROLE_SYSTEM_GROUPING = 20,

        /// <summary>
        /// The object displays a help topic in the form of a tooltip or help balloon.
        /// </summary>
        ROLE_SYSTEM_HELPBALLOON = 31,

        /// <summary>
        /// The object represents a keyboard shortcut field that allows the user to enter a combination or sequence of keystrokes.
        /// </summary>
        ROLE_SYSTEM_HOTKEYFIELD = 50,

        /// <summary>
        /// The object represents an indicator, such as a pointer graphic, that points to the current item.
        /// </summary>
        ROLE_SYSTEM_INDICATOR = 39,

        /// <summary>
        /// The object represents an edit control that is designed for an IP address. The edit control is divided into sections, each for a specific part of the IP address.
        /// </summary>
        ROLE_SYSTEM_IPADDRESS = 63, // Not defined in all oleacc.h versions

        /// <summary>The object represents a link to something else. This object might look like text or a graphic, but it acts like a button.
        /// </summary>
        ROLE_SYSTEM_LINK = 30,

        /// <summary>
        /// The object represents a list box, allowing the user to select one or more items.
        /// </summary>
        ROLE_SYSTEM_LIST = 33,

        /// <summary>
        /// The object represents an item in a list box or in the list portion of a combo box, drop-down list box, or drop-down combo box.
        /// </summary>
        ROLE_SYSTEM_LISTITEM = 34,

        /// <summary>The object represents the menu bar (positioned beneath the title bar of a window) from which users select menus.
        /// </summary>
        ROLE_SYSTEM_MENUBAR = 2,

        /// <summary>
        /// The object represents a menu item: an menu entry that the user can choose to carry out a command, select an option, or display another menu. Functionally, a menu item is equivalent to a push button, a radio button, a check box, or a menu.
        /// </summary>
        ROLE_SYSTEM_MENUITEM = 12,

        /// <summary>
        /// The object represents a menu: a list of options, each with a specific action. All menu types must have role, including the drop-down menus which are displayed when selected from a menu bar; and shortcut menus, which are displayed by clicking the right mouse button.
        /// </summary>
        ROLE_SYSTEM_MENUPOPUP = 11,

        /// <summary>
        /// The object represents an outline or a tree structure, such as a tree view control, that displays a hierarchical list and allows the user to expand and collapse branches.
        /// </summary>
        ROLE_SYSTEM_OUTLINE = 35,

        /// <summary>
        /// The object represents an item that navigates like an outline item. The UP and DOWN ARROW keys are used to navigate through the outline. However, instead of expanding and collapsing when the LEFT and RIGHT ARROW key is pressed, these menus expand or collapse when the SPACEBAR or ENTER key is pressed and the item has focus. 
        /// </summary>
        ROLE_SYSTEM_OUTLINEBUTTON = 64, // Not defined in all oleacc.h versions

        /// <summary>
        /// The object represents an item in an outline or tree structure.
        /// </summary>
        ROLE_SYSTEM_OUTLINEITEM = 36,

        /// <summary>
        /// The object represents a page tab. The only child of a page tab control is a ROLE_SYSTEM_GROUPING object that has the contents of the associated page.
        /// </summary>
        ROLE_SYSTEM_PAGETAB = 37,

        /// <summary>
        /// The object represents a container of page tab controls.
        /// </summary>
        ROLE_SYSTEM_PAGETABLIST = 60,

        /// <summary>
        /// The object represents a pane within a frame or a document window. Users can navigate between panes and within the contents of the current pane, but cannot navigate between items in different panes. Thus, panes represent a grouping level that is lower than frames or document windows, but higher than individual controls. The user navigates between panes by pressing TAB, F6, or CTRL+TAB, depending on the context.
        /// </summary>
        ROLE_SYSTEM_PANE = 16,

        /// <summary>
        /// The object represents a progress bar, which dynamically shows how much of an operation in progress has completed. This control takes no user input.
        /// </summary>
        ROLE_SYSTEM_PROGRESSBAR = 48,

        /// <summary>
        /// The object represents a progress bar, which dynamically shows how much of an operation in progress has completed. This control takes no user input.
        /// </summary>
        ROLE_SYSTEM_PROPERTYPAGE = 38,

        /// <summary>
        /// The object represents a push-button control.
        /// </summary>
        ROLE_SYSTEM_PUSHBUTTON = 43,

        /// <summary>
        /// The object represents an option button (formerly, a radio button). It is one of a group of mutually exclusive options. All objects that share the same parent and that have this attribute are assumed to be part of a single mutually exclusive group. To divide these objects into separate groups, use ROLE_SYSTEM_GROUPING objects.
        /// </summary>
        ROLE_SYSTEM_RADIOBUTTON = 45,

        /// <summary>
        /// The object represents a row of cells within a table.
        /// </summary>
        ROLE_SYSTEM_ROW = 28,

        /// <summary>
        /// The object represents a row header, which provides a visual label for a table row.
        /// </summary>
        ROLE_SYSTEM_ROWHEADER = 26,

        /// <summary>
        /// The object represents a vertical or horizontal scroll bar, which is part of the client area or is used in a control.
        /// </summary>
        ROLE_SYSTEM_SCROLLBAR = 3,

        /// <summary>
        /// The object is used to visually divide a space into two regions. Examples of separator objects include a separator menu item, and a bar that divides split panes within a window.
        /// </summary>
        ROLE_SYSTEM_SEPARATOR = 21,

        /// <summary>
        /// The object represents a slider, which allows the user to adjust a setting in particular increments between minimum and maximum values.
        /// </summary>
        ROLE_SYSTEM_SLIDER = 51,

        /// <summary>
        /// The object represents a system sound, which is associated with various system events.
        /// </summary>
        ROLE_SYSTEM_SOUND = 5,

        /// <summary>
        /// The object represents a spin box, which is a control that allows the user to increment or decrement the value displayed in a separate "buddy" control that is associated with the spin box.
        /// </summary>
        ROLE_SYSTEM_SPINBUTTON = 52,

        /// <summary>
        /// The object represents a button on a toolbar that has a drop-down list icon that is directly adjacent to the button.
        /// </summary>
        ROLE_SYSTEM_SPLITBUTTON = 62, // Not defined in all oleacc.h version

        /// <summary>
        /// The object represents read-only text, such as labels for other controls or instructions in a dialog box. Static text cannot be modified or selected.
        /// </summary>
        ROLE_SYSTEM_STATICTEXT = 41,

        /// <summary>
        /// The object represents a status bar, which is an area at the bottom of a window and which displays information about the current operation, state of the application, or selected object. The status bar has multiple fields, which display different kinds of information.
        /// </summary>
        ROLE_SYSTEM_STATUSBAR = 23,

        /// <summary>
        /// The object represents a table that contains rows and columns of cells, and, optionally, row headers and column headers.
        /// </summary>
        ROLE_SYSTEM_TABLE = 24,

        /// <summary>
        /// The object represents selectable text that allows edits or is designated as read-only.
        /// </summary>
        ROLE_SYSTEM_TEXT = 42,

        /// <summary>
        /// The object represents a title or caption bar for a window.
        /// </summary>
        ROLE_SYSTEM_TITLEBAR = 1,

        /// <summary>
        /// The object represents a toolbar, which is a grouping of controls that provides easy access to frequently used features.
        /// </summary>
        ROLE_SYSTEM_TOOLBAR = 22,

        /// <summary>
        /// The object represents a tooltip that provides helpful hints.
        /// </summary>
        ROLE_SYSTEM_TOOLTIP = 13,

        /// <summary>
        /// The object represents blank space between other objects.
        /// </summary>
        ROLE_SYSTEM_WHITESPACE = 59,

        /// <summary>
        /// The object represents the window frame, which contains child objects such as a title bar, client, and other objects of a window.
        /// </summary>
        ROLE_SYSTEM_WINDOW = 9
    }
}
