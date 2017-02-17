using HDD.ImageGenerator;

namespace HDD.ImageProcessing
{
   public class ImageSmoothing
   {
      private readonly int _maxColumnIndex;
      private readonly int _maxRowIndex;
      private readonly byte[,] _pixels;

      public ImageSmoothing(byte[,] pixels)
      {
         _pixels = pixels;
         _maxColumnIndex = _pixels.GetUpperBound(0);
         _maxRowIndex = _pixels.GetUpperBound(1);
      }

      public byte[,] SmoothImage(GaussianFilter gaussianFilter)
      {
         var halfMaskWidth = gaussianFilter.Size / 2;

         var intermediatePixels = new double[_maxColumnIndex + 1, _maxRowIndex + 1];
         for (var y = 0; y <= _maxRowIndex; ++y)
         {
            for (var x = 0; x <= _maxColumnIndex; ++x)
            {
               for (var m = -halfMaskWidth; m <= halfMaskWidth; ++m)
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
                  intermediatePixels[x, y] += pixel * gaussianFilter.Filter[m + halfMaskWidth];
               }
            }
         }

         var smoothPixels = new double[_maxColumnIndex + 1, _maxRowIndex + 1];
         for (var x = 0; x <= _maxColumnIndex; ++x)
         {
            for (var y = 0; y <= _maxRowIndex; ++y)
            {
               for (var m = -halfMaskWidth; m <= halfMaskWidth; ++m)
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
                  smoothPixels[x, y] += pixel * gaussianFilter.Filter[m + halfMaskWidth];
               }
            }
         }

         var smoothBytePixels = new byte[_maxColumnIndex + 1, _maxRowIndex + 1];
         for (var x = 0; x <= _maxColumnIndex; ++x)
         {
            for (var y = 0; y <= _maxRowIndex; ++y)
            {
               smoothBytePixels[x, y] = (byte) smoothPixels[x, y];
            }
         }
         return smoothBytePixels;
      }
   }
}