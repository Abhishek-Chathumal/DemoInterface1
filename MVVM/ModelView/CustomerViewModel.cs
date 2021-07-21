using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class CustomerViewModel : observableObject
    {

        public RelayCommand ViewCustomerViewCommand { get; set; }
        public RelayCommand AddCustomerViewCommand { get; set; }
        public RelayCommand UpdateCustomerViewCommand { get; set; }

        public ViewCustomerViewModel ViewCustomerVM { get; set; }
        public AddCustomerViewModel AddCustomerVM { get; set; }
        public UpdateCustomerViewModel UpdateCustomerVM { get; set; }

        private object _presentCusView;

        public object PresentCustomerView
        {
            get { return _presentCusView; }
            set
            {
                _presentCusView = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            AddCustomerVM = new AddCustomerViewModel();
            ViewCustomerVM = new ViewCustomerViewModel();
            UpdateCustomerVM = new UpdateCustomerViewModel();
            PresentCustomerView = ViewCustomerVM;

            ViewCustomerViewCommand = new RelayCommand(o =>
            {
                PresentCustomerView = ViewCustomerVM;

            });

            AddCustomerViewCommand = new RelayCommand(o =>
            {
                PresentCustomerView = AddCustomerVM;

            });

            UpdateCustomerViewCommand = new RelayCommand(o =>
            {
                PresentCustomerView = UpdateCustomerVM;
            });

        }
    }
}
