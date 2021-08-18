using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektWPF_BD.Helper
{
    class RelayCommand : ICommand
    {
        private Action Action;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object parameter)
        {
            if (Action != null)return true;
            return false;
        }
        public void Execute(object parameter)
        {
            Action.Invoke();
        }
    }
}
