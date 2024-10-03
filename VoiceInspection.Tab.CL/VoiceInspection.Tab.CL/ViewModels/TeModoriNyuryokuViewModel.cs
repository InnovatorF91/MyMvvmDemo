using Common.Utility;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using VehicleInspection.CM.InputModel;
using VoiceInspection.Tab.CL.Models;
using VoiceInspection.Tab.CL.Models.Repositories;
using VoiceInspection.Tab.CL.Views;

namespace VoiceInspection.Tab.CL.ViewModels
{
    public class TeModoriNyuryokuViewModel : BindableBase
    {
        public DelegateCommand<object> CancelCommand { get; private set; }

        public DelegateCommand<object> HozonCommand { get; private set; }

        public DelegateCommand<object> TestCommand { get; private set; }

        private int count = 0;

        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;
        private string text7;
        private string text8;
        private string text9;
        private string text10;
        private string text11;
        private string text12;
        private string text13;
        private string text14;
        private string text15;
        private string text16;
        private string text17;
        private string text18;
        private string text19;
        private string text20;

        public string Text1
        {
            get => text1;
            set => SetProperty(ref text1, value);
        }

        public string Text2
        {
            get => text2;
            set => SetProperty(ref text2, value);
        }

        public string Text3
        {
            get => text3;
            set => SetProperty(ref text3, value);
        }

        public string Text4
        {
            get => text4;
            set => SetProperty(ref text4, value);
        }

        public string Text5
        {
            get => text5;
            set => SetProperty(ref text5, value);
        }

        public string Text6
        {
            get => text6;
            set => SetProperty(ref text6, value);
        }

        public string Text7
        {
            get => text7;
            set => SetProperty(ref text7, value);
        }

        public string Text8
        {
            get => text8;
            set => SetProperty(ref text8, value);
        }

        public string Text9
        {
            get => text9;
            set => SetProperty(ref text9, value);
        }

        public string Text10
        {
            get => text10;
            set => SetProperty(ref text10, value);
        }

        public string Text11
        {
            get => text11;
            set => SetProperty(ref text11, value);
        }

        public string Text12
        {
            get => text12;
            set => SetProperty(ref text12, value);
        }

        public string Text13
        {
            get => text13;
            set => SetProperty(ref text13, value);
        }

        public string Text14
        {
            get => text14;
            set => SetProperty(ref text14, value);
        }

        public string Text15
        {
            get => text15;
            set => SetProperty(ref text15, value);
        }

        public string Text16
        {
            get => text16;
            set => SetProperty(ref text16, value);
        }

        public string Text17
        {
            get => text17;
            set => SetProperty(ref text17, value);
        }

        public string Text18
        {
            get => text18;
            set => SetProperty(ref text18, value);
        }

        public string Text19
        {
            get => text19;
            set => SetProperty(ref text19, value);
        }

        public string Text20
        {
            get => text20;
            set => SetProperty(ref text20, value);
        }

        public TeModoriNyuryokuViewModel()
        {
            CancelCommand = new DelegateCommand<object>(TapCancelCommand);
            HozonCommand = new DelegateCommand<object>(TapHonzonCommand);
            TestCommand = new DelegateCommand<object>(TapTestCommand);
        }

		private void TapTestCommand(object obj)
		{
            var sub2View = new Sub2View();
            var subWindow2View = new SubWindow2View(sub2View);
            subWindow2View.ShowDialog();
        }

		private void TapHonzonCommand(object obj)
        {
            var teModoriNyuryokuRepository = new TeModoriRiyuNyuryokuRipository(new HttpUtility());

            var teModoriRiyuNyuryokuInputModel = new TeModoriRiyuNyuryokuInputModel();

            teModoriRiyuNyuryokuInputModel.TemodoriRiyuNyuryokuHozonModelList = new List<TemodoriRiyuNyuryokuHozonModel>();

            var loginModel = LoginModel.GetInstance();
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text1);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text2);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text3);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text4);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text5);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text6);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text7);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text8);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text9);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text10);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text11);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text12);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text13);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text14);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text15);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text16);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text17);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text18);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text19);
            MakeHozonModel(teModoriRiyuNyuryokuInputModel,loginModel, Text20);

            var result = teModoriNyuryokuRepository.InsertTemodoriRiyu(teModoriRiyuNyuryokuInputModel);

            if (result.StatusCode != Common.Constant.UtilityEnum.StatusCode.Success)
            {
                MessageBox.Show("手戻り理由入力が失敗しました。", "手戻り理由入力失敗", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (WindowManager.GetInstance().SubWindow.IsVisible)
            {
                WindowManager.GetInstance().SubWindow.Close();
            }
        }

        private void MakeHozonModel(TeModoriRiyuNyuryokuInputModel teModoriRiyuNyuryokuInputModel, LoginModel loginModel, string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            count++;

            var temodoriRiyuNyuryokuHozonModel = new TemodoriRiyuNyuryokuHozonModel();

            temodoriRiyuNyuryokuHozonModel.TenkenId = 1;
            temodoriRiyuNyuryokuHozonModel.TeModoriRiyuBango = count;
            temodoriRiyuNyuryokuHozonModel.TeModoriRiyu = text;
            temodoriRiyuNyuryokuHozonModel.TorokuId = loginModel.UserId;
            temodoriRiyuNyuryokuHozonModel.TodokuNichiji = loginModel.LoginDateTime;

            teModoriRiyuNyuryokuInputModel.TemodoriRiyuNyuryokuHozonModelList.Add(temodoriRiyuNyuryokuHozonModel);
        }

        private void TapCancelCommand(object obj)
        {
            if (WindowManager.GetInstance().SubWindow.IsVisible)
            {
                WindowManager.GetInstance().SubWindow.Close();
            } 
        }
    }
}
