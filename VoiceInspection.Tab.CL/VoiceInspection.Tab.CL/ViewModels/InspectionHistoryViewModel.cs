using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// 点検履歴ビューモデル
    /// </summary>
    public class InspectionHistoryViewModel : BindableBase
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static InspectionHistoryViewModel instance;

        /// <summary>
        /// 選択した点検タイプ
        /// </summary>
        private string selectedType;

        /// <summary>
        /// 選択した開始日時
        /// </summary>
        private string selectedStartDate;

        /// <summary>
        /// 選択した終了日時
        /// </summary>
        private string selectedEndDate;

        /// <summary>
        /// 点検タイプ
        /// </summary>
        private ObservableCollection<string> inspectionType;

        /// <summary>
        /// 開始日時
        /// </summary>
        private ObservableCollection<string> startDate;

        /// <summary>
        /// 終了日時
        /// </summary>
        private ObservableCollection<string> endDate;

        /// <summary>
        /// 点検履歴モデル
        /// </summary>
        private InspectionHistoryModel inspectionHistoryModel = InspectionHistoryModel.GetInstance();

        /// <summary>
        /// 選択した点検タイプ
        /// </summary>
        public string SelectedType
        {
            get => selectedType;
            set => SetProperty(ref selectedType, value);
        }

        /// <summary>
        /// 選択した開始日時
        /// </summary>
        public string SelectedStartDate
        {
            get => selectedStartDate;
            set => SetProperty(ref selectedStartDate, value);
        }

        /// <summary>
        /// 選択した終了日時
        /// </summary>
        public string SelectedEndDate
        {
            get => selectedEndDate;
            set => SetProperty(ref selectedEndDate, value);
        }

        /// <summary>
        /// 点検タイプ
        /// </summary>
        public ObservableCollection<string> InspectionType
        {
            get => inspectionType;
            set => SetProperty(ref inspectionType, value);
        }

        /// <summary>
        /// 開始日時
        /// </summary>
        public ObservableCollection<string> StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        /// <summary>
        /// 終了日時
        /// </summary>
        public ObservableCollection<string> EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        /// <summary>
        /// 戻るタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> BackToTopCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InspectionHistoryViewModel()
        {
            BackToTopCommand = new DelegateCommand<object>(ExecuteBackToTopCommand);
            InitInspectionHistoryView();
        }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>点検履歴ビューモデルインスタンス</returns>
        public static InspectionHistoryViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new InspectionHistoryViewModel();
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
        /// 初期表示処理
        /// </summary>
        private void InitInspectionHistoryView()
        {
            if (inspectionHistoryModel.ShakenInspectionFlag)
            {
                InspectionType = new ObservableCollection<string>
                {
                    "車検",
                    "点検",
                };
            }
            else
            {
                InspectionType = new ObservableCollection<string>
                {
                    "点検",
                };
            }

            StartDate = new ObservableCollection<string>
            {
                inspectionHistoryModel.RegisteredDate.ToString(),
                inspectionHistoryModel.LastUpdateDate.ToString(),
            };

            EndDate = new ObservableCollection<string>
            {
                inspectionHistoryModel.LastUpdateDate.ToString(),
            };
        }
    }
}
