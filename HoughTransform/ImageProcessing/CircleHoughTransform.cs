using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class CircleHoughTransform
   {
      private readonly PixelColor[,] _pixels;

      public CircleHoughTransform(PixelColor[,] pixels)
      {
         _pixels = pixels;
      }
   }
}