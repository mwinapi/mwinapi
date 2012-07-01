/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2011 Michael Schierl
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; see the file COPYING. if not, visit
 * http://www.gnu.org/licenses/lgpl.html or write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ManagedWinapi
{
  /// <summary>
  /// Allows the appearance of a caret to be modified. If the caret has a block
  /// form, the width, height and color can be modified. The caret can also be
  /// specified using a bitmap. In both cases, if the caret exceeds the bounds
  /// of the <see cref="Control"/> that contains the caret, it is clipped.
  ///
  /// Not all <see cref="Control"/> types will be able to correctly display a
  /// custom caret.
  /// </summary>
  public class TextCursor
  {
    #region WinAPI

    /// <summary>
    /// Creates a new shape for the system caret and assigns ownership of the
    /// caret to the specified <see cref="Control"/>. The caret shape can be a line, a block,
    /// or a bitmap.
    /// See: http://msdn.microsoft.com/en-us/library/windows/desktop/ms648399(v=vs.85).aspx
    /// </summary>
    /// <param name="hWnd">A handle to the <see cref="Control"/> that owns the caret.</param>
    /// <param name="hBitmap">A handle to the bitmap that defines the caret
    /// shape. If this parameter is <code>NULL</code>, the caret is solid. If this parameter
    /// is <code>(HBITMAP)</code> 1, the caret is gray. If this parameter is a bitmap handle,
    /// the caret is the specified bitmap; note that a mask is applied on the
    /// bitmap that will change the color used by the caret based on the background color.</param>
    /// <param name="w">The width of the caret, in logical units. If this
    /// parameter is zero, the width is set to the system-defined window border
    /// width. If <code>hBitmap</code> is a bitmap handle, <code>CreateCaret</code> ignores
    /// this parameter.</param>
    /// <param name="h">The height of the caret, in logical units. If this
    /// parameter is zero, the height is set to the system-defined window border
    /// height. If <code>hBitmap</code> is a bitmap handle, <code>CreateCaret</code> ignores
    /// this parameter.</param>
    /// <returns>If the function succeeds, the return value is nonzero. If the
    /// function fails, the return value is zero.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int w, int h);

    //-------------------------------------------------------------------------

    /// <summary>
    /// Makes the caret visible on the screen at the caret's current position.
    /// When the caret becomes visible, it begins flashing automatically.
    /// See: http://msdn.microsoft.com/en-us/library/windows/desktop/ms648406(v=vs.85).aspx
    /// </summary>
    /// <param name="hWnd">A handle to the <see cref="Control"/> that owns the
    /// caret. If this parameter is <code>NULL</code>, <code>ShowCaret</code>
    /// searches the current task for the window that owns the caret.</param>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool ShowCaret(IntPtr hWnd);

    //-------------------------------------------------------------------------

    /// <summary>
    /// Destroys the caret's current shape, frees the caret from the <see cref="Control"/>,
    /// and removes the caret from the screen.
    /// See: http://msdn.microsoft.com/en-us/library/windows/desktop/ms648400(v=vs.85).aspx
    /// </summary>
    /// <returns>If the function succeeds, the return value is nonzero.</returns>
    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool DestroyCaret();

    #endregion WinAPI

    //-------------------------------------------------------------------------

    /// <summary>
    /// The height of the caret. When <code>null</code>, the height is
    /// determined by the font height of the <see cref="ParentControl"/>.
    /// </summary>
    private int? height;

    //-------------------------------------------------------------------------

    /// <summary>
    /// The actual bitmap used to render the caret. A bitmap is used regardless
    /// of the way in which the caret is prescribed; however, a mask must first
    /// be applied to the bitmap. This stores the result of the bitmap mask.
    /// </summary>
    private Bitmap image;

    //-------------------------------------------------------------------------

    /// <summary>
    /// If the background colour of the Control changes, the colour mask
    /// needs to be reapplied to the original bitmap.
    /// </summary>
    private Bitmap originalUserBitmap;

    //-------------------------------------------------------------------------

    /// <summary>
    /// The <see cref="Control"/> that is currently, or had last displayed the
    /// caret. The displayed color of the caret is dependant on the background
    /// colour of the control.
    /// </summary>
    public Control ParentControl { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// A custom bitmap image used to render the caret. If <code>null</code>,
    /// the caret will take have the usual block form. If the image height
    /// exceeds the <see cref="Control"/> height, it is automatically truncated.
    /// </summary>
    public Bitmap CursorImage
    {
      get
      {
        return this.originalUserBitmap;
      }
      set
      {
        this.originalUserBitmap = value;
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Applies an XOR mask using the specified colours. The transparency
    /// (alpha value) is ignored.
    /// </summary>
    /// <param name="original">Represents an ARGB (alpha, red, green, blue)
    /// color.</param>
    /// <param name="background">Represents an ARGB (alpha, red, green, blue)
    /// color.</param>
    /// <returns>The new color resulting from the XOR mask.</returns>
    public static Color XorColorMask(Color original, Color background)
    {
      int r = original.R ^ background.R;
      int g = original.G ^ background.G;
      int b = original.B ^ background.B;
      return Color.FromArgb(r, g, b);
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The color of the caret. This color is ignored if a custom bitmap image
    /// is used.
    /// </summary>
    public Color Color { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The width of the caret in pixels. If the caret exceeds the bounds of the
    /// <see cref="Control"/>, it is clipped.
    /// </summary>
    public int Width { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// <code>true</code> if and only if a <see cref="ParentControl"/> has
    /// focus.
    /// </summary>
    public bool HasFocus { get; private set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The height of the caret. If <code>null</code>, the height is determined
    /// from the font height of the <see cref="ParentControl"/>. If the bounds
    /// of the caret exceed that of the control, the caret is automatically clipped.
    /// </summary>
    public int? Height
    {
      get
      {
        return this.height;
      }
      set
      {
        this.height = value;
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Creates a new white caret with a width of 1; the height of the caret
    /// will match the font height used by the <see cref="ParentControl"/>.
    /// </summary>
    public TextCursor()
    {
      Width = 1;
      Color = Color.Black;
      HasFocus = false;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Creates a new white caret with a width of 1; the height of the caret
    /// will match the font height used by the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="parentControl">Events are registered against this control
    /// so that the custom caret will be visible when applicable.</param>
    public TextCursor(Control parentControl)
      : this()
    {
      ApplyBinding(parentControl);
      ParentControl = parentControl;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Causes the specified <see cref="Control"/> to display the custom caret.
    /// </summary>
    /// <param name="control">The control that requires a custom caret.</param>
    public void ApplyBinding(Control control)
    {
      control.GotFocus += OnFocus;
      control.LostFocus += LostFocus;
      // The caret color depends on the background color, and so must be updated
      // should the background color change:
      control.BackColorChanged += (sender, eventArgs) => { HasFocus = false; };
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Displays the custom caret on the specified Control. The cursor position
    /// is determined automatically. Only one caret instance can exist at any
    /// given time. Therefore a caret should only be displayed if the
    /// <see cref="Control"/> has focus. This can be automatically achieved by
    /// using <see cref="ApplyBinding"/>. When the caret should not longer be
    /// visible, use <see cref="HideCursor"/>.
    /// </summary>
    /// <param name="control">The caret will be displayed in this control.</param>
    public void DisplayCaret(Control control)
    {
      if (control == null)
      {
        return;
      }
      if (this.originalUserBitmap != null)
      {
        this.image = new Bitmap(this.originalUserBitmap);
        using (BitmapDataHandler pixelData = new BitmapDataHandler(image))
        {
          pixelData.Enumerate((pixel) =>
          {
            pixel.R ^= ParentControl.BackColor.R;
            pixel.G ^= ParentControl.BackColor.G;
            pixel.B ^= ParentControl.BackColor.B;
          });
        }
      }
      else
      {
        int caretHeight = this.height ?? ParentControl.Font.Height;
        this.image = new Bitmap(Width, caretHeight);
        using (Graphics cursorGraphics = Graphics.FromImage(this.image))
        {
          using (SolidBrush brush = new SolidBrush(XorColorMask(Color, ParentControl.BackColor)))
          {
            cursorGraphics.FillRectangle(brush, 0, 0, Width, caretHeight);
          }
        }
      }
      if (CreateCaret(ParentControl.Handle, this.image.GetHbitmap(), 0, 0))
      {
        ShowCaret(ParentControl.Handle);
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Called when a bound control has focus. This updates
    /// <see cref="ParentControl"/>.
    /// </summary>
    /// <param name="sender">The parent control.</param>
    /// <param name="e">Event information; this is not used.</param>
    private void OnFocus(object sender, EventArgs e)
    {
      if (HasFocus)
      {
        return;
      }
      HasFocus = true;
      ParentControl = sender as Control;
      DisplayCaret(ParentControl);
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Called when the bound control has lost focus.
    /// </summary>
    /// <param name="sender">The parent control.</param>
    /// <param name="e">Event information; not used.</param>
    private void LostFocus(object sender, EventArgs e)
    {
      if (HasFocus)
      {
        HasFocus = false;
        HideCursor();
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Will destroy the caret if visible regardless of the <see cref="Control"/>
    /// that has focus.
    /// </summary>
    public void HideCursor()
    {
      DestroyCaret();
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Removes any existing associations between the <see cref="Control"/>
    /// instance and this <code>TextCursor</code> instance. That is, the control
    /// will no longer use a custom caret. Has no effect if the association did
    /// not exist before.
    /// </summary>
    /// <param name="control">A <see cref="Control"/> that is using a custom
    /// caret via <see cref="ApplyBinding"/>.</param>
    public void RemoveBinding(Control control)
    {
      control.GotFocus -= OnFocus;
      control.LostFocus -= LostFocus;
    }
  }
}