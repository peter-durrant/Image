using System.Windows;
using Hdd.Logger;

namespace HDD.HoughTransform
{
   /// <summary>
   ///    Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private readonly ILogger _logger;

      public MainWindow()
      {
         _logger = new Logger();
         _logger.Info(this, "Starting application");

         InitializeComponent();
      }
   }
}