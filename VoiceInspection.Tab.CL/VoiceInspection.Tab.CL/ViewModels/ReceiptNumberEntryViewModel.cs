using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Navigation;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    /// <summary>
    /// 受付番号入力ビューモデル
    /// </summary>
    public class ReceiptNumberEntryViewModel : BindableBase
    {
        /// <summary>
        /// QRコードモデル
        /// </summary>
        private QRCodeModel codeModel = QRCodeModel.GetInstance();

        /// <summary>
        /// 入力した受付番号
        /// </summary>
        private string receiptNo;
        
        private bool buttonJotai;

        private bool teModoriNyuryokuSeigyo;

        private ReceiptNumberEntryView View { get; set; }

        private NavigationParameters Para { get; set; }

        /// <summary>
        /// 入力した受付番号
        /// </summary>
        public string ReceiptNo
        {
            get => receiptNo;
            set => SetProperty(ref receiptNo, value);
        }

        public bool ButtonJotai
        {
            get => buttonJotai;
            set => SetProperty(ref buttonJotai, value);
        }

        public bool TeModoriNyuryokuSeigyo
        {
            get => teModoriNyuryokuSeigyo;
            set => SetProperty(ref teModoriNyuryokuSeigyo, value);
        }

        /// <summary>
        /// QRボタンタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> QRCommand { get; private set; }

        /// <summary>
        /// 戻るタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> BackToTopCommand { get; private set; }

        /// <summary>
        /// 次へタップ処理コマンド
        /// </summary>
        public DelegateCommand<object> NextViewCommand { get; private set; }

        public DelegateCommand<object> TeModoriNyuryokuCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReceiptNumberEntryViewModel(NavigationParameters parameter)
        {
            Para = parameter;

            var value = Para.GetValue<ReceiptNumberEntryView>("view");

            View = value;

            Initlize();  
        }

        private void Initlize()
        {
            ButtonJotai = false;

            QRCommand = new DelegateCommand<object>(ExecuteQRCommand);
            BackToTopCommand = new DelegateCommand<object>(ExecuteBackToTopCommand);
            NextViewCommand = new DelegateCommand<object>(ExecuteNextViewCommand);

            TeModoriNyuryokuCommand = new DelegateCommand<object>(TapTeModoriNyuryokuCommand);

            View.txbReceiptNo.TextChanged += TxbReceiptNo_TextChanged;

            if (!string.IsNullOrEmpty(codeModel.QRcode))
            {
                ReceiptNo = codeModel.QRcode;
            }

            if (!string.IsNullOrEmpty(ReceiptNo))
            {
                ButtonJotai = true;
            }

            TeModoriNyuryokuSeigyo = true;
        }

        private void TapTeModoriNyuryokuCommand(object parameter)
        {
            var teModoriNyuryokuView = new TeModoriNyuryokuView();
            var subWindowView = new SubWindowView(teModoriNyuryokuView);
            subWindowView.ShowDialog();
        }

        private void TxbReceiptNo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            if (ButtonJotai == false)
            {
                ButtonJotai = true;

                return;
            }

            if (string.IsNullOrEmpty(View.txbReceiptNo.Text))
            {
                if (ButtonJotai == true)
                {
                    ButtonJotai = false;
                }
            }
        }

        /// <summary>
        /// QRボタンタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteQRCommand(object parameter)
        {
            // QRコード読み込み画面へ遷移
            var mainWindowViewModel = Application.Current.MainWindow.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.CurrentView = new QRCodeReaderView();
            }
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
                codeModel.Dispose();

                mainWindowViewModel.CurrentView = new TopView();
            }
        }

        /// <summary>
        /// 次へタップ処理
        /// </summary>
        /// <param name="parameter">parameter</param>
        private void ExecuteNextViewCommand(object parameter)
        {
            var inspectInfo = InspectInfoModel.GetInstance();

            if (inspectInfo.InspectType == null ||
                inspectInfo.ReceiptNo != ReceiptNo)
            {
                // 点検種別選択ダイアログを呼び出す。
            }
            else if (inspectInfo.InspectType == 1)
            {
                // 車検情報リポジトリを呼び出し、点検情報をDBから取得する
                // 車検情報登録画面へ遷移
            }
            else if (inspectInfo.InspectType == 2)
            {
                // 点検情報リポジトリを呼び出し、点検情報をDBから取得する
                // 点検情報登録画面へ遷移
            }
        }
    }
}
