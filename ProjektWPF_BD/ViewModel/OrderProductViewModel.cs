using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    public class OrderProductViewModel : INotifyPropertyChanged
    {

        public int Idproduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public string NazwaFirmy { get; set; }
        public string NazwaKategorii { get; set; }
        public string IlośćJednostkowa { get; set; }
        public decimal? CenaJednostkowa { get; set; }
        public short? StanMagazynu { get; set; }
        public float Rabat { get; set; }
        public short IlośćZamówienia { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
