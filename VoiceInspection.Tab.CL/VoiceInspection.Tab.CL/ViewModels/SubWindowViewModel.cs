using Prism.Mvvm;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    public class SubWindowViewModel : BindableBase
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

        public SubWindowViewModel(object view)
        {
            if (view is TeModoriNyuryokuView || view is Sub2View)
            {
                CurrentView = view;
            }
        }
    }
}
