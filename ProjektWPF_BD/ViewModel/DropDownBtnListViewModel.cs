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
            new DropDownBtnViewModel(title: "Pracownik"),
            new DropDownBtnViewModel(title: "Produkt"),
            new DropDownBtnViewModel(title: "Klient"),
            new DropDownBtnViewModel(title: "Transakcja")
        };
        public static List<DropDownBtnViewModel> DropDownList_Show { get; set; } = new List<DropDownBtnViewModel>
        {
            new DropDownBtnViewModel(DataGridViewModel.instance.ShowEmployee, "Pracownik"),
            new DropDownBtnViewModel(DataGridViewModel.instance.ShowProduct, "Produkt"),
            new DropDownBtnViewModel(DataGridViewModel.instance.ShowCustomers, "Klient"),
            new DropDownBtnViewModel(DataGridViewModel.instance.ShowTransactions, "Transakcja")
        };
        


    }
}
