using DemoInterface1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInterface1.MVVM.ModelView
{
    class VehicleViewModel : observableObject
    {
        public RelayCommand ViewVehicleViewCommand { get; set; }
        public RelayCommand AddVehicleViewCommand { get; set; }
        public RelayCommand UpdateVehicleViewCommand { get; set; }

        public ViewCustomerViewModel ViewVehicleVM { get; set; }
        public AddCustomerViewModel AddVehicleVM { get; set; }
        public UpdateCustomerViewModel UpdateVehicleVM { get; set; }

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
            AddVehicleVM = new AddCustomerViewModel();
            ViewVehicleVM = new ViewCustomerViewModel();
            UpdateVehicleVM = new UpdateCustomerViewModel();
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
