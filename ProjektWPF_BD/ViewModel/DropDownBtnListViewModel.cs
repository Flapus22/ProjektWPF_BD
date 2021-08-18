using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektWPF_BD.ViewModel
{
    class DropDownBtnListViewModel
    {
        public static List<DropDownBtnViewModel> DropDownList_New { get; set; } = new List<DropDownBtnViewModel>
        {
            new DropDownBtnViewModel("Pracownik"),
            new DropDownBtnViewModel("Produkt"),
            new DropDownBtnViewModel("Klient"),
            new DropDownBtnViewModel("Transakcja")
        };
        public static List<DropDownBtnViewModel> dropDownList_Show { get; set; } = new List<DropDownBtnViewModel>
        {
            new DropDownBtnViewModel("Pracownik", DataGridViewModel.instance.ShowEmployee),
            new DropDownBtnViewModel("Produkt", DataGridViewModel.instance.ShowProduct),
            new DropDownBtnViewModel("Klient", DataGridViewModel.instance.ShowCustomers),
            new DropDownBtnViewModel("Transakcja", DataGridViewModel.instance.ShowTransactions)
        };


    }
}
