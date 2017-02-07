using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HDD.ImageGenerator
{
   internal class BitmapRenderer : IBitmapRenderer
   {
      internal BitmapRenderer(int pixelWidth, int pixelHeight, int dpi)
      {
         Bitmap = new RenderTargetBitmap(pixelWidth, pixelHeight, dpi, dpi, PixelFormats.Pbgra32);
      }

      public void Render(IEnumerable<Geometry> geometries, Brush brush)
      {
         var visual = new DrawingVisual();
         using (var drawingContext = visual.RenderOpen())
         {
            foreach (var geometry in geometries)
            {
               drawingContext.DrawGeometry(brush, null, geometry);
            }
         }
         Bitmap.Render(visual);
      }

      public void Clear()
      {
         Bitmap.Clear();
      }

      public void Save(string filename)
      {
         var pngEncoder = new PngBitmapEncoder();
         pngEncoder.Frames.Add(BitmapFrame.Create(Bitmap));
         using (var file = new FileStream(filename, FileMode.Create))
         {
            pngEncoder.Save(file);
         }
      }

      public RenderTargetBitmap Bitmap { get; }
   }
}