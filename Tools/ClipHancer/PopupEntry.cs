using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClipHancer
{
    public partial class PopupEntry : UserControl
    {
        ClipboardEntry ce;
        int index = -1;

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                num.Text = "" + index;
            }
        }

        private bool framed;
        public bool Framed
        {
            get { return framed; }
            set { framed = value; Invalidate(); }
        }

        public PopupEntry()
        {
            InitializeComponent();
        }

        internal ClipboardEntry ClipboardEntry
        {
            get { return ce; }
            set
            {
                this.ce = value;
                pct.Image = ce.PreviewImage;
                lbl.Text = ce.Caption;
            }
        }

        private void PopupEntry_Paint(object sender, PaintEventArgs e)
        {
            if (framed)
            {
                Pen p = new Pen(Color.Blue, 2);
                e.Graphics.DrawRectangle(p, 3, 3, Width - 5, Height - 5);
            }
        }

        private void any_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }
}
