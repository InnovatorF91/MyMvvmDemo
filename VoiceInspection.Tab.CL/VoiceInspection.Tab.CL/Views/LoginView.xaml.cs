using Prism.Regions;
using System.Windows.Controls;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// LoginView.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoginView(NavigationParameters parameters)
        {
            InitializeComponent();
            DataContext = new LoginViewModel(parameters);

            // パスワード欄に変更があったら呼び出されるイベント
            txbPasswordTextBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is LoginViewModel viewModel)
                {
                    viewModel.Password = txbPasswordTextBox.Password;
                }
            };
        }
    }
}
