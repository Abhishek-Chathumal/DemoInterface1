using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class OwnerViewModel : observableObject
    {
        public RelayCommand ViewOwnerViewCommand { get; set; }
        public RelayCommand AddOwnerViewCommand { get; set; }
        public RelayCommand UpdateOwnerViewCommand { get; set; }

        public ViewOwnersViewModel ViewOwnerVM { get; set; }
        public AddOwnersViewModel AddOwnerVM { get; set; }
        public UpdateOwnersViewModel UpdateOwnerVM { get; set; }

        private object _presentOwnView;

        public object PresentOwnerView
        {
            get { return _presentOwnView; }
            set
            {
                _presentOwnView = value;
                OnPropertyChanged();
            }
        }

        public OwnerViewModel()
        {
            AddOwnerVM = new AddOwnersViewModel();
            ViewOwnerVM = new ViewOwnersViewModel();
            UpdateOwnerVM = new UpdateOwnersViewModel();
            PresentOwnerView = ViewOwnerVM;

            ViewOwnerViewCommand = new RelayCommand(o =>
            {
                PresentOwnerView = ViewOwnerVM;

            });

            AddOwnerViewCommand = new RelayCommand(o =>
            {
                PresentOwnerView = AddOwnerVM;

            });

            UpdateOwnerViewCommand = new RelayCommand(o =>
            {
                PresentOwnerView = UpdateOwnerVM;
            });

        }
    }
}
