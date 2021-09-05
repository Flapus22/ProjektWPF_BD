using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        public int Idzamówienia { get; set; }
        public string NazwaFirmy { get; set; }
        public string Pracownik { get; set; }
        public DateTime? DataZamówienia { get; set; }
        public DateTime? DataWymagana { get; set; }
        public DateTime? DataWysyłki { get; set; }
        public int? Idspedytora { get; set; }
        //public double Suma { get; set; }
        public string NazwaOdbiorcy { get; set; }
        public string AdresOdbiorcy { get; set; }
        public string MiastoOdbiorcy { get; set; }
        public string RegionOdbiorcy { get; set; }
        public string KodPocztowyOdbiorcy { get; set; }
        public string KrajOdbiorcy { get; set; }

        public List<OrderProductViewModel> OrderProductViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TransactionViewModel()
        {
            OrderProductViewModel = new List<OrderProductViewModel>();
        }
    }
}
