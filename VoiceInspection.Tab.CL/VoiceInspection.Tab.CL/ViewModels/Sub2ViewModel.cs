using Prism.Commands;
using Prism.Mvvm;
using System;
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
			if (WindowManager.GetInstance().SubWindow2.IsVisible)
			{
				WindowManager.GetInstance().SubWindow2.Close();
			}
		}
	}
}
