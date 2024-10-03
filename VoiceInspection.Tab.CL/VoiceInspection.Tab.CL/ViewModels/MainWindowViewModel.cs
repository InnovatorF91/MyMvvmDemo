using Prism.Mvvm;
using Prism.Regions;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// メインウィンドウビューモデル
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 現在実行しているビュー
        /// </summary>
        private object currentView;

        /// <summary>
        /// 現在実行しているビュー
        /// </summary>
        public object CurrentView
        {
            get => currentView;
            set => SetProperty(ref currentView, value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // 最初はログイン表示に設定
            CurrentView = new LoginView(new NavigationParameters());
        }
    }
}
