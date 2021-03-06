using System.Windows;
using System.Windows.Controls;

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
            Reports.RViewVehicleService obj = new Reports.RViewVehicleService();
            obj.Show();
        }

        private void btn_maintenance_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewMaintenanceHistory obj = new Reports.RViewMaintenanceHistory();
            obj.Show();
        }

        private void btn_vehicle_accident_Click(object sender, RoutedEventArgs e)
        {
            Reports.RViewVehicleAccident obj = new Reports.RViewVehicleAccident();
            obj.Show();
        }

        private void btn_vehicle_maintenance_Click(object sender, RoutedEventArgs e)
        {
            Reports.RVIewVehicleMaintenance obj = new Reports.RVIewVehicleMaintenance();
            obj.Show();
        }
    }
}
