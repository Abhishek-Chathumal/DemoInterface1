using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class ServiceViewModel : observableObject
    {
        public RelayCommand ViewServiceViewCommand { get; set; }
        public RelayCommand AddServiceViewCommand { get; set; }
        public RelayCommand UpdateServiceViewCommand { get; set; }

        public ViewServiceViewModel ViewServiceVM { get; set; }
        public AddServiceViewModel AddServiceVM { get; set; }
        public UpdateServiceViewModel UpdateServiceVM { get; set; }

        private object _presentSerView;

        public object PresentServiceView
        {
            get { return _presentSerView; }
            set
            {
                _presentSerView = value;
                OnPropertyChanged();
            }
        }

        public ServiceViewModel()
        {
            ViewServiceVM = new ViewServiceViewModel();
            AddServiceVM = new AddServiceViewModel();
            UpdateServiceVM = new UpdateServiceViewModel();
            PresentServiceView = ViewServiceVM;

            ViewServiceViewCommand = new RelayCommand(o =>
            {
                PresentServiceView = ViewServiceVM;
            });
            AddServiceViewCommand = new RelayCommand(o =>
            {
                PresentServiceView = AddServiceVM;
            });
            UpdateServiceViewCommand = new RelayCommand(o =>
            {
                PresentServiceView = UpdateServiceVM;
            });

        }
    }
}
