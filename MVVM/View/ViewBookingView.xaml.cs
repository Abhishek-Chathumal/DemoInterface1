using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for ViewBookingView.xaml
    /// </summary>
    public partial class ViewBookingView : UserControl
    {
        public ViewBookingView()
        {
            InitializeComponent();
            loadData();
        }
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        Booking book = new Booking();
        DataTable dt = new DataTable();

        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_vno.ItemsSource = dt.DefaultView;
            cmb_vno.DisplayMemberPath = "Plate No";
            cmb_vno.SelectedValuePath = "Plate No";

            dt = customer.viewCustomer();
            cmb_cno.ItemsSource = dt.DefaultView;
            cmb_cno.DisplayMemberPath = "NIC";
            cmb_cno.SelectedValuePath = "NIC";

            cmb_vno.SelectedIndex = -1;
            cmb_cno.SelectedIndex = -1;
            dte_bDate.SelectedDate = null;

            dt = book.viewBookingForm();
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void cmb_vno_DropDownClosed(object sender, EventArgs e)
        {
            dte_bDate.SelectedDate = null;
            cmb_cno.SelectedIndex = -1;
            dt = book.viewBookingVehicle(cmb_vno.Text);
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void cmb_cno_DropDownClosed(object sender, EventArgs e)
        {
            dte_bDate.SelectedDate = null;
            cmb_vno.SelectedIndex = -1;
            dt = book.viewBookingCustomer(cmb_cno.Text);
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void dte_bDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dte_bDate.SelectedDate != null)
            {
                dt = book.viewBookingDate(dte_bDate.SelectedDate.Value.ToString("yyyy-MM-dd"));
                dg_booking.ItemsSource = dt.DefaultView;
            }

        }
    }
}
