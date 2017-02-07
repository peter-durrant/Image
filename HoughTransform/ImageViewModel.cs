using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hdd.Logger;
using Hdd.Presentation.Core;
using HDD.ImageGenerator;

namespace HDD.HoughTransform
{
   public class ImageViewModel : ViewModelBase
   {
      private readonly ImageModel _imageModel;
      private readonly ILogger _logger;
      private ICommand _clearImageCommand;
      private ICommand _createCirclesCommand;
      private ICommand _saveImageCommand;

      public ImageViewModel()
      {
         _logger = new Logger();
         _imageModel = new ImageModel(1000, 1000);
      }

      public RenderTargetBitmap Bitmap => _imageModel.Bitmap;

      public ICommand CreateCirclesCommand
      {
         get
         {
            return
               _createCirclesCommand =
                  _createCirclesCommand ?? new RelayCommand(x =>
                  {
                     _logger.Info(this, "Create circles");
                     _imageModel.CreateCircles(5, 20, 100);
                  });
         }
      }

      public ICommand SaveImageCommand
      {
         get
         {
            return _saveImageCommand =
               _saveImageCommand ?? new RelayCommand(x =>
               {
                  _logger.Info(this, "Save image");
                  _imageModel.Save("circles.png");
               });
         }
      }

      public ICommand ClearImageCommand
      {
         get
         {
            return _clearImageCommand =
               _clearImageCommand ?? new RelayCommand(x =>
               {
                  _logger.Info(this, "Clear image");
                  _imageModel.Clear();
               });
         }
      }
   }
}