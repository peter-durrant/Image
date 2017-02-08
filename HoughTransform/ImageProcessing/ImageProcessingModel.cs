using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class ImageProcessingModel
   {
      public void FindCircles(PixelColor[,] pixels)
      {
         var cht = new CircleHoughTransform(pixels);
      }
   }
}