using System;
using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class CircleHoughTransform
   {
      private readonly int _maxColumnIndex;
      private readonly int _maxRowIndex;
      private readonly byte[,] _pixels;

      public CircleHoughTransform(byte[,] pixels)
      {
         _pixels = pixels;
         _maxColumnIndex = _pixels.GetUpperBound(0);
         _maxRowIndex = _pixels.GetUpperBound(1);

         SmoothImage(5, 1);
      }

      private void SmoothImage(int maskWidth, double deviation)
      {
         // TODO expected final smooth pixels to be in the same range as the input data (only if the maskWidth is >=9)
         var mask = GaussianFilter.Generate(maskWidth, deviation);
         var halfMaskWidth = maskWidth / 2;

         var intermediatePixels = new double[_maxColumnIndex + 1, _maxRowIndex + 1];
         for (var y = 0; y < _maxRowIndex; ++y)
         {
            for (var x = 0; x < _maxColumnIndex; ++x)
            {
               for (var m = -halfMaskWidth; m < halfMaskWidth; ++m)
               {
                  double pixel;
                  if (m + x < 0)
                  {
                     pixel = _pixels[0, y];
                  }
                  else if (m + x > _maxColumnIndex)
                  {
                     pixel = _pixels[_maxColumnIndex, y];
                  }
                  else
                  {
                     pixel = _pixels[m + x, y];
                  }
                  intermediatePixels[x, y] += pixel * mask[m + halfMaskWidth];
               }
            }
         }

         var smoothPixels = new double[_maxColumnIndex + 1, _maxRowIndex + 1];
         for (var x = 0; x < _maxColumnIndex; ++x)
         {
            for (var y = 0; y < _maxRowIndex; ++y)
            {
               for (var m = -halfMaskWidth; m < halfMaskWidth; ++m)
               {
                  double pixel;
                  if (m + y < 0)
                  {
                     pixel = intermediatePixels[x, 0];
                  }
                  else if (m + y > _maxRowIndex)
                  {
                     pixel = intermediatePixels[x, _maxRowIndex];
                  }
                  else
                  {
                     pixel = intermediatePixels[x, m + y];
                  }
                  smoothPixels[x, y] += pixel * mask[m + halfMaskWidth];
               }
            }
         }
      }
   }
}