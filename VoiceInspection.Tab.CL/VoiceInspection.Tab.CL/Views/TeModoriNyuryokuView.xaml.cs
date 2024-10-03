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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VoiceInspection.Tab.CL.ViewModels;

namespace VoiceInspection.Tab.CL.Views
{
    /// <summary>
    /// TeModoriNyuryokuView.xaml の相互作用ロジック
    /// </summary>
    public partial class TeModoriNyuryokuView : UserControl
    {
        public TeModoriNyuryokuView()
        {
            InitializeComponent();
            DataContext = new TeModoriNyuryokuViewModel();
        }
    }
}
