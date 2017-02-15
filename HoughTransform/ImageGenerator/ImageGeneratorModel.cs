using System.Windows.Media.Imaging;

namespace HDD.ImageGenerator
{
   public class ImageGeneratorModel
   {
      private readonly IBitmapRenderer _bitmapRenderer;
      private readonly int _pixelHeight;
      private readonly int _pixelWidth;

      public ImageGeneratorModel(int pixelWidth, int pixelHeight, int dpi = 96)
      {
         _pixelWidth = pixelWidth;
         _pixelHeight = pixelHeight;

         _bitmapRenderer = new BitmapRenderer(_pixelWidth, _pixelHeight, dpi);
      }

      public RenderTargetBitmap Bitmap => _bitmapRenderer.Bitmap;

      public byte[,] Gray8Pixels
      {
         get
         {
            var pixels = BitmapRendererAdapter.Gray8Pixels(_bitmapRenderer.Bitmap);
            return pixels;
         }
      }

      public void CreateCircles(int numCircles, int minRadius, int maxRadius)
      {
         CircleGenerator.Generate(_bitmapRenderer, _pixelWidth, _pixelHeight, numCircles, minRadius, maxRadius);
      }

      public void Clear()
      {
         _bitmapRenderer.Clear();
      }

      public void Save(string filename)
      {
         _bitmapRenderer.Save(filename);
      }
   }
}