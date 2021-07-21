using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class InsuranceViewModel : observableObject
    {
        public RelayCommand ViewInsuranceViewCommand { get; set; }
        public RelayCommand AddInsuranceViewCommand { get; set; }
        public RelayCommand UpdateInsuranceViewCommand { get; set; }

        public ViewInsuranceViewModel ViewInsuranceVM { get; set; }
        public AddInsuranceViewModel AddInsuranceVM { get; set; }
        public UpdateInsuranceViewModel UpdateInsuranceVM { get; set; }

        private object _presentInsView;

        public object PresentInsuranceView
        {
            get { return _presentInsView; }
            set
            {
                _presentInsView = value;
                OnPropertyChanged();
            }
        }

        public InsuranceViewModel()
        {
            ViewInsuranceVM = new ViewInsuranceViewModel();
            AddInsuranceVM = new AddInsuranceViewModel();
            UpdateInsuranceVM = new UpdateInsuranceViewModel();
            PresentInsuranceView = ViewInsuranceVM;

            ViewInsuranceViewCommand = new RelayCommand(o =>
            {
                PresentInsuranceView = ViewInsuranceVM;
            });
            AddInsuranceViewCommand = new RelayCommand(o =>
            {
                PresentInsuranceView = AddInsuranceVM;
            });
            UpdateInsuranceViewCommand = new RelayCommand(o =>
            {
                PresentInsuranceView = UpdateInsuranceVM;
            });

        }
    }
}
