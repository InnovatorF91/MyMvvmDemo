using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// TopView.xaml の相互作用ロジック
    /// </summary>
    public partial class TopView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopView()
        {
            InitializeComponent();
            DataContext = new TopViewModel();
        }
    }
}
