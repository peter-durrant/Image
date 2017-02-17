using HDD.ImageGenerator;
using HDD.ImageProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageGeneratorTests
{
   [TestClass]
   public class ImageSmoothingTests
   {
      private const int Columns = 10;
      private const int Rows = 20;
      private byte[,] _pixels;

      [TestInitialize]
      public void Init()
      {
         _pixels = new byte[Columns, Rows];
      }

      [TestMethod]
      public void GivenAnInitialisedTest_ThenEnsureDimensionsAreNotEqualToZero()
      {
         // assert
         Assert.AreEqual(200, Rows * Columns);
      }

      [TestMethod]
      public void GivenAnImageWithUniformPixels_WhenSmoothed_ThenAllValuesAreEqual_AndUnchanged()
      {
         // arrange
         const byte expectedPixelValue = 10;
         AssignPixels(expectedPixelValue);
         var imageSmoothing = new ImageSmoothing(_pixels);
         var gaussianFilter = new GaussianFilter(5, 1);

         // act
         var smoothedPixels = imageSmoothing.SmoothImage(gaussianFilter);

         // assert
         var count = 0;
         for (var y = 0; y < Rows; ++y)
         {
            for (var x = 0; x < Columns; ++x)
            {
               Assert.AreEqual(expectedPixelValue, smoothedPixels[x, y]);
               ++count;
            }
         }
         Assert.AreEqual(Rows * Columns, count);
      }

      private void AssignPixels(byte value)
      {
         for (var y = 0; y < Rows; ++y)
         {
            for (var x = 0; x < Columns; ++x)
            {
               _pixels[x, y] = value;
            }
         }
      }
   }
}