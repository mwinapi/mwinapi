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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ManagedWinapi
{
  /// <summary>
  /// Provides uniform caret appearance across <see cref="TextBox"/>
  /// <see cref="Control"/> types in a form.
  /// </summary>
  [ProvideProperty("UseCaret", typeof(Control))]
  public class TextCursorProvider : Component, IExtenderProvider
  {
    /// <summary>
    /// A single <code>TextCursor</code> instance is used for all associated
    /// <see cref="Control"/> instances. This provides a uniform look across
    /// the form.
    /// </summary>
    public TextCursor Caret { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Used during design mode only: keeps track of controls that have been
    /// elected to use a custom caret.
    /// </summary>
    private List<Control> controlSet;

    //-------------------------------------------------------------------------

    /// <summary>
    /// A uniform style text cursor is associated with all supported
    /// <see cref="Control"/> types. The caret, by default, is black with a
    /// width of 1 pixel.
    /// </summary>
    public TextCursorProvider()
    {
      Caret = new TextCursor();
      controlSet = new List<Control>();
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The width of the caret in pixels. If the caret exceeds the bounds of the
    /// <see cref="Control"/>, it is clipped.
    /// </summary>
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(1)]
    [Description("The width of the caret in pixels. If the caret exceeds the bounds of the Control, it is clipped.")]
    public int Width
    {
      get { return Caret.Width; }
      set { Caret.Width = value; }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The color of the caret. This color is ignored if a custom bitmap image
    /// is used.
    /// </summary>
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Black")]
    [Description("The colour of the caret. This color is ignored if a custom bitmap image is used.")]
    public Color Color
    {
      get { return Caret.Color; }
      set { Caret.Color = value; }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// A custom bitmap image used to render the caret. If <code>null</code>,
    /// the caret will take have the usual block form. If the image height
    /// exceeds the <see cref="Control"/> height, it is automatically truncated.
    /// </summary>
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("A custom bitmap image used to render the caret. If null, the caret will take have the usual block form. If the image height exceeds the Control height, it is automatically truncated.")]
    public Bitmap CursorImage
    {
      get { return Caret.CursorImage; }
      set { Caret.CursorImage = value; }
    }

    //-------------------------------------------------------------------------

    #region UseCaret

    /// <summary>
    /// When <code>true</code>, the caret properties, as specified by the
    /// <code>TextCursorProvider</code> component instance, will be applied to the
    /// caret used for the specified control.
    /// </summary>
    /// <param name="control">A <see cref="Control"/> instance.</param>
    /// <returns><code>true</code> if and only if a custom caret will be used
    /// for the specified control.</returns>
    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("When true, the caret properties, as specified by the TextCursorProvider component instance, will be applied to the caret used for this Control.")]
    public bool GetUseCaret(Control control)
    {
      return this.controlSet.Contains(control);
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The specified <see cref="Control"/> is bound to the custom caret.
    /// </summary>
    /// <param name="control">A control instance that uses a caret.</param>
    /// <param name="value"><code>true</code> if and only if the custom caret
    /// should be used by the control instance.</param>
    public void SetUseCaret(Control control, bool value)
    {
      if (DesignMode)
      {
        if (value)
        {
          if (!controlSet.Contains(control))
          {
            controlSet.Add(control);
          }
        }
        else
        {
          controlSet.Remove(control);
        }
      }
      if (value)
      {
        Caret.ApplyBinding(control);
      }
      else
      {
        Caret.RemoveBinding(control);
      }
    }

    #endregion UseCaret

    //-------------------------------------------------------------------------

    /// <summary>
    /// Returns <code>true</code> if and only if a custom <see cref="TextCursor"/>
    /// is fully compatible with the specified <see cref="Control"/>.
    /// </summary>
    /// <param name="extendee">The design time object that might be compatible
    /// with the caret. Currently only <see cref="TextBox"/> is supported.</param>
    /// <returns><code>true</code> if and only if the custom caret can be
    /// applied to the specified control.</returns>
    public bool CanExtend(object extendee)
    {
      return extendee is TextBox;
    }
  }
}