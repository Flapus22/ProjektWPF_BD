﻿using MahApps.Metro.Controls;
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
using ProjektWPF_BD.View.Windows;
using ProjektWPF_BD.Model;

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
            //DropDownBtnNowy.DataContext = DropDownBtnListViewModel.DropDownList_New;
            DropDownBtnWyswietl.DataContext = DropDownBtnListViewModel.DropDownList_Show;
            //test.DataContext = new DataGrid1();
            contentControl.DataContext = DataGridViewModel.instance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewDataWindowView();
            window.Show();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new BD1_2020Context())
            {

                var newCustomer = new Klienci()
                {
                    Idklienta = "aa",
                    NazwaFirmy = "Baczki",
                    Przedstawiciel = "aaa",
                    StanowiskoPrzedstawiciela = "aaa",
                    Adres = "aaa",
                    Miasto = "aaa",
                    Region = "aaa",
                    KodPocztowy = "aaa",
                    Kraj = "aaa",
                    Telefon = "aaa",
                    Faks = "aaa"
                };

                var a = new Produkty()
                {
                    NazwaProduktu = "aa",
                    Iddostawcy = 1,
                    Idkategorii = 1,
                    IlośćJednostkowa = "szt",
                    CenaJednostkowa = 1,
                    StanMagazynu = 1,
                    IlośćZamówiona = 1,
                    StanMinimum = 1,
                    Wycofany = true
                };
                var b = new Kategorie
                {
                    NazwaKategorii = "Kategoria",
                    Opis = "nic ważnego"
                };

                //context.Klienci.Add(newCustomer);
                //context.Kategorie.Add();
                context.SaveChanges();
            }

        }
    }
}
