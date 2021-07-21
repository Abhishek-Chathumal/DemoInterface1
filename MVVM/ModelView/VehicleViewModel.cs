using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class VehicleViewModel : observableObject
    {
        public RelayCommand ViewVehicleViewCommand { get; set; }
        public RelayCommand AddVehicleViewCommand { get; set; }
        public RelayCommand UpdateVehicleViewCommand { get; set; }

        public ViewVehiclesViewModel ViewVehicleVM { get; set; }
        public AddVehiclesViewModel AddVehicleVM { get; set; }
        public UpdateVehiclesViewModel UpdateVehicleVM { get; set; }

        private object _presentVehView;

        public object PresentVehicleView
        {
            get { return _presentVehView; }
            set
            {
                _presentVehView = value;
                OnPropertyChanged();
            }
        }

        public VehicleViewModel()
        {
            AddVehicleVM = new AddVehiclesViewModel();
            ViewVehicleVM = new ViewVehiclesViewModel();
            UpdateVehicleVM = new UpdateVehiclesViewModel();
            PresentVehicleView = ViewVehicleVM;

            ViewVehicleViewCommand = new RelayCommand(o =>
            {
                PresentVehicleView = ViewVehicleVM;

            });

            AddVehicleViewCommand = new RelayCommand(o =>
            {
                PresentVehicleView = AddVehicleVM;

            });

            UpdateVehicleViewCommand = new RelayCommand(o =>
            {
                PresentVehicleView = UpdateVehicleVM;
            });
        }

    }
}
