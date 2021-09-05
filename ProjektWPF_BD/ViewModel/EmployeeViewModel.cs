using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public int Idpracownika { get; set; }
        public string Nazwisko { get; set; }
        public string Imię { get; set; }
        public string Stanowisko { get; set; }
        public string ZwrotGrzecznościowy { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public DateTime? DataZatrudnienia { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Region { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public string TelefonDomowy { get; set; }
        public string TelefonWewnętrzny { get; set; }
        public string Uwagi { get; set; }
        public int? Szef { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
