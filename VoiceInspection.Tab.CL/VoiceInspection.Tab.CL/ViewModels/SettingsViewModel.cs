using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// 設定ビューモデル
    /// </summary>
    public class SettingsViewModel : BindableBase
    {
        /// <summary>
        /// スライダーの値
        /// </summary>
        private double sliderValue;

        /// <summary>
        /// チェックフラグ
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// 設定ビューモデルインスタンス
        /// </summary>
        private static SettingsViewModel instance;

        /// <summary>
        /// スライダーの値
        /// </summary>
        public double SliderValue
        {
            get => sliderValue;
            set => SetProperty(ref sliderValue, value);
        }

        /// <summary>
        /// チェックフラグ
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;
            set => SetProperty(ref isChecked, value);
        }

        /// <summary>
        /// 戻るタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> BackToTopCommand { get; private set; }

        /// <summary>
        /// 音声再生タップ処理コマンド
        /// </summary>
        public DelegateCommand<object> VoicePlayBackCommand { get; private set; }

        /// <summary>
        /// デフォルトタイヤシーズンタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> DefaultTireSeasonCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingsViewModel()
        {
            BackToTopCommand = new DelegateCommand<object>(ExecuteBackToTopCommand);
            VoicePlayBackCommand = new DelegateCommand<object>(ExecuteVoicePlayBackCommand);
            DefaultTireSeasonCommand = new DelegateCommand<object>(ExecuteDefaultTireSeasonCommand);
            SliderValue = 30;
            IsChecked = false;
        }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>設定ビューモデルインスタンス</returns>
        public static SettingsViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new SettingsViewModel();
            }

            return instance;
        }

        /// <summary>
        /// 戻るタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteBackToTopCommand(object parameter)
        {
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new TopView();
            }
        }

        /// <summary>
        /// 音声再生タップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteVoicePlayBackCommand(object parameter)
        {
            // 音声再生速度の値を読みこんで、
            // テスト用音声を再生する。
        }

        /// <summary>
        /// デフォルトタイヤシーズンタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteDefaultTireSeasonCommand(object parameter)
        {
            // 夏：False / 冬：True
            var tireSeason = SettingsModel.GetInstance();
            if (IsChecked)
            {
                tireSeason.TireSeason = "冬";
            }
            else
            {
                tireSeason.TireSeason = "夏";
            }
        }
    }
}
