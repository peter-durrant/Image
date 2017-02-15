using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class ImageProcessingModel
   {
      public void FindCircles(byte[,] pixels)
      {
         var cht = new CircleHoughTransform(pixels);
      }
   }
}