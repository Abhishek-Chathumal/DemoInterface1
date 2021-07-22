using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoInterface1.Core;

namespace DemoInterface1.MVVM.ModelView
{
    class BookingViewModel  : observableObject
    {
        public RelayCommand ViewBookingViewCommand { get; set; }
        public RelayCommand AddBookingViewCommand { get; set; }
        public RelayCommand UpdateBookingViewCommand { get; set; }

        public ViewBookingViewModel ViewBookingVM { get; set; }
        public AddBookingViewModel AddBookingVM { get; set; }
        public UpdateBookingViewModel UpdateBookingVM { get; set; }

        private object _presentBokView;

        public object PresentBookingView
        {
            get { return _presentBokView; }
            set
            {
                _presentBokView = value;
                OnPropertyChanged();
            }
        }

        public BookingViewModel()
        {
            ViewBookingVM = new ViewBookingViewModel();
            AddBookingVM = new AddBookingViewModel();
            UpdateBookingVM = new UpdateBookingViewModel();
            PresentBookingView = ViewBookingVM;

            ViewBookingViewCommand = new RelayCommand(o =>
            {
                PresentBookingView = ViewBookingVM;
            });
            AddBookingViewCommand = new RelayCommand(o =>
            {
                PresentBookingView = AddBookingVM;
            });
            UpdateBookingViewCommand = new RelayCommand(o =>
            {
                PresentBookingView = UpdateBookingVM;
            });

        }
    }
}
