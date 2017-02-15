using System;
using System.Windows;
using System.Windows.Media.Imaging;

// Based on code from
// http://stackoverflow.com/questions/1176910/finding-specific-pixel-colors-of-a-bitmapimage/1740553#1740553
// http://stackoverflow.com/users/199245/ray-burns

namespace HDD.ImageGenerator
{
   public static class BitmapSourceHelper
   {
#if UNSAFE
      public static unsafe void CopyAllPixels(this BitmapSource source, byte[,] pixels, int stride, int offset)
      {
         fixed (byte* buffer = &pixels[0, 0])
         {
            source.CopyPixels(
               new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
               (IntPtr) (buffer + offset),
               pixels.GetLength(0) * pixels.GetLength(1) * sizeof(byte),
               stride);
         }
      }
#else
      public static void CopyAllPixels(this BitmapSource source, byte[,] pixels, int stride)
      {
         var height = source.PixelHeight;
         var width = source.PixelWidth;
         var pixelBytes = new byte[height * width];
         source.CopyPixels(pixelBytes, stride, 0);
         for (var y = 0; y < height; y++)
         {
            for (var x = 0; x < width; x++)
            {
               pixels[x, y] = pixelBytes[y * width + x];
            }
         }
      }
#endif
   }
}