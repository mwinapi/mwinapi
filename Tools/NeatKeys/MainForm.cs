using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;
using NeatKeys.Views;

namespace NeatKeys
{
    public partial class MainForm : Form, ViewContainer
    {

        ViewState view;
        SystemWindow fgWindow;
        bool hintsEnabled = true;
        int currentScreen;
        RectangleAdjustment adjustment = new RectangleAdjustment();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void placeOnScreen()
        {
            Rectangle r = Screen.AllScreens[currentScreen].WorkingArea;
            this.Top = r.Top;
            this.Width = r.Width;
            this.Height = r.Height;
            this.Left = r.Left;
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            view.VC = this;
            view.Paint(e);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            view.VC = this;
            view.MouseDown(e);
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            view.VC = this;
            view.MouseUp(e);
        }

 

        public bool ShowHints
        {
            get
            {
                return hintsEnabled;
            }
            set
            {
                hintsEnabled = value;
                Invalidate();
            }
        }


        public int DisplayWidth
        {
            get { return Width; }
        }

        public int DisplayHeight
        {
            get { return Height; }
        }



        public int CurrentScreen
        {
            get
            {
                return currentScreen;
            }
            set
            {
                if (value < 0 || value >= Screen.AllScreens.Length)
                {
                    throw new ArgumentException();
                }
                currentScreen = value;
                if (Visible) placeOnScreen();
            }
        }

        public ViewState NextState
        {
            set {
                view = value;
                view.restart();
                Invalidate();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            view.VC = this;
            view.InternalKeyDown(e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            view.VC = this;
            view.KeyUp(e);
        }



        public int ScreenCount
        {
            get { return Screen.AllScreens.Length; }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDispose();
        }

        private void startNeatKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Visible) start(fgCache);
        }

        private void start(SystemWindow fgWindow)
        {
            view = ViewState.START;
            if (((TilingViewState)ViewState.TILING).HasTiles) view = ViewState.TILING;
            view.restart();
            if (findWindow(fgWindow))
            {
                placeOnScreen();
                Visible = true;
            }
        }

        private bool findWindow(SystemWindow fg) {
            fgWindow = fg;
            if (!fgWindow.Visible) {
                MessageBox.Show("Foreground window is not visible!", "NeatKeys");
                return false;
            }
            if (!fgWindow.Enabled) {
                MessageBox.Show("Foreground window is disabled!", "NeatKeys");
                return false;
            }
            if (!fgWindow.Movable)
            {
                MessageBox.Show("Foreground window is not movable!", "NeatKeys");
                return false;
            }
            Screen s = Screen.FromHandle(fgWindow.HWnd);
            currentScreen = -1;
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (Screen.AllScreens[i].Equals(s))
                {
                    currentScreen = i;
                    break;
                }
            }
            if (currentScreen == -1)
            {
                MessageBox.Show("Cannot detect current screen!");
                currentScreen = 0;
            }
            Rectangle rr = fgWindow.Position.ToRectangle();
            rr.Offset(-s.WorkingArea.Left, -s.WorkingArea.Top);
            adjustment.reset(rr, fgWindow.Title);
            return true;
        }

        private void hotKeyKeypad_HotkeyPressed(object sender, EventArgs e)
        {
            if (!Visible) start(SystemWindow.ForegroundWindow);
        }

        private void hotkeyMain_HotkeyPressed(object sender, EventArgs e)
        {
            if (!Visible) start(SystemWindow.ForegroundWindow);
        }

        private void MyDispose()
        {
            Dispose();
            PositionStore.Instance.Save();
            Application.Exit();
        }

        void IDisposable.Dispose()
        {
            MyDispose();
        }

        public SystemWindow CurrentTarget
        {
            get
            {
                return fgWindow;
            }
        }

        int ViewContainer.Opacity
        {
            get
            {
                return (int)(Opacity * 100);
            }
            set
            {
                Opacity = value / 100.0;
            }
        }


        public RectangleAdjustment Adjustment
        {
            get { return adjustment; }
        }





