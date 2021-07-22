using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class RepairsViewModel : observableObject
    {
        public RelayCommand ViewRepairViewCommand { get; set; }
        public RelayCommand AddRepairViewCommand { get; set; }
        public RelayCommand UpdateRepairViewCommand { get; set; }

        public ViewRepairViewModel ViewRepairVM { get; set; }
        public AddRepairViewModel AddRepairVM { get; set; }
        public UpdateRepairViewModel UpdateRepairVM { get; set; }

        private object _presentRepView;

        public object PresentRepairView
        {
            get { return _presentRepView; }
            set
            {
                _presentRepView = value;
                OnPropertyChanged();
            }
        }

        public RepairsViewModel()
        {
            ViewRepairVM = new ViewRepairViewModel();
            AddRepairVM = new AddRepairViewModel();
            UpdateRepairVM = new UpdateRepairViewModel();
            PresentRepairView = ViewRepairVM;

            ViewRepairViewCommand = new RelayCommand(o =>
            {
                PresentRepairView = ViewRepairVM;
            });
            AddRepairViewCommand = new RelayCommand(o =>
            {
                PresentRepairView = AddRepairVM;
            });
            UpdateRepairViewCommand = new RelayCommand(o =>
            {
                PresentRepairView = UpdateRepairVM;
            });

        }
    }
}
