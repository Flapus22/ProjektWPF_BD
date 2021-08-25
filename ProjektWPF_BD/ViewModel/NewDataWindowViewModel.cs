using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjektWPF_BD.View.UserControls;

namespace ProjektWPF_BD.ViewModel
{
    class NewDataWindowViewModel : INotifyPropertyChanged
    {
        public UserControl UserControl { get; set; } = NewTransactionUserControlView;

        public static NewDataWindowViewModel instance { get; set; } = new NewDataWindowViewModel();

        public static NewCustomerUserControlView NewCustomerUserControlView { get; set; } = new NewCustomerUserControlView();
        public static NewEmployeeUserControlView NewEmployeeUserControlView { get; set; } = new NewEmployeeUserControlView();
        public static NewProductUserControlView NewProductUserControlView { get; set; } = new NewProductUserControlView();
        public static NewTransactionUserControlView NewTransactionUserControlView { get; set; } = new NewTransactionUserControlView();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NewCustomerShow()
        {
            UserControl = NewCustomerUserControlView;
        }
        public void NewEmployeeShow()
        {
            UserControl = NewEmployeeUserControlView;
        }
        public void NewProductShow()
        {
            UserControl = NewProductUserControlView;
        }
        public void NewTransactionShow()
        {
            UserControl = NewTransactionUserControlView;
        }

    }
}
