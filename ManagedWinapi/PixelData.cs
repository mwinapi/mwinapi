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

namespace ManagedWinapi
{
  /// <summary>
  /// Provides pixel color information and manipulation.
  /// </summary>
  public class PixelData
  {
    /// <summary>
    /// The x coordinate of the image where the top left corner of the image
    /// is (0, 0).
    /// </summary>
    public int X { get; internal set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The y coordinate of the image where the top left corner of the image
    /// is (0, 0).
    /// </summary>
    public int Y { get; internal set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The red component color value of the pixel. Valid values are 0 through
    /// 255.
    /// </summary>
    public byte R { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The green component color value of the pixel. Valid values are 0 through
    /// 255.
    /// </summary>
    public byte G { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The blue component color value of the pixel. Valid values are 0 through
    /// 255.
    /// </summary>
    public byte B { get; set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Describes the pixel at the specified coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the image where the top left corner
    /// of the image is (0, 0).</param>
    /// <param name="y">The y coordinate of the image where the top left corner
    /// of the image is (0, 0).</param>
    /// <param name="r">The red component color value of the pixel. Valid
    /// values are 0 through 255.</param>
    /// <param name="g">The green component color value of the pixel. Valid
    /// values are 0 through 255.</param>
    /// <param name="b">The blue component color value of the pixel. Valid
    /// values are 0 through 255.</param>
    public PixelData(int x, int y, byte r, byte g, byte b)
    {
      X = x;
      Y = y;
      R = r;
      G = g;
      B = b;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Creates a new <code>PixelData</code> instance from an existing instance.
    /// The pixel information is completely copied and no link between the two
    /// instance will maintained.
    /// </summary>
    /// <param name="pixel">A <code>PixelData</code> instance.</param>
    public PixelData(PixelData pixel)
    {
      if (pixel == null)
      {
        throw new ArgumentException("Unable to clone a null instance of PixelData.");
      }
      X = pixel.X;
      Y = pixel.Y;
      R = pixel.R;
      G = pixel.G;
      B = pixel.B;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// To prevent inconsistent use of the pixel coordinates,
    /// <code>PixelData</code> cannot be instantiated without pixel coordinates.
    /// </summary>
    internal PixelData()
    {
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The <see cref="Color"/> of the pixel at the <see cref="X"/> and
    /// <see cref="Y"/> coordinates of the image.
    /// </summary>
    /// <returns>The ARGB (alpha, red, green, blue) color of the pixel.</returns>
    public Color GetColor()
    {
      return Color.FromArgb(R, G, B);
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Sets the color of the pixel at the <see cref="X"/> and <see cref="Y"/>
    /// coordinates of the image. The color of the pixel can be modified by
    /// directly changing the <see cref="R"/>, <see cref="G"/>, and <see cref="B"/>
    /// color component values of the pixel.
    /// </summary>
    /// <param name="color">The new pixel color.</param>
    public void SetColor(Color color)
    {
      R = color.R;
      G = color.G;
      B = color.B;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public PixelData Clone()
    {
      return new PixelData(X, Y, R, G, B);
    }
  }
}