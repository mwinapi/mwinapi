using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContentsSaver
{
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            textBox.Text = text;
        }
    }
}