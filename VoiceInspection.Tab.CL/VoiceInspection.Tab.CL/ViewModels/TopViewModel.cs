using Common.Utility;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// トップビューモデル
    /// </summary>
    public class TopViewModel : BindableBase
    {
        /// <summary>
        /// ログアウトタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> LogoutCommand { get; private set; }

        /// <summary>
        /// 設定タップ処理コマンド
        /// </summary>
        public DelegateCommand<object> SettingsCommand { get; private set; }

        /// <summary>
        /// 点検履歴一覧タップ処理コマンド
        /// </summary>
        public DelegateCommand<object> ShowInspectionHistoryCommand { get; private set; }

        /// <summary>
        /// 点検開始タップ処理コマンド
        /// </summary>
        public DelegateCommand<object> InspectStart { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopViewModel()
        {
            LogoutCommand = new DelegateCommand<object>(ExecuteLogoutCommand);
            SettingsCommand = new DelegateCommand<object>(ExecuteSettingsCommand);
            ShowInspectionHistoryCommand = new DelegateCommand<object>(ExecuteShowInspectionHistoryCommand);
            InspectStart = new DelegateCommand<object>(ExecuteInspectStart);
        }

        /// <summary>
        /// ログアウトタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteLogoutCommand(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new LoginView(new NavigationParameters());
            }
        }

        /// <summary>
        /// 設定タップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteSettingsCommand(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new SettingsView();
            }
        }

        /// <summary>
        /// 点検履歴一覧タップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteShowInspectionHistoryCommand(object parameter)
        {
            var inspectionHistoryRepository = new InspectionHistoryRepository(new HttpUtility());

            var loginModel = LoginModel.GetInstance();

            if (!inspectionHistoryRepository.Authenticate(loginModel.CompanyId,loginModel.LoginDateTime))
            {
                MessageBox.Show("点検履歴情報が取得できません！", "画面表示失敗", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new InspectionHistoryView();
            }
        }

        /// <summary>
        /// 点検開始タップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteInspectStart(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new ReceiptNumberEntryView(new NavigationParameters());
            }
        }
    }
}
