using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// QRReaderView.xaml の相互作用ロジック
    /// </summary>
    public partial class QRCodeReaderView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QRCodeReaderView()
        {
            InitializeComponent();
            DataContext = new QRCodeReaderViewModel();
        }
    }
}
