using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinternalExplorer
{
    public class ChildControl : UserControl
    {
        protected ChildControl()
        {
        }

        internal virtual void Update(TreeNodeData tnd, bool allowUnsafeChanges, MainForm mf)
        {
        }

        internal virtual void Update(bool allowUnsafeChanges)
        {
        }
    }
}
