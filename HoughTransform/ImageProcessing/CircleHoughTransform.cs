using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class CircleHoughTransform
   {
      public CircleHoughTransform(byte[,] pixels)
      {
         var gaussianFilter = new GaussianFilter(5, 1);
         var imageSmoothing = new ImageSmoothing(pixels);
         var smoothedPixels = imageSmoothing.SmoothImage(gaussianFilter);
      }
   }
}