using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShootNotes
{
    public partial class InputBox : Form
    {
        public InputBox(string caption)
        {
            InitializeComponent();
            label.Text = caption;
        }

        public static string Show(Form parent, string message, string defaultValue)
        {
            InputBox ib = new InputBox(message);
            ib.text.Text = defaultValue;
            DialogResult dr = ib.ShowDialog(parent);
            if (dr == DialogResult.Cancel) return null;
            else return ib.text.Text;
        }
    }
}