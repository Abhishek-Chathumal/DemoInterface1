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

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView()
        {
            InitializeComponent();
        }

        private void btn_book_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewBookingHistory obj = new Reports.RViewBookingHistory();
            obj.Show();
        }

        private void btn_vehicle_book_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewVehicleBooking obj = new Reports.RViewVehicleBooking();
            obj.Show();
        }

        private void btn_cus_book_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewCustomerBooking obj = new Reports.RViewCustomerBooking();
            obj.Show();
        }

        private void btn_status_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewVehicleStatus obj = new Reports.RViewVehicleStatus();
            obj.Show();
        }

        private void btn_acccident_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewAccidentHistory obj = new Reports.RViewAccidentHistory();
            obj.Show();
        }

        private void btn_service_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewServiceHistory obj = new Reports.RViewServiceHistory();
            obj.Show();
        }

        private void btn_vehicle_service_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_maintenance_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewMaintenanceHistory obj = new Reports.RViewMaintenanceHistory();
            obj.Show();
        }

        private void btn_vehicle_accident_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_vehicle_maintenance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
