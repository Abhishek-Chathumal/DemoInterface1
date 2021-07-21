using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class ModelsViewModel:observableObject
    {
        public RelayCommand ViewModelsViewCommand { get; set; }
        public RelayCommand AddModelsViewCommand { get; set; }
        public RelayCommand UpdateModelsViewCommand { get; set; }

        public ViewModelsViewModel ViewModelsVM { get; set; }
        public AddModelsViewModel AddModelsVM { get; set; }
        //public UpdateOwnersViewModel UpdateOwnerVM { get; set; }

        private object _presentModView;

        public object PresentModelsView
        {
            get { return _presentModView; }
            set
            {
                _presentModView = value;
                OnPropertyChanged();
            }
        }

        public ModelsViewModel()
        {
            AddModelsVM = new AddModelsViewModel();
            ViewModelsVM = new ViewModelsViewModel();
            //UpdateOwnerVM = new UpdateOwnersViewModel();
            PresentModelsView = ViewModelsVM;

            ViewModelsViewCommand = new RelayCommand(o =>
            {
                PresentModelsView = ViewModelsVM;

            });

            AddModelsViewCommand = new RelayCommand(o =>
            {
                PresentModelsView = AddModelsVM;

            });

            //UpdateOwnerViewCommand = new RelayCommand(o =>
            //{
            // PresentOwnerView = UpdateOwnerVM;
            //});

        }

    }
}
