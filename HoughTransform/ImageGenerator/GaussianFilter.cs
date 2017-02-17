using System;

namespace HDD.ImageGenerator
{
   public class GaussianFilter
   {
      private static readonly double OneOverSquareRootTwoPi = 1.0 / Math.Sqrt(2.0 * Math.PI);

      /// <summary>
      ///    Generate 1D Gaussian convolution kernel for 2D Gaussian filter. Must be applied vertically and horizontally.
      /// </summary>
      /// <param name="size">Distance across the kernel, central point corresponds to max weight of target pixel, odd number.</param>
      /// <param name="deviation">Standard deviation of the distribution.</param>
      /// <returns>One dimensional array containing a Gaussian kernel.</returns>
      public GaussianFilter(int size, double deviation)
      {
         Size = size;
         Deviation = deviation;
         Filter = new double[size];
         var range = (int) Math.Floor(size / 2.0);

         double sum = 0;
         for (var i = -range; i <= range; ++i)
         {
            var y = IntegrateGaussian(i, 0.5, 100, deviation);
            Filter[i + range] = y;
            sum += y;
         }

         for (var i = 0; i < size; ++i)
         {
            Filter[i] /= sum;
         }
      }

      public int Size { get; private set; }

      public double Deviation { get; private set; }

      public double[] Filter { get; }

      private static double IntegrateGaussian(double center, double radius, int steps, double deviation)
      {
         var stepWidth = 2.0 * radius / steps;
         double? oldY = null;

         var sum = 0.0;
         for (var i = 0; i <= steps; ++i)
         {
            var x = center - radius + i * stepWidth;
            var y = Gaussian(x, deviation);
            if (oldY.HasValue)
            {
               var area = stepWidth * (oldY.Value + y) / 2.0;
               sum += area;
            }
            oldY = y;
         }
         return sum;
      }

      private static double Gaussian(double x, double deviation)
      {
         var oneOverDeviation = 1.0 / deviation;
         var minusXSquared = -x * x;
         var oneOverTwoDeviationSquared = 0.5 / (deviation * deviation);

         var result = oneOverDeviation * OneOverSquareRootTwoPi * Math.Exp(minusXSquared * oneOverTwoDeviationSquared);
         return result;
      }
   }
}