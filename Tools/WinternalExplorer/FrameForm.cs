using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinternalExplorer
{
    public partial class FrameForm : Form
    {
        private bool dragging = false, editable = true;
        int dragX, dragY, dragWhere;
        private ResizedDelegate resized;

        public FrameForm(Rectangle where, ResizedDelegate rd)
        {
            resized = rd;
            editable = (rd != null);
            InitializeComponent();
            Location = where.Location;
            Size = where.Size;
            Visible = true;
            Size = where.Size;
        }

        private void FrameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(1, 1, Width - 2, Height - 2));
        }

        private void FrameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                switch (dragWhere)
                {
                    case 0:
                        Left += e.X - dragX;
                        Top += e.Y - dragY;
                        break;
                    case 1:
                        Top += e.Y - dragY;
                        Height -= e.Y - dragY;
                        break;
                    case 2:
                        Width += e.X - dragX;
                        dragX = e.X;
                        Top += e.Y - dragY;
                        Height -= e.Y - dragY;
                        break;
                    case 3:
                        Left += e.X - dragX;
                        Width -= e.X - dragX;
                        break;
                    case 5:
                        Width += e.X - dragX;
                        dragX = e.X;
                        break;
                    case 6:
                        Left += e.X - dragX;
                        Width -= e.X - dragX;
                        Height += e.Y - dragY;
                        dragY = e.Y;
                        break;
                    case 7:
                        Height += e.Y - dragY;
                        dragY = e.Y;
                        break;
                    case 8:
                        Height += e.Y - dragY;
                        dragY = e.Y;
                        Width += e.X - dragX;
                        dragX = e.X;
                        break;
                }
                resized(this);
                return;
            }
            if (!editable)
            {
                this.Cursor = null;
                return;
            }
            this.Cursor = new Cursor[] {
                this.Cursor = Cursors.SizeAll,
                this.Cursor = Cursors.SizeNS,
                this.Cursor = Cursors.SizeNESW,
                this.Cursor = Cursors.SizeWE,
                null,
                this.Cursor = Cursors.SizeWE,
                this.Cursor = Cursors.SizeNESW,
                this.Cursor = Cursors.SizeNS,
                this.Cursor = Cursors.SizeNWSE
            }[where(e.Location)];
        }

        private void FrameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!editable) return;
            dragging = true;
            dragX = e.X;
            dragY = e.Y;
            dragWhere = where(e.Location);
        }

        private int where(Point p)
        {
            if (p.Y < 16)
            {
                if (p.X < 16)
                {
                    return 0;
                }
                else if (p.X > Width - 16)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else if (p.Y > Height - 16)
            {
                if (p.X < 16)
                {
                    return 6;

                }
                else if (p.X > Width - 16)
                {
                    return 8;
                }
                else
                {
                    return 7;
                }
            }
            else
            {
                if (p.X < 16)
                {
                    return 3;
                }
                else
                {
                    return 5;
                }
            }
        }

        private void FrameForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!editable) return;
            FrameForm_MouseMove(sender, e);
            dragging = false;
        }
    }

    public delegate void ResizedDelegate(FrameForm ff);
}