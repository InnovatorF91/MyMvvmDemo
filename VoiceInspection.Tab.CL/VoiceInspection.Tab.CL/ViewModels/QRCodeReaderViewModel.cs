using AForge.Video;
using AForge.Video.DirectShow;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;
using ZXing;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// QRコード読み込みビューモデル
    /// </summary>
    public class QRCodeReaderViewModel : BindableBase , IDisposable
    {
        /// <summary>
        /// バーコード読み込み
        /// </summary>
        private readonly BarcodeReader barcodeReader;

        /// <summary>
        /// ビデオデバイス
        /// </summary>
        private FilterInfoCollection videoDevices;

        /// <summary>
        /// ビデオソース
        /// </summary>
        private VideoCaptureDevice videoSource;

        /// <summary>
        /// QRコードモデル
        /// </summary>
        private QRCodeModel codeModel = QRCodeModel.GetInstance();

        /// <summary>
        /// カメラの画像ソース
        /// </summary>
        private ImageSource cameraImageSource;

        /// <summary>
        /// カメラの画像ソース
        /// </summary>
        public ImageSource CameraImageSource
        {
            get { return cameraImageSource; }
            set { SetProperty(ref cameraImageSource, value); }
        }

        /// <summary>
        /// キャンセルタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> CancelCommand { get; private set; }

        /// <summary>
        /// 背景画面タップ処理コマンド
        /// </summary>
        public DelegateCommand<object> BackgroundClickCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QRCodeReaderViewModel()
        {
            CancelCommand = new DelegateCommand<object>(ExecuteCancelCommand);
            BackgroundClickCommand = new DelegateCommand<object>(ExecuteBackgroundClickCommand);

            barcodeReader = new BarcodeReader();

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += OnNewFrame;
                videoSource.Start();
            }
        }

        /// <summary>
        /// キャンセルタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteCancelCommand(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                Dispose();
                mainWindowViewModel.CurrentView = new ReceiptNumberEntryView(new Prism.Regions.NavigationParameters());
            }
        }

        /// <summary>
        /// 背景画面タップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteBackgroundClickCommand(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                Dispose();
                mainWindowViewModel.CurrentView = new ReceiptNumberEntryView(new Prism.Regions.NavigationParameters());
            }
        }

        /// <summary>
        /// 次のフレームに対する処理
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="eventArgs">eventArgs</param>
        private void OnNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (eventArgs.Frame == null)
                    return; // フレームがnullの場合は処理を行わない

                Bitmap bitmap = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, eventArgs.Frame.PixelFormat);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(eventArgs.Frame, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                }

                // UIスレッドで処理を実行する
                App.Current.Dispatcher.Invoke(() =>
                {
                    CameraImageSource = BitmapToImageSource(bitmap);

                    var result = barcodeReader.Decode(bitmap);
                    if (result != null)
                    {
                        codeModel.QRcode = result.Text;
                        videoSource.SignalToStop();

                        var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
                        if (mainWindowViewModel != null)
                        {
                            Dispose();
                            mainWindowViewModel.CurrentView = new ReceiptNumberEntryView(new Prism.Regions.NavigationParameters());
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                // 異常処理
                MessageBox.Show(ex.Message, "QRコード取得失敗", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// ビットマップから画像ソースに変更する処理
        /// </summary>
        /// <param name="bitmap">ビットマップ</param>
        /// <returns>変更した画像ソース</returns>
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        public void Dispose()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
        }
    }
}
