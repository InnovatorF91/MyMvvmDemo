using Prism.Regions;
using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// RecipetNumberEntry.xaml の相互作用ロジック
    /// </summary>
    public partial class ReceiptNumberEntryView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReceiptNumberEntryView(NavigationParameters para)
        {
            InitializeComponent();

            para.Add("view", this);

            DataContext = new ReceiptNumberEntryViewModel(para);
        }
    }
}
