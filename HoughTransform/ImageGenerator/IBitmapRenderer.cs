using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HDD.ImageGenerator
{
   public interface IBitmapRenderer
   {
      /// <summary>
      ///    Pixel representation
      /// </summary>
      RenderTargetBitmap Bitmap { get; }

      /// <summary>
      ///    Render the list of geometries in the colour specified on to the bitmap
      /// </summary>
      /// <param name="geometries">List of geometries to render</param>
      /// <param name="brush">Colour to render the geometries</param>
      void Render(IEnumerable<Geometry> geometries, Brush brush);

      /// <summary>
      ///    Clear the bitmap back to the initial state
      /// </summary>
      void Clear();

      /// <summary>
      ///    Save the current bitmap rendering - overwrites if the file exists
      /// </summary>
      /// <param name="filename">The target filename</param>
      void Save(string filename);
   }
}