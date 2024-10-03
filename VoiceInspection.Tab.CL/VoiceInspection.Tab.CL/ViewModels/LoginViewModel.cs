using Common.Utility;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        /// <summary>
        /// ユーザ名
        /// </summary>
        private string userName;

        /// <summary>
        /// パスワード
        /// </summary>
        private string passWord;

        /// <summary>
        /// ユーザ名
        /// </summary>
        public string Username
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        /// <summary>
        /// パスワード
        /// </summary>
        public string Password
        {
            get => passWord;
            set => SetProperty(ref passWord, value);
        }

        /// <summary>
        /// ログインタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> LoginCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoginViewModel(NavigationParameters parameters)
        {
            LoginCommand = new DelegateCommand<object>(ExecuteLoginCommand);
        }

        /// <summary>
        /// ログインタップ処理
        /// </summary>
        /// <param name="paramater">paramater</param>
        private void ExecuteLoginCommand(object paramater)
        {
            var _userRepository = new LoginRepository(new HttpUtility());

            if (!_userRepository.Authenticate(Username, Password))
            {
                MessageBox.Show("ユーザー名またはパスワードが正しくありません！", "ログイン失敗", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // ログイン成功、トップ画面へ
            var mainViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentView = new TopView();
            }
        }
    }
}
