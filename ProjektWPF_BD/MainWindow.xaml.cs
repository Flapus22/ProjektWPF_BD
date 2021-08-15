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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektWPF_BD.ViewModel;
using ProjektWPF_BD.View;



namespace ProjektWPF_BD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ContentControl ContentControl { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DropDownBtnNowy.DataContext = DropDownBtnListViewModel.DropDownList_Nowy;
            DropDownBtnWyswietl.DataContext = DropDownBtnListViewModel.dropDownList_Wyswietl;
            test.DataContext = ContentControl;
            ContentControl = new DataGrid1();
        }

    }
}
