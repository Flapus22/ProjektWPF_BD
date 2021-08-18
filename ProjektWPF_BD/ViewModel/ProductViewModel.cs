using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    class ProductViewModel: INotifyPropertyChanged
    {
        public int Idproduktu { get; set; }
        public string NazwaProduktu { get; set; }

        public string IlośćJednostkowa { get; set; }
        public decimal? CenaJednostkowa { get; set; }
        public short? StanMagazynu { get; set; }
        public short? IlośćZamówiona { get; set; }
        public short? StanMinimum { get; set; }
        public bool Wycofany { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
