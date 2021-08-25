using MahApps.Metro.Controls;
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
using ProjektWPF_BD.ViewModel;

namespace ProjektWPF_BD.View.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy NewDataWindowView.xaml
    /// </summary>
    public partial class NewDataWindowView : MetroWindow
    {
        public NewDataWindowView()
        {
            InitializeComponent();
            DropDownBtnTemplate.DataContext = DropDownBtnListViewModel.DropDownList_Templates;
            contentControl.DataContext = NewDataWindowViewModel.instance;
        }
    }
}
