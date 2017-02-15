using System.Windows.Media;
using System.Windows.Media.Imaging;

// Based on code from
// http://stackoverflow.com/questions/1176910/finding-specific-pixel-colors-of-a-bitmapimage/1740553#1740553
// http://stackoverflow.com/users/199245/ray-burns

namespace HDD.ImageGenerator
{
   public static class BitmapRendererAdapter
   {
      public static byte[,] Gray8Pixels(BitmapSource source)
      {
         if (source.Format != PixelFormats.Gray8)
         {
            source = new FormatConvertedBitmap(source, PixelFormats.Gray8, null, 0);
         }

         var width = source.PixelWidth;
         var height = source.PixelHeight;
         var result = new byte[width, height];

         source.CopyAllPixels(result, width);
         return result;
      }
   }
}