using HDD.ImageGenerator;
using HDD.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageGeneratorTests
{
   [TestClass]
   public class GaussianFilterTests
   {
      [TestMethod]
      public void GivenGaussianFilter_WhenCreatedWithDimension5_AndDeviation1_ThenFilterGeneratedWithinTolerance
         ()
      {
         // arrange
         var expectedFilter = new[] {0.06136, 0.24477, 0.38774, 0.24477, 0.06136};

         // act
         var filter = GaussianFilter.Generate(5, 1);

         // assert
         CollectionAssert.AreEqual(expectedFilter, filter, new DoubleComparer(1e-4));
      }

      [TestMethod]
      public void GivenGaussianFilter_WhenCreatedWithDimension5_AndDeviation2_ThenFilterGeneratedWithinTolerance
         ()
      {
         // arrange
         var expectedFilter = new[] {0.153388, 0.221461, 0.250301, 0.221461, 0.153388};

         // act
         var filter = GaussianFilter.Generate(5, 2);

         // assert
         CollectionAssert.AreEqual(expectedFilter, filter, new DoubleComparer(1e-4));
      }

      [TestMethod]
      public void GivenGaussianFilter_WhenCreatedWithDimension7_AndDeviation1_ThenFilterGeneratedWithinTolerance
         ()
      {
         // arrange
         var expectedFilter = new[] {0.00598, 0.060626, 0.241843, 0.383103, 0.241843, 0.060626, 0.00598};

         // act
         var filter = GaussianFilter.Generate(7, 1);

         // assert
         CollectionAssert.AreEqual(expectedFilter, filter, new DoubleComparer(1e-4));
      }

      [TestMethod]
      public void GivenGaussianFilter_WhenCreatedWithDimension7_AndDeviation2_ThenFilterGeneratedWithinTolerance
         ()
      {
         // arrange
         var expectedFilter = new[] {0.071303, 0.131514, 0.189879, 0.214607, 0.189879, 0.131514, 0.071303};

         // act
         var filter = GaussianFilter.Generate(7, 2);

         // assert
         CollectionAssert.AreEqual(expectedFilter, filter, new DoubleComparer(1e-4));
      }
   }
}