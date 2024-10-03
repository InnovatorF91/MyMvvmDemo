using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL
{
	/// <summary>
	/// SubWindow2View.xaml の相互作用ロジック
	/// </summary>
	public partial class SubWindow2View : Window
	{
		public SubWindow2View(object view)
		{
			InitializeComponent();
			DataContext = new SubWindow2ViewModel(view);

			WindowManager.GetInstance().SubWindow2 = this;
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			WindowManager.GetInstance().SubWindow.Opacity = 1.0;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			WindowManager.GetInstance().SubWindow.Opacity = 0.5;
		}
	}
}
