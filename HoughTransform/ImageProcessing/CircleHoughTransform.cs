using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class CircleHoughTransform
   {
      private readonly byte[,] _pixels;

      public CircleHoughTransform(byte[,] pixels)
      {
         _pixels = pixels;

         GaussianMask();
      }

      private void GaussianMask()
      {
         var mask = GaussianFilter.Generate(11, 8.0 / 3.0);
      }
   }
}