using System;
using System.Collections;
using System.Globalization;

namespace HDD.TestHelpers
{
   public class DoubleComparer : IComparer
   {
      private readonly double _tolerance;

      public DoubleComparer(double tolerance)
      {
         _tolerance = tolerance;
      }

      public int Compare(object x, object y)
      {
         var value1 = ((IConvertible) x).ToDouble(CultureInfo.InvariantCulture);
         var value2 = ((IConvertible) y).ToDouble(CultureInfo.InvariantCulture);

         if (Math.Abs(value1 - value2) < _tolerance)
         {
            return 0;
         }
         if (value1 < value2)
         {
            return -1;
         }
         return 1;
      }
   }
}