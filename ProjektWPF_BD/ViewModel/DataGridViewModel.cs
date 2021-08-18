using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektWPF_BD.Model;
using ProjektWPF_BD.Helper;
using ProjektWPF_BD.View;
using System.Windows.Controls;

namespace ProjektWPF_BD.ViewModel
{
    class DataGridViewModel : INotifyPropertyChanged
    {

        public static DataGridViewModel instance { get; set; } = new DataGridViewModel();

        public List<Klienci> Customer { get; set; } = new List<Klienci>();
        public List<Pracownicy> Employee { get; set; } = new List<Pracownicy>();
        public List<Produkty> Product { get; set; } = new List<Produkty>();
        public List<Zamówienium> Transaction { get; set; } = new List<Zamówienium>();

        public static DataGridCustomer DataGridViewCustomer { get; set; } = new DataGridCustomer();
        public static DataGridEmployee DataGridViewEmployee { get; set; } = new DataGridEmployee();
        public static DataGridProduct DataGridViewProduct { get; set; } = new DataGridProduct();
        public static DataGridTransactions DataGridViewTransactions { get; set; } = new DataGridTransactions();

        public UserControl UserControl { get; set; } = DataGridViewCustomer;


        public event PropertyChangedEventHandler PropertyChanged;


        //public DataGrid1 CustomerDataGridView { get; set; } = new DataGrid1();

        public void LoadCustomers()
        {

        }

        public async void ShowCustomers()
        {
            await using var context = new BD1_2020Context();

            Customer = context.Klienci.ToList();

            instance.UserControl = DataGridViewCustomer;

        }
        public async void ShowEmployee()
        {
            await using var context = new BD1_2020Context();

            Employee = context.Pracownicy.ToList();

            UserControl = DataGridViewEmployee;
        }
        public void ShowProduct()
        {
            UserControl = DataGridViewProduct;

        }
        public void ShowTransactions()
        {
            UserControl = DataGridViewTransactions;
            ProductViewModel productViewModel = new ProductViewModel();

        }


    }
}
