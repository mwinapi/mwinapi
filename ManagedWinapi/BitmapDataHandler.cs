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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ManagedWinapi
{
  /// <summary>
  /// Locks the entire bitmap image into system memory and caches write
  /// request. This will improve performance for large scale changes.
  ///
  /// This class only supports images that use 24 bits per pixel:
  /// <see cref="PixelFormat.Format24bppRgb"/>.
  /// </summary>
  public class BitmapDataHandler : IDisposable
  {
    /// <summary>
    /// The pixel data from the image. Changes to this array will only reflect
    /// in the image when it is copied back to the image memory.
    /// </summary>
    private byte[] pixelData;

    //-------------------------------------------------------------------------

    /// <summary>
    /// The number of bytes used to represent a single pixel in the image.
    /// </summary>
    internal const byte BYTES_PER_PIXEL = 3;

    //-------------------------------------------------------------------------

    /// <summary>
    /// Provides access to the underlying bitmap data. This is required to
    /// unlock the bitmap memory.
    /// </summary>
    private BitmapData bitmapData;

    //-------------------------------------------------------------------------

    /// <summary>
    /// The bitmap image used to create the handler. Once a bitmap image is
    /// locked, only changes via the <see cref="BitmapDataHandler"/> instance
    /// are valid.
    /// </summary>
    public Bitmap Bitmap { get; private set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// The image may only be modified while it is locked. Disposing the
    /// <see cref="BitmapDataHandler"/> instance will unlock the bitmap memory.
    /// </summary>
    public bool Locked { get; private set; }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Locks the bitmap image into system memory. External changes to the
    /// bitmap will no longer be valid. The image must be in the
    /// <see cref="PixelFormat.Format24bppRgb"/> pixel format.
    /// </summary>
    /// <param name="bmp">The bitmap image that should be locked to enable
    /// faster data modification.</param>
    /// <exception cref="ArgumentException">The pixel format is not supported.
    /// This class only supports images that use 24 bits per pixel.</exception>
    /// <exception cref="Exception">The lock operation was not possible.</exception>
    public BitmapDataHandler(Bitmap bmp)
    {
      Bitmap = bmp;
      this.bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      this.pixelData = new byte[this.bitmapData.Stride * this.bitmapData.Height];
      Marshal.Copy(this.bitmapData.Scan0, pixelData, 0, this.pixelData.Length);
      Locked = true;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Gets the color of the pixel at the specified coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the image where the top left
    /// corner of the image is (0, 0). Must be a positive number &lt; the width
    /// of the image.</param>
    /// <param name="y">The y coordinate of the image where the top left
    /// corner of the image is (0, 0). Must be a positive number &lt; the height
    /// of the image.</param>
    /// <returns>The color of the pixel.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If the pixel
    /// coordinates are invalid.</exception>
    /// <exception cref="InvalidOperationException">If the bitmap is no longer
    /// locked.</exception>
    public Color GetPixel(int x, int y)
    {
      VerifyArugments(x, y);
      int index = y * this.bitmapData.Stride + x * BYTES_PER_PIXEL;
      byte blue = this.pixelData[index];
      ++index;
      byte green = this.pixelData[index];
      ++index;
      byte red = this.pixelData[index];
      return Color.FromArgb(red, green, blue);
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Represents the method that will handle pixel enumeration. For each
    /// pixel in the image, this method is invoked.
    /// </summary>
    /// <param name="data">The pixel data.</param>
    public delegate void EnumerationHandler(PixelData data);

    //-------------------------------------------------------------------------

    /// <summary>
    /// Occurs when <see cref="BitmapDataHandler.Enumerate()"/> is invoked. Pixels are
    /// enumerated from the top left corner of the image, line by line.
    /// The <see cref="PixelData"/> is updated at each step of the enumeration;
    /// that is, a new <see cref="PixelData"/> instance is not created at each
    /// step. Modifying the <see cref="PixelData"/> will modify the bitmap
    /// image when the <see cref="Dispose"/> or <see cref="Flush"/> is invoked
    /// on the bitmap handler.
    /// </summary>
    public event EnumerationHandler Enumerator;

    //-------------------------------------------------------------------------

    /// <summary>
    /// Will enumerate through the pixels in the image. For each pixel in the
    /// image, the event <see cref="Enumerator"/> is triggered. Pixels are
    /// enumerated from the top left corner of the image, line by line.
    /// The <see cref="PixelData"/> is updated at each step of the enumeration;
    /// that is, a new <see cref="PixelData"/> instance is not created at each
    /// step. Modifying the <see cref="PixelData"/> will modify the bitmap
    /// image when the <see cref="Dispose"/> or <see cref="Flush"/> is invoked
    /// on the bitmap handler.
    /// </summary>
    public void Enumerate()
    {
      if (Enumerator != null)
      {
        Enumerate(Enumerator);
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Iterates through the pixels of the bitmap image. For each pixel, the
    /// specified <code>delegate</code> is called.  Pixels are enumerated from
    /// the top left corner of the image, line by line. The <see cref="PixelData"/>
    /// is updated at each step of the enumeration; that is, a new
    /// <see cref="PixelData"/> instance is not created at each step. Modifying
    /// the <see cref="PixelData"/> will modify the bitmap image when the
    /// <see cref="Dispose"/> or <see cref="Flush"/> is invoked on the bitmap
    /// handler.
    /// </summary>
    /// <param name="enumerator">The <code>delegate</code> that will handle
    /// pixel enumeration.</param>
    public void Enumerate(EnumerationHandler enumerator)
    {
      if (!Locked)
      {
        throw new InvalidOperationException("The bitmap is no longer locked; pixel information is no longer maintained.");
      }

      PixelData pixel = new PixelData();
      for (int ycoordinate = 0; ycoordinate < Bitmap.Height; ++ycoordinate)
      {
        int offset = ycoordinate * this.bitmapData.Stride;
        for (int xcoordinate = 0; xcoordinate < Bitmap.Width; ++xcoordinate)
        {
          int bIndex = offset + xcoordinate * BYTES_PER_PIXEL;
          int gIndex = bIndex + 1;
          int rIndex = gIndex + 1;
          pixel.X = xcoordinate;
          pixel.Y = ycoordinate;
          pixel.R = this.pixelData[rIndex];
          pixel.G = this.pixelData[gIndex];
          pixel.B = this.pixelData[bIndex];

          enumerator(pixel);

          this.pixelData[rIndex] = pixel.R;
          this.pixelData[gIndex] = pixel.G;
          this.pixelData[bIndex] = pixel.B;
        }
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Sets the color of the pixel at the specified coordinates.
    /// </summary>
    /// <param name="x">The x coordinate of the image where the top left
    /// corner of the image is (0, 0). Must be a positive number &lt; the width
    /// of the image.</param>
    /// <param name="y">The y coordinate of the image where the top left
    /// corner of the image is (0, 0). Must be a positive number &lt; the height
    /// of the image.</param>
    /// <param name="color">The new color of the pixel.</param>
    /// <exception cref="ArgumentOutOfRangeException">If the pixel
    /// coordinates are invalid.</exception>
    /// <exception cref="InvalidOperationException">If the bitmap is no longer
    /// locked.</exception>
    public void SetPixel(int x, int y, Color color)
    {
      VerifyArugments(x, y);
      int index = y * this.bitmapData.Stride + x * BYTES_PER_PIXEL;

      this.pixelData[index] = color.B;
      ++index;
      this.pixelData[index] = color.G;
      ++index;
      this.pixelData[index] = color.R;
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Verifies that the pixel coordinates are valid and the the bitmap is
    /// locked.
    /// </summary>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <exception cref="ArgumentOutOfRangeException">If the pixel
    /// coordinates are invalid.</exception>
    /// <exception cref="InvalidOperationException">If the bitmap is no longer
    /// locked.</exception>
    private void VerifyArugments(int x, int y)
    {
      if (x < 0)
      {
        throw new ArgumentOutOfRangeException("The x pixel coordinate must be positive. The width of the image is " +
          Bitmap.Width + "; the x value given is " + x + ".");
      }
      if (x >= Bitmap.Width)
      {
        throw new ArgumentOutOfRangeException("The x pixel coordinate must less than the width of the image. The width of the image is " +
          Bitmap.Width + "; the x value given is " + x + ".");
      }
      if (y < 0)
      {
        throw new ArgumentOutOfRangeException("The y pixel coordinate must be positive. The height of the image is " +
          Bitmap.Height + "; the y value given is " + y + ".");
      }
      if (x >= Bitmap.Width)
      {
        throw new ArgumentOutOfRangeException("The y pixel coordinate must less than the height of the image. Thee height of the image is " +
          Bitmap.Height + "; the y value given is " + y + ".");
      }
      if (!Locked)
      {
        throw new InvalidOperationException("The bitmap is no longer locked; pixel information is no longer maintained.");
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// Cached changes are written to the image; the image will still remain in
    /// a locked state.
    /// </summary>
    public void Flush()
    {
      if (Locked)
      {
        Marshal.Copy(pixelData, 0, this.bitmapData.Scan0, pixelData.Length);
      }
    }

    //-------------------------------------------------------------------------

    /// <summary>
    /// All changes are written to the bitmap image and the image is unlocked.
    /// This has no effect if the image is already unlocked.
    /// </summary>
    public void Dispose()
    {
      if (Locked)
      {
        Flush();
        Locked = false;
        Bitmap.UnlockBits(this.bitmapData);
        pixelData = null;
      }
    }

    //-------------------------------------------------------------------------
  }
}