using System.Windows.Media.Imaging;

// Based on code from
// http://stackoverflow.com/questions/1176910/finding-specific-pixel-colors-of-a-bitmapimage/1740553#1740553
// http://stackoverflow.com/users/199245/ray-burns

namespace HDD.ImageGenerator
{
   public static class BitmapSourceHelper
   {
#if UNSAFE
  public unsafe static void CopyAllPixels(this BitmapSource source, PixelColor[,] pixels, int stride, int offset)
  {
    fixed(PixelColor* buffer = &pixels[0, 0])
      source.CopyPixels(
        new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
        (IntPtr)(buffer + offset),
        pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
        stride);
  }
#else
      public static void CopyAllPixels(this BitmapSource source, PixelColor[,] pixels, int stride, int offset)
      {
         var height = source.PixelHeight;
         var width = source.PixelWidth;
         var pixelBytes = new byte[height * width * 4];
         source.CopyPixels(pixelBytes, stride, 0);
         var y0 = offset / width;
         var x0 = offset - width * y0;
         for (var y = 0; y < height; y++)
         {
            for (var x = 0; x < width; x++)
            {
               pixels[x + x0, y + y0] = new PixelColor
               {
                  Blue = pixelBytes[(y * width + x) * 4 + 0],
                  Green = pixelBytes[(y * width + x) * 4 + 1],
                  Red = pixelBytes[(y * width + x) * 4 + 2],
                  Alpha = pixelBytes[(y * width + x) * 4 + 3]
               };
            }
         }
      }
#endif
   }
}