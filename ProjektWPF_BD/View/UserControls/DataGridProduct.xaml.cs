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
using ProjektWPF_BD.Model;


namespace ProjektWPF_BD.View
{
    /// <summary>
    /// Logika interakcji dla klasy DataGrid.xaml
    /// </summary>
    public partial class DataGridProduct : UserControl
    {
        public DataGridProduct()
        {
            InitializeComponent();
            DataGridViewModel.instance.LoadCustomers();

            Data.DataContext = DataGridViewModel.instance;
        }

    }
}
