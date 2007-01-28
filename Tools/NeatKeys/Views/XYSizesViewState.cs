using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NeatKeys.Views
{
    class XYSizesViewState : ViewState
    {

        static readonly SizesSet defaultSet = new SizesSet( null, 0,
            new SizeEntry(0, 12),                                    // 0
            new SizeEntry(0, 4),
            new SizeEntry(0, 6),
            new SizeEntry(0, 8), 
            new SizeSubmenuEntry("Sizes based on fourths"),          // 4
            new SizeEntry(4, 8),
            new SizeSubmenuEntry("Sizes based on sixths"),           // 6
            new SizeEntry(4, 12),
            new SizeEntry(6,12),
            new SizeEntry(8, 12));                                   // 9


        static XYSizesViewState()
        {
            // fourths submenu
            new SizesSet(defaultSet, 4, 
                new SizeEntry(0, 12), // 0
                new SizeEntry(0, 3), // 1
                new SizeEntry(0, 6),
                new SizeEntry(0, 9), 
                new SizeEntry(3, 6),
                new SizeEntry(3, 9), // 5
                new SizeEntry(6, 9),
                new SizeEntry(3, 12),
                new SizeEntry(6, 12),
                new SizeEntry(9, 12)); // 9

            //sixths submenu
            SizesSet sixths = new SizesSet(defaultSet, 6,
                new SizeEntry(0, 12), // 0
                new SizeEntry(0, 2),  // 1
                new SizeEntry(2,4),
                new SizeEntry(4,6),
                new SizeSubmenuEntry("More left-biased sizes"),
                new SizeEntry(2, 10), // 5
                new SizeSubmenuEntry("More right-biased sizes"),
                new SizeEntry(6,8),
                new SizeEntry(8,10),
                new SizeEntry(10, 12)); // 9

            new SizesSet(sixths, 4, 
                new SizeEntry(0, 12), // 0
                new SizeEntry(0, 4),  // 1
                new SizeEntry(0, 6),  // 2
                new SizeEntry(0, 8),  // 3 
                new SizeEntry(0, 10), // 4
                new SizeEntry(2, 6),  // 5
                new SizeEntry(2, 8),  // 6
                new SizeEntry(2, 10), // 7
                new SizeEntry(2, 12), // 8
                new SizeEntry(4, 8)); // 9
            new SizesSet(sixths, 6, 
                new SizeEntry(0, 12), // 0
                new SizeEntry(4, 8),  // 1
                new SizeEntry(0, 10), // 2
                new SizeEntry(2, 10), // 3 
                new SizeEntry(4, 10), // 4
                new SizeEntry(6, 10), // 5
                new SizeEntry(2, 12), // 6
                new SizeEntry(4, 12), // 7
                new SizeEntry(6, 12), // 8
                new SizeEntry(8, 12));// 9
        }



        SizeEntry widthValue;
        SizesSet currentSet;

        internal override void  restart()
        {
            widthValue = null;
            currentSet = defaultSet;

        }

        internal override void Paint(PaintEventArgs e)
        {
            Font f = ScaleFont(e.Graphics, vc.Font, vc.Width / 15);
            using (Pen black = new Pen(Color.Black))
            using (Brush green = new SolidBrush(Color.LightGreen), blackb = new SolidBrush(Color.Black))
            {
                if (widthValue == null)
                {
                    int w = vc.Width;
                    int h= vc.Height;
                    for (int i = 0; i < 10; i++)
                    {
                        int ii = (i + 9) % 10;
                        e.Graphics.DrawRectangle(black, 0, h*i/10, w, h/10);
                        if (currentSet[i] is SizeSubmenuEntry) {
                            SizeSubmenuEntry sse = (SizeSubmenuEntry) currentSet[i];
                            DrawString(e.Graphics, f, i + ": " + sse.Title, 10, h * ii / 10 + h / 20, 0, 0.5f, blackb);
                        } else {
                            SizeEntry se = (SizeEntry) currentSet[i];
                            e.Graphics.FillRectangle(green, w * se.From / 12, h * ii / 10 + 5, w * (se.To - se.From) / 12, h / 10 - 10);
                            e.Graphics.DrawRectangle(black, w * se.From / 12, h * ii / 10 + 5, w * (se.To - se.From) / 12, h / 10 - 10);
                            DrawString(e.Graphics, f, "" + i, w * (se.From + se.To) / 24, h * ii / 10 + h / 20, 0.5f, 0.5f, blackb);
                        }
                    }
                    if (vc.ShowHints && currentSet.Parent == null)
                    {
                        DrawHelpBox(e.Graphics, vc.Font, w * 3 / 4, 20,
                            "Select horitontal size\n\n" +
                            "4 and 6 open submenus,\n" +
                            "other digits select,\n" +
                            ",: Use old window width\n" +
                            "Backspace/-: One menu back");
                    }
                }
                else
                {
                    int w = vc.Width;
                    int h = vc.Height;
                    for (int i = 0; i < 10; i++)
                    {
                        int ii = (i + 9) % 10;
                        e.Graphics.DrawRectangle(black, w * i / 10, 0, w/10, h);
                        if (currentSet[i] is SizeSubmenuEntry)
                        {
                            SizeSubmenuEntry sse = (SizeSubmenuEntry)currentSet[i];
                            DrawString(e.Graphics, f, i + "", w*ii/10+ w/20, 10, 0.5f, 0, blackb);
                            // print title?
                        }
                        else
                        {
                            SizeEntry se = (SizeEntry)currentSet[i];
                            e.Graphics.FillRectangle(green, w * ii / 10 + 5, h * se.From / 12, w / 10 - 10, h * (se.To - se.From) / 12);
                            e.Graphics.DrawRectangle(black, w * ii / 10 + 5, h * se.From / 12, w / 10 - 10, h * (se.To - se.From) / 12);
                            DrawString(e.Graphics, f, "" + i, w * ii / 10 + w / 20, h * (se.From + se.To) / 24, 0.5f, 0.5f, blackb);
                        }
                    }
                    if (vc.ShowHints && currentSet.Parent == null)
                    {
                        DrawHelpBox(e.Graphics, vc.Font, w * 3 / 4, 20,
                            "Select vertical size\n\n" +
                            "4 and 6 open submenus,\n" +
                            "other digits select,\n" +
                            ",: Use old window height\n" +
                            "Backspace/-: One menu back");
                    }
                }
            }
        }

        internal override void KeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                SizesSetMember ssm = currentSet[e.KeyChar - '0'];
                if (ssm is SizeSubmenuEntry)
                {
                    SizeSubmenuEntry sse = (SizeSubmenuEntry)ssm;
                    currentSet = sse.SubMenu;
                    vc.Invalidate();
                }
                else
                {
                    SizeEntry se = (SizeEntry)ssm;
                    select(se);
                }

            }
            else
            {
                switch (e.KeyChar)
                {
                    case ',':
                    case '.':
                        select(new SizeEntry(-1, -1));
                        break;
                    case '-':
                    case '\b':
                        currentSet = currentSet.Parent;
                        if (currentSet == null)
                        {
                            if (widthValue != null)
                            {
                                widthValue = null;
                                currentSet = defaultSet;
                            }
                            else
                            {
                                vc.NextState = ViewState.START;
                            }
                        }
                        vc.Invalidate();
                        break;
                }
            }
        }

        private void select(SizeEntry sizeEntry)
        {
            if (widthValue == null)
            {
                widthValue = sizeEntry;
                currentSet = defaultSet;
                vc.Invalidate();
                return;
            }
            SizeEntry heightValue = sizeEntry;
            vc.DoResize(12, widthValue.From, heightValue.From, widthValue.To - widthValue.From, heightValue.To - heightValue.From, true);
        }
    }
    
    class SizesSet
    {
        SizesSetMember[] members;
        SizesSet parent;

        public SizesSet(SizesSet parent, int parentIndex, params SizesSetMember[] m)
        {
            if (m.Length != 10) throw new ArgumentException();
            members = m;
            this.parent = parent;
            if (parent != null) ((SizeSubmenuEntry)parent[parentIndex]).SubMenu = this;
        }

        public SizesSetMember this[int i]
        {
            get
            {
                return members[i];
            }
        }

        public int Count {
            get
            {
                return members.Length;
            }
        }

        public SizesSet Parent
        {
            get { return parent; }
        }
    }

    interface SizesSetMember { }

    class SizeEntry : SizesSetMember{
        int from, to;
        public SizeEntry(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
        public int From { get { return from; } }
        public int To { get { return to; } }
    }

    class SizeSubmenuEntry : SizesSetMember {
        SizesSet subMenu;
        string title;

        public SizeSubmenuEntry(string t)
        {
            subMenu = null;
            title = t;
        }

        public SizesSet SubMenu
        {
            get { return subMenu; }
            set { subMenu = value; }
        }
        public string Title { get { 
            return title; } }
    }
}
