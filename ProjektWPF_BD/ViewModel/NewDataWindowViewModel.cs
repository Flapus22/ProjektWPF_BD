using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjektWPF_BD.Model;
using ProjektWPF_BD.View.UserControls;
using ProjektWPF_BD.View.Windows;


namespace ProjektWPF_BD.ViewModel
{
    class NewDataWindowViewModel : INotifyPropertyChanged
    {
        //NewDataWindowView NewDataWindowView { get; set; }

        public UserControl UserControl { get; set; }

        //public static NewDataWindowViewModel instance { get; set; } = new NewDataWindowViewModel();

        public NewCustomerUserControlView NewCustomerUserControlView { get; set; }
        public NewEmployeeUserControlView NewEmployeeUserControlView { get; set; }
        public NewProductUserControlView NewProductUserControlView { get; set; }
        public NewTransactionUserControlView NewTransactionUserControlView { get; set; }

        public ProductViewModel ProductViewModel { get; set; }
        public EmployeeViewModel EmployeeViewModel { get; set; }
        public TransactionViewModel TransactionViewModel { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public List<DropDownBtnViewModel> DropDownList_Templates { get; set; }

        public DropDownBtnViewModel CreateNewData { get; set; }

        public NewDataWindowViewModel(NewDataWindowView newDataWindowView)
        {
            ProductViewModel = new ProductViewModel();
            EmployeeViewModel = new EmployeeViewModel();
            TransactionViewModel = new TransactionViewModel();
            CustomerViewModel = new CustomerViewModel();

            NewCustomerUserControlView = new NewCustomerUserControlView(CustomerViewModel);
            NewEmployeeUserControlView = new NewEmployeeUserControlView(EmployeeViewModel);
            NewProductUserControlView = new NewProductUserControlView(ProductViewModel);
            NewTransactionUserControlView = new NewTransactionUserControlView(TransactionViewModel);

            UserControl = NewTransactionUserControlView;//NewTransactionUserControlView;

            DropDownList_Templates = new List<DropDownBtnViewModel>
            {
            new DropDownBtnViewModel(NewEmployeeShow, "Pracownik"),
            new DropDownBtnViewModel(NewProductShow, "Produkt" ),
            new DropDownBtnViewModel(NewCustomerShow, "Klient"),
            new DropDownBtnViewModel(NewTransactionShow,"Transakcja")
            };
            DropDownList_Templates[3].Command.Execute(1);
            CreateNewData = new DropDownBtnViewModel(NewDataTransaction);
            //NewDataWindowView = newDataWindowView;
        }

        public async Task NewCustomerShow()
        {
            UserControl = NewCustomerUserControlView;
            CreateNewData = new DropDownBtnViewModel(NewDataCustomer);
        }
        public async Task NewEmployeeShow()
        {
            UserControl = NewEmployeeUserControlView;
            CreateNewData = new DropDownBtnViewModel(NewDataEmployee);

        }
        public async Task NewProductShow()
        {
            UserControl = NewProductUserControlView;
            CreateNewData = new DropDownBtnViewModel(NewDataProduct);

        }
        public async Task NewTransactionShow()
        {
            UserControl = NewTransactionUserControlView;
            CreateNewData = new DropDownBtnViewModel(NewDataTransaction);
            await using (var context = new BD1_2020Context())
            {
                TransactionViewModel.OrderProductViewModel = context.Produkty.Join(context.Dostawcy,
                    p => p.Iddostawcy,
                    d => d.Iddostawcy,
                    (p, d) => new
                    {
                        Idproduktu = p.Idproduktu,
                        NazwaProduktu = p.NazwaProduktu,
                        NazwaFirmy = d.NazwaFirmy,
                        Idkategorii = p.Idkategorii,
                        IlośćJednostkowa = p.IlośćJednostkowa,
                        CenaJednostkowa = p.CenaJednostkowa,
                        StanMagazynu = p.StanMagazynu,
                    })
                    .Join(context.Kategorie,
                    p => p.Idkategorii,
                    k => k.Idkategorii,
                    (p, k) => new OrderProductViewModel
                    {
                        Idproduktu = p.Idproduktu,
                        NazwaProduktu = p.NazwaProduktu,
                        NazwaFirmy = p.NazwaFirmy,
                        NazwaKategorii = k.NazwaKategorii,
                        IlośćJednostkowa = p.IlośćJednostkowa,
                        CenaJednostkowa = p.CenaJednostkowa,
                        StanMagazynu = p.StanMagazynu,
                        IlośćZamówienia = 0,
                        Rabat = 0
                    }).ToList();
            }
        }

        public async Task NewDataCustomer()
        {
            await using (var context = new BD1_2020Context())
            {
                var customer = new Klienci
                {
                    Idklienta = CustomerViewModel.Idklienta,
                    NazwaFirmy = CustomerViewModel.NazwaFirmy,
                    Przedstawiciel = CustomerViewModel.Przedstawiciel,
                    StanowiskoPrzedstawiciela = CustomerViewModel.StanowiskoPrzedstawiciela,
                    Adres = CustomerViewModel.Adres,
                    Miasto = CustomerViewModel.Miasto,
                    Region = CustomerViewModel.Region,
                    KodPocztowy = CustomerViewModel.KodPocztowy,
                    Kraj = CustomerViewModel.Kraj,
                    Telefon = CustomerViewModel.Telefon,
                    Faks = CustomerViewModel.Faks
                };
                context.Klienci.Add(customer);
                context.SaveChanges();
            }
        }
        public async Task NewDataEmployee()
        {

            await using (var context = new BD1_2020Context())
            {
                var employee = new Pracownicy
                {
                    Idpracownika = EmployeeViewModel.Idpracownika,
                    Nazwisko = EmployeeViewModel.Nazwisko,
                    Imię = EmployeeViewModel.Imię,
                    Stanowisko = EmployeeViewModel.Stanowisko,
                    ZwrotGrzecznościowy = EmployeeViewModel.ZwrotGrzecznościowy,
                    DataUrodzenia = EmployeeViewModel.DataUrodzenia,
                    DataZatrudnienia = EmployeeViewModel.DataZatrudnienia,
                    Adres = EmployeeViewModel.Adres,
                    Miasto = EmployeeViewModel.Miasto,
                    Region = EmployeeViewModel.Region,
                    KodPocztowy = EmployeeViewModel.KodPocztowy,
                    Kraj = EmployeeViewModel.Kraj,
                    TelefonDomowy = EmployeeViewModel.TelefonDomowy,
                    TelefonWewnętrzny = EmployeeViewModel.TelefonWewnętrzny,
                    Uwagi = EmployeeViewModel.Uwagi,
                    Szef = EmployeeViewModel.Szef
                };
                context.Pracownicy.Add(employee);
                context.SaveChanges();
            }
        }
        public async Task NewDataProduct()
        {
            try
            {
                await using (var context = new BD1_2020Context())
                {
                    var product = new Produkty()
                    {
                        Idproduktu = ProductViewModel.Idproduktu,
                        NazwaProduktu = ProductViewModel.NazwaProduktu,
                        Iddostawcy = ProductViewModel.NazwaFirmyPoID ? int.Parse(ProductViewModel.NazwaFirmy) : context.Dostawcy.Where(x => x.NazwaFirmy.Equals(ProductViewModel.NazwaFirmy)).Select(x => x.Iddostawcy).FirstOrDefault(),
                        Idkategorii = ProductViewModel.KategoriaPoID ? int.Parse(ProductViewModel.NazwaKategorii) : context.Kategorie.Where(x => x.NazwaKategorii.Equals(ProductViewModel.NazwaKategorii)).Select(x => x.Idkategorii).FirstOrDefault(),
                        IlośćJednostkowa = ProductViewModel.IlośćJednostkowa,
                        CenaJednostkowa = ProductViewModel.CenaJednostkowa,
                        StanMagazynu = ProductViewModel.StanMagazynu,
                        IlośćZamówiona = ProductViewModel.IlośćZamówiona,
                        StanMinimum = ProductViewModel.StanMinimum,
                        Wycofany = false,
                    };
                    var a = context.Kategorie.Select(x => x.Idkategorii);
                    context.Produkty.Add(product);
                    //context.Kategorie.Add();
                    context.SaveChanges();
                }
                //NewDataWindowView.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public async Task NewDataTransaction()
        {
            try
            {
                using (var context = new BD1_2020Context())
                {
                    var employeeIsNumber = int.TryParse(TransactionViewModel.Pracownik, out int employeeId);
                    var order = new Zamówienium
                    {
                        Idzamówienia = TransactionViewModel.Idzamówienia,
                        Idklienta = TransactionViewModel.NazwaFirmy,
                        Idpracownika = employeeIsNumber ? employeeId : context.Pracownicy.Where(x => x.Imię == TransactionViewModel.Pracownik).Select(x => x.Idpracownika).First(),
                        DataZamówienia = TransactionViewModel.DataZamówienia,
                        DataWymagana = TransactionViewModel.DataWymagana,
                        DataWysyłki = TransactionViewModel.DataWysyłki,
                        Idspedytora = TransactionViewModel.Idspedytora,
                        NazwaOdbiorcy = TransactionViewModel.NazwaOdbiorcy,
                        AdresOdbiorcy = TransactionViewModel.AdresOdbiorcy,
                        MiastoOdbiorcy = TransactionViewModel.MiastoOdbiorcy,
                        RegionOdbiorcy = TransactionViewModel.RegionOdbiorcy,
                        KodPocztowyOdbiorcy = TransactionViewModel.KodPocztowyOdbiorcy,
                        KrajOdbiorcy = TransactionViewModel.KrajOdbiorcy
                    };

                    if (TransactionViewModel.OrderProductViewModel.Any(x => x.IlośćZamówienia > x.StanMagazynu)) throw new Exception("Brak opowiedniej ilości towaru");

                    foreach (var item in TransactionViewModel.OrderProductViewModel)
                    {
                        if (item.IlośćZamówienia == 0) continue;

                        var orderItem = new PozycjeZamówienium
                        {
                            Idzamówienia = order.Idzamówienia,
                            Idproduktu = item.Idproduktu,
                            CenaJednostkowa = (decimal)item.CenaJednostkowa,
                            Ilość = item.IlośćZamówienia,
                            Rabat = item.Rabat
                        };
                        context.PozycjeZamówienia.Add(orderItem);
                    }
                    context.Zamówienia.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            //context.Klienci.Add(newCustomer);
            //context.Kategorie.Add();
        }
    }
}

