using Prism.Mvvm;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
	public class SubWindow2ViewModel : BindableBase
	{
		private double height;
		private double width;

		public double Height
		{
			get => height;
			set => SetProperty(ref height, value);
		}

		public double Width
		{
			get => width;
			set => SetProperty(ref width, value);
		}

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

        public SubWindow2ViewModel(object view)
        {
			Height = 350;
			Width = 600;

			if (view is Sub2View)
			{
                CurrentView = view;
			}
        }
    }
}
