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

namespace ManagedWinapi.Windows.Contents
{
    /// <summary>
    /// The content of a list box or combo box.
    /// </summary>
    public class ListContent : WindowContent
    {
        string type, current;
        string[] values;
        int selected;

        internal ListContent(string type, int selected, string current, string[] values)
        {
            this.type = type;
            this.selected = selected;
            this.current = current;
            this.values = values;
        }

        ///
        public string ComponentType
        {
            get { return type; }
        }

        ///
        public string ShortDescription
        {
            get { return (current == null ? "" : current + " ") + "<" + type + ">"; }
        }

        ///
        public string LongDescription
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<" + type + ">");
                if (current != null)
                    sb.Append(" (selected value: \"" + current + "\")");
                sb.Append("\nAll values:\n");
                int idx = 0;
                foreach (string v in values)
                {
                    if (selected == idx) sb.Append("*");
                    sb.Append("\t" + v + "\n");
                    idx++;
                }
                return sb.ToString();
            }
        }

        ///
        public Dictionary<string, string> PropertyList
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add("SelectedValue", current);
                result.Add("SelectedIndex", "" + selected);
                result.Add("Count", "" + values.Length);
                for (int i = 0; i < values.Length; i++)
                {
                    result.Add("Value" + i, values[i]);
                }
                return result;
            }
        }

        /// <summary>
        /// The value in this list or combo box that is selected.
        /// In a combo box, this value may not be in the list.
        /// </summary>
        public String SelectedValue
        {
            get { return current; }
        }

        /// <summary>
        /// The index of the selected item, or -1 if no item
        /// is selected.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selected;
            }
        }

        /// <summary>
        /// The number of items in this list.
        /// </summary>
        public int Count
        {
            get
            {
                return values.Length;
            }
        }

        /// <summary>
        /// Accesses individual list items.
        /// </summary>
        /// <param name="index">Index of list item.</param>
        /// <returns>The list item.</returns>
        public string this[int index]
        {
            get
            {
                return values[index];
            }
        }
    }

    internal class ListBoxParser : WindowContentParser
    {
        internal override bool CanParseContent(SystemWindow sw)
        {
            return SystemListBox.FromSystemWindow(sw) != null;
        }

        internal override WindowContent ParseContent(SystemWindow sw)
        {
            SystemListBox slb = SystemListBox.FromSystemWindow(sw);
            int c = slb.Count;
            string[] values = new string[c];
            for (int i = 0; i < c; i++)
            {
                values[i] = slb[i];
            }
            return new ListContent("ListBox", slb.SelectedIndex, slb.SelectedItem, values);
        }
    }

    internal class ComboBoxParser : WindowContentParser
    {
        internal override bool CanParseContent(SystemWindow sw)
        {
            return SystemComboBox.FromSystemWindow(sw) != null;
        }

        internal override WindowContent ParseContent(SystemWindow sw)
        {
            SystemComboBox slb = SystemComboBox.FromSystemWindow(sw);
            int c = slb.Count;
            string[] values = new string[c];
            for (int i = 0; i < c; i++)
            {
                values[i] = slb[i];
            }
            return new ListContent("ComboBox", -1, sw.Title, values);
        }
    }
}
