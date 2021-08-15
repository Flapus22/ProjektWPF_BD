using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    class DropDownBtnListViewModel
    {
        public static List<DropDownBtnViewModel> DropDownList_Nowy { get; set; } = new List<DropDownBtnViewModel>
        {
            new DropDownBtnViewModel("Pracownik"),
            new DropDownBtnViewModel("Produkt"),
            new DropDownBtnViewModel("Klient"),
            new DropDownBtnViewModel("Transakcja")
        };
        public static List<DropDownBtnViewModel> dropDownList_Wyswietl { get; set; } = new List<DropDownBtnViewModel>
        {
            new DropDownBtnViewModel("Pracownik"),
            new DropDownBtnViewModel("Produkt"),
            new DropDownBtnViewModel("Klient"/*,DataGridViewModel.LoadCustomers*/),
            new DropDownBtnViewModel("Transakcja")
        };


    }
}
