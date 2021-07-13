using DemoInterface1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterface1.MVVM.ModelView
{
    class CustomerViewModel:observableObject
    {
        
        public RelayCommand ViewCustomerViewCommand { get; set; }
        public RelayCommand AddCustomerViewCommand { get; set; }
        public RelayCommand UpdateCustomerViewCommand { get; set; }

        public ViewCustomerViewModel ViewCustomerVM { get; set; }
        public AddCustomerViewModel AddCustomerVM { get; set; }
        public UpdateCustomerViewModel UpdateCustomerVM { get; set; }

        private object _presentView;

        public object PresentView
        {
            get { return _presentView; }
            set
            {
                _presentView = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            AddCustomerVM = new AddCustomerViewModel();
            ViewCustomerVM = new ViewCustomerViewModel();
            UpdateCustomerVM = new UpdateCustomerViewModel();
            PresentView = ViewCustomerVM;

           AddCustomerViewCommand = new RelayCommand(o =>
            {
                PresentView = AddCustomerVM;
            });
            ViewCustomerViewCommand = new RelayCommand(o =>
            {
                PresentView = ViewCustomerVM;
            });
            UpdateCustomerViewCommand = new RelayCommand(o =>
            {
                PresentView = UpdateCustomerVM;
            });
        }
    }
}
