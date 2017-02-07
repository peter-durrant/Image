using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace HDD.ImageGenerator
{
   internal static class CircleGenerator
   {
      internal static void Generate(IBitmapRenderer bitmapRenderer, int pixelWidth, int pixelHeight, int numCircles,
         int radiusMin, int radiusMax)
      {
         var geometries = new List<Geometry>();
         var rng = new Random();
         for (var i = 0; i < numCircles; i++)
         {
            double radius = rng.Next(radiusMin, radiusMax);
            var center = new Point(rng.Next(pixelWidth), rng.Next(pixelHeight));
            geometries.Add(new EllipseGeometry(center, radius, radius));
         }

         bitmapRenderer.Render(geometries, Brushes.Red);
      }
   }
}