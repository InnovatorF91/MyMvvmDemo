using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// SettingsView.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingsView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingsView()
        {
            InitializeComponent();
            DataContext = SettingsViewModel.GetInstance();
        }

        /// <summary>
        /// 音量の値をint型に変更するためイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void slVoiceSpeed_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.txbVoiceSpeed.Text = ((int)this.slVoiceSpeed.Value).ToString();
        }
    }
}
