using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinternalExplorer
{
    public partial class NoneControl : ChildControl
    {
        public static NoneControl Instance = new NoneControl();

        public NoneControl()
        {
            InitializeComponent();
        }
    }
}
