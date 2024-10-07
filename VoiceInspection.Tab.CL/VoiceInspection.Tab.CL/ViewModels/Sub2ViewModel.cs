using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using VoiceInspection.Tab.CL.Models;

namespace VoiceInspection.Tab.CL.ViewModels
{
	public class Sub2ViewModel : BindableBase
	{
		public DelegateCommand<object> TojiruCommand { get; private set; }

		public Sub2ViewModel()
		{
			TojiruCommand = new DelegateCommand<object>(TapTojiruCommand);
		}

		private void TapTojiruCommand(object obj)
		{
			var windowManager = WindowManager.GetInstance();

			if (windowManager.SubWindow2 == null || !windowManager.SubWindow2.IsVisible)
			{
				CloseWindowIfVisible(windowManager.SubWindow);
			}
			
			CloseWindowIfVisible(windowManager.SubWindow2);
		}

		private void CloseWindowIfVisible(Window window)
		{
			if (window != null && window.IsVisible)
			{
				window.Close();
			}
		}
	}
}
