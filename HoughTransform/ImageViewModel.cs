using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hdd.Logger;
using Hdd.Presentation.Core;
using HDD.ImageGenerator;
using HDD.ImageProcessing;

namespace HDD.HoughTransform
{
   public class ImageViewModel : ViewModelBase
   {
      private readonly ImageGeneratorModel _imageGeneratorModel;
      private readonly ILogger _logger;
      private ICommand _clearImageCommand;
      private ICommand _createCirclesCommand;
      private ICommand _findCirclesCommand;
      private ICommand _saveImageCommand;

      public ImageViewModel()
      {
         _logger = new Logger();
         _imageGeneratorModel = new ImageGeneratorModel(1000, 1000);
      }

      public RenderTargetBitmap Bitmap => _imageGeneratorModel.Bitmap;

      public ICommand CreateCirclesCommand
      {
         get
         {
            return
               _createCirclesCommand =
                  _createCirclesCommand ?? new RelayCommand(x =>
                  {
                     _logger.Info(this, "Create circles");
                     _imageGeneratorModel.CreateCircles(5, 20, 100);
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
                  _imageGeneratorModel.Save("circles.png");
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
                  _imageGeneratorModel.Clear();
               });
         }
      }

      public ICommand FindCirclesCommand
      {
         get
         {
            return _findCirclesCommand =
               _findCirclesCommand ?? new RelayCommand(x =>
               {
                  _logger.Info(this, "Find circles");
                  var imageProcessingModel = new ImageProcessingModel();
                  imageProcessingModel.FindCircles(_imageGeneratorModel.Gray8Pixels);
               });
         }
      }
   }
}