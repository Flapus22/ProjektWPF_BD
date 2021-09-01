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
        NewDataWindowView NewDataWindowView { get; set; }

        public UserControl UserControl { get; set; }

        //public static NewDataWindowViewModel instance { get; set; } = new NewDataWindowViewModel();

        public NewCustomerUserControlView NewCustomerUserControlView { get; set; }
        public NewEmployeeUserControlView NewEmployeeUserControlView { get; set; }
        public NewProductUserControlView NewProductUserControlView { get; set; }
        public NewTransactionUserControlView NewTransactionUserControlView { get; set; }

        public ProductViewModel ProductViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<DropDownBtnViewModel> DropDownList_Templates { get; set; }

        public DropDownBtnViewModel CreateNewData { get; set; }  //Uwaga: Do zmiany Oczekiwany błąd: przy 2 oknach np 1 będzie tworzyło klienta 2 transakcje po kliknięciu przycisku w oknie z transakcją będzie próba stworzenia klienta


        public NewDataWindowViewModel(NewDataWindowView newDataWindowView)
        {
            ProductViewModel = new ProductViewModel();

            NewCustomerUserControlView = new NewCustomerUserControlView();
            NewEmployeeUserControlView = new NewEmployeeUserControlView();
            NewProductUserControlView = new NewProductUserControlView(ProductViewModel);
            NewTransactionUserControlView = new NewTransactionUserControlView();

            UserControl = NewProductUserControlView;//NewTransactionUserControlView;
            DropDownList_Templates = new List<DropDownBtnViewModel>
            {
            new DropDownBtnViewModel(NewEmployeeShow, "Pracownik"),
            new DropDownBtnViewModel(NewProductShow, "Produkt" ),
            new DropDownBtnViewModel(NewCustomerShow, "Klient"),
            new DropDownBtnViewModel(NewTransactionShow,"Transakcja")
            };
            CreateNewData = new DropDownBtnViewModel(NewDataProduct);
            NewDataWindowView = newDataWindowView;
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

        }

        public async Task NewDataCustomer()
        {
            using (var context = new BD1_2020Context())
            {

                //context.Klienci.Add(newCustomer);
                //context.Kategorie.Add();
                context.SaveChanges();
            }
        }
        public async Task NewDataEmployee()
        {
            using (var context = new BD1_2020Context())
            {

                //context.Klienci.Add(newCustomer);
                //context.Kategorie.Add();
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
                    var a = context.Kategorie.Select(x=>x.Idkategorii);
                    context.Produkty.Add(product);
                    //context.Kategorie.Add();
                    context.SaveChanges();
                }
                //NewDataWindowView.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public async Task NewDataTransaction()
        {
            using (var context = new BD1_2020Context())
            {

                //context.Klienci.Add(newCustomer);
                //context.Kategorie.Add();
                context.SaveChanges();
            }
        }
    }
}
