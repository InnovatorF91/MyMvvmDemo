using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Threading;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();

            WindowManager.GetInstance().MainWindow = this;
        }
    }
}