        public void DoResize(int factor, int x, int y, int w, int h, bool hide)
        {
            if (!fgWindow.Movable || !fgWindow.Enabled || !fgWindow.Visible) return;
            Rectangle r;
            Rectangle wa = Screen.AllScreens[currentScreen].WorkingArea;
            Rectangle fgp = adjustment.BaseRect;
            if (factor == 0)
            {
                r = new Rectangle(x, y, w, h);
            }
            else if (factor == -1)
            {
                r = new Rectangle(fgp.X, fgp.Y, fgp.Width, fgp.Height);
            }
            else
            {
                int xx, yy, ww, hh;
                if (x == -1)
                {
                    xx = fgp.X;
                    ww = fgp.Width;
                }
                else
                {
                    xx = wa.Width * x / factor;
                    ww = wa.Width * w / factor;
                }
                if (y == -1)
                {
                    yy = fgp.Y;
                    hh = fgp.Height;
                }
                else
                {
                    yy = wa.Height * y / factor;
                    hh = wa.Height * h / factor;
                }
                r = new Rectangle(xx, yy, ww, hh);
            }
            r.Offset(wa.Location);
            r = adjustment.adjust(r);
            if (!fgWindow.Resizable)
            {
                if (r.Width != fgp.Width || r.Height != fgp.Height)
                {
                    r.X += (r.Width - fgp.Width) / 2;
                    r.Y += (r.Height - fgp.Height) / 2;
                    r.Width = fgp.Width;
                    r.Height = fgp.Height;
                }
            }
            Visible = false;
            FormWindowState oldws = fgWindow.WindowState;
            fgWindow.WindowState = FormWindowState.Normal;
            fgWindow.Position = RECT.FromRectangle(r);
            fgWindow.WindowState = oldws;
            if (hide)
            {
                SystemWindow.ForegroundWindow = fgWindow;
            }
            else
            {
                Visible = true;
            }
        }


        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            view.VC = this;
            view.KeyPress(e);
        }


        public Form Form
        {
            get { return this; }
        }

        private void trayIcon_MouseDown(object sender, MouseEventArgs e)
        {
            fgCache = fgCache2;
            if (fgCache == null) fgCache = SystemWindow.ForegroundWindow;
        }

        private SystemWindow fgCache, fgCache2;

        private void trayIcon_MouseMove(object sender, MouseEventArgs e)
        {
            fgCache2 = SystemWindow.ForegroundWindow;
        }

        private void mouseModeMenuItem_Click(object sender, EventArgs e)
        {
            startMouse(fgCache);
        }

        MouseForm mf;

        private void startMouse(SystemWindow fg)
        {
            if (findWindow(fg))
            {
                if (DrawForm.Reactivate()) return;
                mf = new MouseForm(this);
            }
        }

        private void trayIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                startMouse(fgCache);
        }

        private void alignCurrentMenuItem_Click(object sender, EventArgs e)
        {
            align(fgCache);
        }

        public void DoAlign(bool allWindows)
        {
            if (allWindows)
            {
                alignAll();
            }
            else
            {
                align(fgWindow);
            }
            Hide();
        }

        private void alignAll()
        {
            foreach (SystemWindow sw in SystemWindow.AllToplevelWindows)
            {
                if (sw.Visible && sw.Enabled && sw.Movable && sw.Resizable && sw.WindowState == FormWindowState.Normal)
                {
                    align(sw);
                }
            }
        }

        private void align(SystemWindow fg)
        {
            if (!fg.Visible)
            {
                MessageBox.Show("Window is not visible!", "NeatKeys");
                return;
            }
            if (!fg.Enabled)
            {
                MessageBox.Show("Window is disabled!", "NeatKeys");
                return;
            }
            if (!fg.Movable)
            {
                MessageBox.Show("Window is not movable!", "NeatKeys");
                return;
            }
            if (!fg.Resizable)
            {
                MessageBox.Show("Window is not resizable!", "NeatKeys");
                return;
            }
            if (fg.WindowState != FormWindowState.Normal)
            {
                MessageBox.Show("Window is minimized or maximized!", "NeatKeys");
                return;
            }
            Rectangle wa = Screen.FromHandle(fg.HWnd).WorkingArea;
            Rectangle r = fg.Position.ToRectangle();
            r.Offset(-wa.X, -wa.Y);
            int dx = wa.Width / 12;
            int dy = wa.Height / 12;
            int nx = ((r.X *24 + wa.Width) / (wa.Width*2)) * wa.Width / 12;
            int nw = ((r.Width *24+wa.Width) / (wa.Width * 2)) * wa.Width / 12;
            int ny = ((r.Y *24+ wa.Height) / (wa.Height*2)) * wa.Height / 12;
            int nh = ((r.Height* 24+wa.Height) / (wa.Height * 2)) * wa.Height / 12;
            r = new Rectangle(nx, ny, nw, nh);
            fg.Position = RECT.FromRectangle(r);
        }

        private void alignAllMenuItem_Click(object sender, EventArgs e)
        {
            alignAll();
        }
    }
}