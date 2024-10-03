using System;
using System.Windows;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL
{
    /// <summary>
    /// SubWindowView.xaml の相互作用ロジック
    /// </summary>
    public partial class SubWindowView : Window
    {
        public SubWindowView(object view)
        {
            InitializeComponent();
            DataContext = new SubWindowViewModel(view);

            WindowManager.GetInstance().SubWindow = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowManager.GetInstance().MainWindow.Opacity = 0.5;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WindowManager.GetInstance().MainWindow.Opacity = 1.0;
        }
    }
}
