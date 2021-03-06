using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class MainViewModel : observableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand VehicleViewCommand { get; set; }
        public RelayCommand CustomerViewCommand { get; set; }
        public RelayCommand BookingViewCommand { get; set; }
        public RelayCommand OwnerViewCommand { get; set; }
        public RelayCommand ModelsViewCommand { get; set; }
        public RelayCommand RepairsViewCommand { get; set; }
        public RelayCommand ServiceViewCommand { get; set; }
        public RelayCommand AccountsViewCommand { get; set; }
        public RelayCommand ReportsViewCommand { get; set; }
        public RelayCommand InsuranceViewCommand { get; set; }



        public HomeViewModel HomeVM { get; set; }
        public VehicleViewModel VehicleVM { get; set; }
        public CustomerViewModel CustomerVM { get; set; }
        public BookingViewModel BookingVM { get; set; }
        public OwnerViewModel OwnerVM { get; set; }
        public ModelsViewModel ModelVM { get; set; }
        public RepairsViewModel RepairsVM { get; set; }
        public ServiceViewModel ServiceVM { get; set; }
        public AccountsViewModel AccountsVM { get; set; }
        public ReportsViewModel ReportsVM { get; set; }
        public InsuranceViewModel InsuranceVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            VehicleVM = new VehicleViewModel();
            CustomerVM = new CustomerViewModel();
            BookingVM = new BookingViewModel();
            OwnerVM = new OwnerViewModel();
            ModelVM = new ModelsViewModel();
            RepairsVM = new RepairsViewModel();
            ServiceVM = new ServiceViewModel();
            AccountsVM = new AccountsViewModel();
            ReportsVM = new ReportsViewModel();
            InsuranceVM = new InsuranceViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            VehicleViewCommand = new RelayCommand(o =>
            {
                CurrentView = VehicleVM;
            });
            CustomerViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomerVM;
            });
            BookingViewCommand = new RelayCommand(o =>
            {
                CurrentView = BookingVM;
            });
            OwnerViewCommand = new RelayCommand(o =>
            {
                CurrentView = OwnerVM;
            });
            ModelsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ModelVM;
            });
            RepairsViewCommand = new RelayCommand(o =>
            {
                CurrentView = RepairsVM;
            });
            ServiceViewCommand = new RelayCommand(o =>
            {
                CurrentView = ServiceVM;
            });
            AccountsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AccountsVM;
            });
            ReportsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReportsVM;
            });
            InsuranceViewCommand = new RelayCommand(o =>
            {
                CurrentView = InsuranceVM;
            });
        }
    }
}
