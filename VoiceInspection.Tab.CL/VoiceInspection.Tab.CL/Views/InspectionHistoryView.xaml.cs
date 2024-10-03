using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// InspectionHistory.xaml の相互作用ロジック
    /// </summary>
    public partial class InspectionHistoryView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InspectionHistoryView()
        {
            InitializeComponent();
            DataContext = InspectionHistoryViewModel.GetInstance();
        }
    }
}
