using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// Based on code from
// http://stackoverflow.com/questions/1176910/finding-specific-pixel-colors-of-a-bitmapimage/1740553#1740553
// http://stackoverflow.com/users/199245/ray-burns

namespace HDD.ImageGenerator
{
   [StructLayout(LayoutKind.Sequential)]
   public struct PixelColor
   {
      public byte Blue;
      public byte Green;
      public byte Red;
      public byte Alpha;
   }

   public static class BitmapRendererAdapter
   {
      public static PixelColor[,] Pixels(BitmapSource source)
      {
         if (source.Format != PixelFormats.Bgra32)
         {
            source = new FormatConvertedBitmap(source, PixelFormats.Bgra32, null, 0);
         }

         var width = source.PixelWidth;
         var height = source.PixelHeight;
         var result = new PixelColor[width, height];

         source.CopyAllPixels(result, width * 4, 0);
         return result;
      }
   }
}