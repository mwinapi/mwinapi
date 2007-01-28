using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ManagedWinapi.Windows;
using System.Windows.Forms;

namespace NeatKeys.Views
{
    public interface ViewContainer : IDisposable
    {
        Form Form { get;}
        int DisplayWidth { get;}
        int DisplayHeight { get;}
        int Width { get;}
        int Height { get;}
        bool ShowHints { get; set;}
        Color ForeColor { get;}
        Color BackColor { get;}
        Font Font { get;}
        void Hide();
        int CurrentScreen { get; set;}
        int ScreenCount { get;}
        SystemWindow CurrentTarget { get;}
        ViewState NextState { set;}
        RectangleAdjustment Adjustment { get;}
        void DoResize(int factor, int x, int y, int width, int height, bool hide);
        void DoAlign(bool allWindows);

        int Opacity { get; set;}

        void Invalidate();
    }
}
