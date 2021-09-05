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
        public List<EmployeeViewModel> Employee { get; set; } = new List<EmployeeViewModel>();
        public List<Produkty> Product { get; set; } = new List<Produkty>();
        public List<TransactionViewModel> Transaction { get; set; } = new List<TransactionViewModel>();

        public static DataGridCustomer DataGridViewCustomer { get; set; } = new DataGridCustomer();
        public static DataGridEmployee DataGridViewEmployee { get; set; } = new DataGridEmployee();
        public static DataGridProduct DataGridViewProduct { get; set; } = new DataGridProduct();
        public static DataGridTransactions DataGridViewTransactions { get; set; } = new DataGridTransactions();

        public UserControl UserControl { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


        //public DataGrid1 CustomerDataGridView { get; set; } = new DataGrid1();

        public async Task ShowCustomers()
        {
            //await using var context = new BD1_2020Context();

            instance.UserControl = DataGridViewCustomer;
            await using (var context = new BD1_2020Context())
            {
                Customer = context.Klienci.ToList();
            }

        }
        public async Task ShowEmployee()
        {
            //await using var context = new BD1_2020Context();
            //Employee = context.Pracownicy.ToList();

            instance.UserControl = DataGridViewEmployee;
            await using (var context = new BD1_2020Context())
            {
                Employee = context.Pracownicy.Select(x => new EmployeeViewModel
                {
                    Idpracownika = x.Idpracownika,
                    Nazwisko = x.Nazwisko,
                    Imię = x.Imię,
                    Stanowisko = x.Stanowisko,
                    ZwrotGrzecznościowy = x.ZwrotGrzecznościowy,
                    DataUrodzenia = x.DataUrodzenia,
                    DataZatrudnienia = x.DataZatrudnienia,
                    Adres = x.Adres,
                    Miasto = x.Miasto,
                    Region = x.Region,
                    KodPocztowy = x.KodPocztowy,
                    TelefonDomowy = x.TelefonDomowy,
                    TelefonWewnętrzny = x.TelefonWewnętrzny,
                    Uwagi = x.Uwagi,
                    Szef = x.Szef
                }).ToList();
            }
        }

        public async Task ShowProduct()
        {
            instance.UserControl = DataGridViewProduct;
            await using (var context = new BD1_2020Context())
            {
                Product = context.Produkty.ToList();
            }
        }

        public async Task ShowTransactions()
        {
            instance.UserControl = DataGridViewTransactions;
            //ProductViewModel productViewModel = new ProductViewModel();
            await using (var context = new BD1_2020Context())
            {
                Transaction = context.Zamówienia.Join(context.Klienci,
                    z => z.Idklienta,
                    k => k.Idklienta,
                    (z, k) => new
                    {
                        Idzamówienia = z.Idzamówienia,
                        NazwaFirmy = k.NazwaFirmy,
                        Pracownik = z.Idpracownika,
                        DataZamówienia = z.DataZamówienia,
                        DataWysyłki = z.DataWysyłki,
                        NazwaOdbiorcy = z.NazwaOdbiorcy,
                        AdresOdbiorcy = z.AdresOdbiorcy,
                        MiastoOdbiorcy = z.MiastoOdbiorcy,
                        RegionOdbiorcy = z.RegionOdbiorcy,
                        KodPocztowyOdbiorcy = z.KodPocztowyOdbiorcy,
                        KrajOdbiorcy = z.KrajOdbiorcy,
                    }).Join(context.Pracownicy,
                    x=>x.Pracownik,
                    p=>p.Idpracownika,
                    (x,p)=> new TransactionViewModel
                    {
                        Idzamówienia = x.Idzamówienia,
                        NazwaFirmy = x.NazwaFirmy,
                        Pracownik = $"{p.Imię} {p.Nazwisko}",
                        DataZamówienia = x.DataZamówienia,
                        DataWysyłki = x.DataWysyłki,
                        NazwaOdbiorcy = x.NazwaOdbiorcy,
                        AdresOdbiorcy = x.AdresOdbiorcy,
                        MiastoOdbiorcy = x.MiastoOdbiorcy,
                        RegionOdbiorcy = x.RegionOdbiorcy,
                        KodPocztowyOdbiorcy = x.KodPocztowyOdbiorcy,
                        KrajOdbiorcy = x.KrajOdbiorcy
                    }).Take(100).ToList();
                    
            }
        }
    }
}
