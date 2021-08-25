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
        public event EventHandler CanExecuteChanged;

        //Func<Task> Action;

        //public RelayCommand(Func<Task> action)
        //{
        //    Action = action;
        //}

        private Action Action;

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
