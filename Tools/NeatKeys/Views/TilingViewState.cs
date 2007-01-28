using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NeatKeys.Views
{
    class TilingViewState : ViewState
    {
        Rectangle?[] tiles = new Rectangle?[52];
        List<Rectangle> restTiles = new List<Rectangle>();
        private static readonly string TITLES;
        int currentTile = -1;
        enum Mode { NORMAL, RENAME, JOIN };

        private static readonly int[] SPLITTINGS = new int[] { // 60th of width
             12, /* 1/5 */
             15, /* 1/4 */
             20, /* 1/3 */
             24, /* 2/5 */
             30, /* 1/2 */
             36, /* 3/5 */
             40, /* 2/3 */
             45, /* 3/4 */
             48  /* 4/5 */
        };

        Mode mode = Mode.NORMAL;
        bool shift = false, ctrl = false;

        static TilingViewState()
        {
            char[] c = new char[52];
            for (int i = 0; i < 26; i++)
            {
                c[i] = (char)('a' + i);
                c[i + 26] = (char)('A' + i);
            }
            TITLES = new string(c);
        }

        internal override void restart()
        {
            shift = false;
            ctrl = false;
            currentTile = -1;
            mode = Mode.NORMAL;
            EnsureSelection();
        }

        internal bool HasTiles
        {
            get
            {
                return currentTile != -1;
            }
        }

        private void EnsureSelection()
        {
            if (restTiles.Count > 0)
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (tiles[i] == null)
                    {
                        tiles[i] = restTiles[0];
                        restTiles.RemoveAt(0);
                        if (restTiles.Count == 0) break;
                    }
                }
            }
            if (currentTile != -1 && tiles[currentTile] != null) return;
            currentTile = -1;
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] != null)
                {
                    currentTile = i;
                    break;
                }
            }
        }

        private int NextSlot
        {
            get
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (tiles[i] == null) return i;
                }
                return -1;
            }
        }

        private void AssignNextSlot(Rectangle r)
        {
            if (NextSlot == -1)
            {
                restTiles.Add(r);
            }
            else
            {
                tiles[NextSlot] = r;
            }
            EnsureSelection();
        }

        internal override void Paint(PaintEventArgs e)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] != null)
                {
                    Rectangle r = tiles[i].Value;
                    e.Graphics.DrawRectangle(i == currentTile ? new Pen(Color.Black, 3) : Pens.Black, r);
                    if (!ctrl || !shift)
                    {
                        Font f = vc.Font;
                        if (i == currentTile)
                        {
                            f = new Font(f, FontStyle.Bold);
                        }
                        e.Graphics.DrawString("" + TITLES[i], f, mode != Mode.NORMAL && i == currentTile ? Brushes.Red : Brushes.Black, r.X + 2, r.Y + 2);
                    }
                }
            }
            foreach (Rectangle r in restTiles)
            {
                e.Graphics.DrawRectangle(Pens.Black, r);
            }
            if (ctrl && shift)
            {
                for (int i = 0; i < 36; i++)
                {
                    Rectangle? rr = PositionStore.Instance[i];
                    if (rr.HasValue)
                    {
                        Rectangle r = rr.Value;
                        Point p = r.Location;
                        e.Graphics.DrawRectangle(Pens.Blue, r);
                        e.Graphics.DrawString("" + SavedPositionsViewState.TITLES[i], vc.Font, Brushes.Blue, r.Location);
                    }
                }
            }
            else if (shift && currentTile != -1)
            {
                Rectangle r = tiles[currentTile].Value;
                for (int i = 0; i < 9; i++)
                {
                    int xx = r.X + r.Width * SPLITTINGS[i] / 60;
                    e.Graphics.DrawLine(Pens.Blue, xx, r.Y, xx, r.Y + r.Height);
                    e.Graphics.DrawString("" + (i + 1), vc.Font, Brushes.Blue, xx, r.Y + r.Height / 2);
                }
            }
            else if (ctrl && currentTile != -1)
            {
                Rectangle r = tiles[currentTile].Value;
                for (int i = 0; i < 9; i++)
                {
                    int yy = r.Y + r.Height * SPLITTINGS[i] / 60;
                    e.Graphics.DrawLine(Pens.Blue, r.X, yy, r.X + r.Width, yy);
                    e.Graphics.DrawString("" + (i + 1), vc.Font, Brushes.Blue, r.X + r.Width / 2, yy);
                }
            }
            if (vc.ShowHints)
            {
                String GLOBAL=
                    "Shift+Return: Create new tile fullscreeen\n"+
                    ", or .: Create tile of current window shape\n"+
                    "Ctrl+Shift+(A-Z,0-9): Tile from saved position\n"+
                    "Alt: Options\n"+
                    "Backspace: Back to default mode";
                if (mode == Mode.RENAME)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 150, 30,
                        "Type letter to rename current tile to.");
                }
                else if (mode == Mode.JOIN)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 150, 30,
                        "Type letter of other join corner.");
                }
                else if (currentTile == -1)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 150, 30,
                        "Return: Create new tile fullscreen\n" +
                        GLOBAL
                    );
                }
                else
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 150, 30,
                        "0: Split current tile to custom pieces\n" +
                        "- or 1: Join pieces\n" +
                        "2-9: Split current to preset pieces:\n" +
                        "     2: 2x1, 3: 3x1, 4: 2x2, 5: 1x2\n" +
                        "     6: 3x2, 7: 1x3, 8: 4x2, 9: 3x3\n" +
                        "Ctrl+Digit: Split horizontally (0=custom)\n" +
                        "Shift+Digit: Split vertically (0=custom)\n" +
                        "Return: Place window into current tile\n" +
                        "/, Delete, Space: Delete tile\n" +
                        "Shift+Space, Shift+Delete: Delete all\n" +
                        "a-z,A-Z: Select tile\n" +
                        "':': Rename tile\n" +
                        GLOBAL);
                }
            }
        }

        internal override void KeyDown(KeyEventArgs e)
        {
            Keys KeyCode = e.KeyCode;
            if (KeyCode >= Keys.NumPad0 && KeyCode <= Keys.NumPad9)
            {
                KeyCode = KeyCode - Keys.NumPad0 + Keys.D0;
            }
            if (mode != Mode.NORMAL) return;
            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = true;
                vc.Invalidate();
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
                vc.Invalidate();
            }
            if (e.KeyCode == Keys.Menu)
            {
                vc.NextState = OPTIONS_TILED;
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (shift)
                {
                    for (int i = 0; i < tiles.Length; i++)
                    {
                        tiles[i] = null;
                    }
                    restTiles.Clear();
                }
                else if (currentTile != -1)
                {
                    tiles[currentTile] = null;
                }
                EnsureSelection();
                vc.Invalidate();

            }
            checkmodifiers(e);
            if (ctrl && shift && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                Rectangle? rr = PositionStore.Instance[e.KeyCode - Keys.A + 10];
                if (rr.HasValue)
                {
                    Rectangle r = rr.Value;
                    AssignNextSlot(new Rectangle(r.X, r.Y, r.Width, r.Height));
                    vc.Invalidate();
                }
            }
            else if (ctrl && shift && KeyCode >= Keys.D0 && KeyCode <= Keys.D9)
            {
                Rectangle? rr = PositionStore.Instance[e.KeyCode - Keys.D0];
                if (rr.HasValue)
                {
                    Rectangle r = rr.Value;
                    AssignNextSlot(new Rectangle(r.X, r.Y, r.Width, r.Height));
                    vc.Invalidate();
                }
            }
            else if (ctrl && !shift && KeyCode >= Keys.D1 && KeyCode <= Keys.D9)
            {
                SplitHorizontally(SPLITTINGS[KeyCode - Keys.D1], 60);

            }
            else if (!ctrl && shift && KeyCode >= Keys.D1 && KeyCode <= Keys.D9)
            {
                SplitVertically(SPLITTINGS[KeyCode - Keys.D1], 60);
            }
            else if (ctrl && !shift && KeyCode == Keys.D0)
            {
                string percentage = InputBox.Show(vc.Form, "Split percentage (0-100):", "50");
                try
                {
                    int percent = int.Parse(percentage);
                    if (percent >= 0 && percent <= 100)
                    {
                        SplitHorizontally(percent, 100);
                    }
                }
                catch { }
            }
            else if (!ctrl && shift && KeyCode == Keys.D0)
            {
                string percentage = InputBox.Show(vc.Form, "Split percentage (0-100):", "50");
                try
                {
                    int percent = int.Parse(percentage);
                    if (percent >= 0 && percent <= 100)
                    {
                        SplitVertically(percent, 100);
                    }
                }
                catch { }
            }
        }

        private void SplitVertically(int numerator, int denominator)
        {
            if (currentTile == -1) return;
            Rectangle b = tiles[currentTile].Value;

            tiles[currentTile] = new Rectangle(b.X, b.Y, b.Width * numerator / denominator, b.Height);
            AssignNextSlot(new Rectangle(b.X + b.Width * numerator / denominator, b.Y, b.Width * (denominator - numerator) / denominator, b.Height));

            vc.Invalidate();
        }

        private void SplitHorizontally(int numerator, int denominator)
        {
            if (currentTile == -1) return;
            Rectangle b = tiles[currentTile].Value;

            tiles[currentTile] = new Rectangle(b.X, b.Y, b.Width, b.Height * numerator/denominator);
            AssignNextSlot(new Rectangle(b.X, b.Y + b.Height * numerator/denominator, b.Width, b.Height * (denominator - numerator) / denominator));

            vc.Invalidate();
        }
        
        internal override void KeyUp(KeyEventArgs e)
        {
            if (mode != Mode.NORMAL) return;
            if (e.KeyCode == Keys.ShiftKey)
            {
                shift = false;
                vc.Invalidate();
            }
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = false;
                vc.Invalidate();
            }
            checkmodifiers(e);
        }

        private void checkmodifiers(KeyEventArgs e)
        {
            if (e.Control != ctrl)
            {
                ctrl = e.Control;
                vc.Invalidate();
            }
            if (e.Shift != shift)
            {
                shift = e.Shift;
                vc.Invalidate();
            }
        }


        internal override void KeyPress(KeyPressEventArgs e)
        {
            if (mode != Mode.NORMAL)
            {
                if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                {
                    RenameOrJoin(e.KeyChar - 'a');
                }
                if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                {
                    RenameOrJoin(e.KeyChar - 'A' + 26);
                }
                return;
            }
            switch (e.KeyChar)
            {
                case ',':
                case '.':
                    AssignNextSlot(vc.Adjustment.BaseRect);
                    vc.Invalidate();
                    break;
                case ':':
                    if (currentTile != -1)
                    {
                        mode = Mode.RENAME;
                        vc.Invalidate();
                    }
                    break;
                case '-':
                    if (currentTile != -1)
                    {
                        mode = Mode.JOIN;
                        vc.Invalidate();
                    }
                    break;

            }
            if (ctrl && shift)
            {
            }
            else if (ctrl)
            {
            }
            else if (shift)
            {
                switch (e.KeyChar)
                {
                    case '\r':
                        AssignNextSlot(new Rectangle(0, 0, vc.Width, vc.Height));
                        vc.Invalidate();
                        break;
                    case ' ':
                        for (int i = 0; i < tiles.Length; i++)
                        {
                            tiles[i] = null;
                        }
                        restTiles.Clear();
                        EnsureSelection();
                        vc.Invalidate();
                        break;
                    default:
                        if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                        {
                            Select(e.KeyChar - 'A' + 26);
                        }
                        break;
                }
            }
            else
            {
                switch (e.KeyChar)
                {
                    case '\b':
                        vc.NextState = ViewState.START;
                        break;
                    case '0':
                        CustomSplit();
                        break;
                    case '1':
                        if (currentTile != -1)
                        {
                            mode = Mode.JOIN;
                            vc.Invalidate();
                        }
                        break;
                    case '2': SplitCurrent(2, 1); break;
                    case '3': SplitCurrent(3, 1); break;
                    case '4': SplitCurrent(2, 2); break;
                    case '5': SplitCurrent(1, 2); break;
                    case '6': SplitCurrent(3, 2); break;
                    case '7': SplitCurrent(1, 3); break;
                    case '8': SplitCurrent(4, 2); break;
                    case '9': SplitCurrent(3, 3); break;
                    case '\r':
                        if (currentTile == -1)
                        {
                            AssignNextSlot(new Rectangle(0, 0, vc.Width, vc.Height));
                            vc.Invalidate();
                        }
                        else
                        {
                            Rectangle r = tiles[currentTile].Value;
                            tiles[currentTile] = null;
                            vc.DoResize(0, r.X, r.Y, r.Width, r.Height, true);
                            EnsureSelection();
                        }
                        break;
                    case '/':
                    case ' ':
                        if (currentTile != -1)
                        {
                            tiles[currentTile] = null;
                            EnsureSelection();
                            vc.Invalidate();
                        }
                        break;
                    default:
                        if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                        {
                            Select(e.KeyChar - 'a');
                        }
                        break;
                }
            }
        }

        private void CustomSplit()
        {
            if (currentTile == -1) return;
            int[] xx = parseSpec(InputBox.Show(vc.Form, "Split in X direction:", "1"));
            if (xx == null) return;
            int[] yy = parseSpec(InputBox.Show(vc.Form, "Split in Y direction:", "1"));
            if (yy == null) return;
            int xdiv=0, ydiv=0;
            foreach (int x in xx) { xdiv += x; }
            foreach(int y in yy) {ydiv +=y;}

            Rectangle b = tiles[currentTile].Value;
            tiles[currentTile] = new Rectangle(b.X, b.Y, b.Width *xx[0]/ xdiv, b.Height *yy[0]/ ydiv);
            int yacc = 0;
            for (int i = 0; i < yy.Length; i++)
            {
                int xacc = 0;
                for (int j = 0; j < xx.Length; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        AssignNextSlot(new Rectangle(b.X + xacc * b.Width / xdiv,
                            b.Y + yacc * b.Height / ydiv, b.Width *xx[j]/ xdiv, b.Height *yy[i]/ ydiv));
                    }
                    xacc += xx[j];
                }
                yacc += yy[i];
            }
            vc.Invalidate();


        }

        private int[] parseSpec(string spec)
        {
            if (spec == null) return null;
            try
            {
                if (!spec.Contains(",") && !spec.Contains("*")) spec += "*1";
                List<int> result = new List<int>();
                foreach (string part in spec.Split(','))
                {
                    int pos = part.IndexOf('*');
                    uint width, times;
                    if (pos == -1)
                    {
                        times = 1;
                        width = uint.Parse(part);
                    }
                    else
                    {
                        times = uint.Parse(part.Substring(0, pos));
                        width = uint.Parse(part.Substring(pos + 1));
                    }
                    for (uint i = 0; i < times; i++)
                        result.Add((int)width);
                }
                if (result.Count == 0) throw new Exception();
                return result.ToArray();
            }
            catch
            {
                MessageBox.Show(vc.Form, "Input could not be parsed");
                return null;
            }
        }

        private void RenameOrJoin(int index)
        {
            if (mode == Mode.RENAME)
            {
                Rectangle? tmp = tiles[currentTile];
                tiles[currentTile] = tiles[index];
                tiles[index] = tmp;
                currentTile = index;
            }
            else if (mode == Mode.JOIN)
            {
                if (tiles[index] == null)
                {
                    return;
                }
                Rectangle r1 = tiles[currentTile].Value;
                Rectangle r2 = tiles[index].Value;
                Rectangle newRect = Rectangle.FromLTRB(Math.Min(r1.Left, r2.Left), Math.Min(r1.Top, r2.Top),
                    Math.Max(r1.Right, r2.Right), Math.Max(r1.Bottom, r2.Bottom));
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (tiles[i] != null)
                    {
                        Rectangle rr1 = tiles[i].Value, rr2 = new Rectangle(rr1.X, rr1.Y, rr1.Width, rr1.Height);
                        rr2.Intersect(newRect);
                        if (rr1 == rr2)
                        {
                            tiles[i] = null;
                        }
                    }
                }
                for(int i=0; i< restTiles.Count; i++) {
                    Rectangle rr1 = restTiles[i], rr2 = new Rectangle(rr1.X, rr1.Y, rr1.Width, rr1.Height);
                    rr2.Intersect(newRect);
                    if (rr1 == rr2)
                        {
                        restTiles.RemoveAt(i);
                        i--;
                    }
                }
                tiles[currentTile] = newRect;
            }
            EnsureSelection();
            mode = Mode.NORMAL;
            vc.Invalidate();
        }

        private void SplitCurrent(int xdiv, int ydiv)
        {
            if (currentTile == -1) return;
            Rectangle b = tiles[currentTile].Value;
            tiles[currentTile] = new Rectangle(b.X, b.Y, b.Width / xdiv, b.Height / ydiv);
            for (int i = 0; i < ydiv; i++)
            {
                for (int j = 0; j < xdiv; j++)
                {
                    if (i == 0 && j == 0) continue;
                    AssignNextSlot(new Rectangle(b.X + j * b.Width / xdiv,
                        b.Y + i * b.Height / ydiv, b.Width / xdiv, b.Height / ydiv));
                }
            }
            vc.Invalidate();
        }

        private void Select(int index)
        {
            if (tiles[index] != null)
            {
                currentTile = index;
                vc.Invalidate();
            }
        }
    }
}
