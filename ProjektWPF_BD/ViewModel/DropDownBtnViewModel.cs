using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjektWPF_BD.Helper;

namespace ProjektWPF_BD.ViewModel
{
    class DropDownBtnViewModel 
    {
        public string Title { get; set; }

        public ICommand Command { get; set; }

        public DropDownBtnViewModel(Func<Task> command = null, string title = null)
        {
            Title = title;
            Command = new RelayCommand(command);
        }
        //public DropDownBtnViewModel(Action command = null, string title = null)
        //{
        //    Title = title;
        //    Command = new RelayCommand(command);
        //}
    }
}
