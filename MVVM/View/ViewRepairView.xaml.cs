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
    /// Interaction logic for ViewRepairView.xaml
    /// </summary>
    public partial class ViewRepairView : UserControl
    {
        public ViewRepairView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();
        MaintenanceRepair mr = new MaintenanceRepair();
        AccidentRepair ar = new AccidentRepair();
        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";
        }

        private void cmb_RepCatagory_DropDownClosed(object sender, EventArgs e)
        {
            date_repair.SelectedDate = null;
            cmb_vehicle.SelectedIndex = -1;
            if (cmb_RepCatagory.SelectedIndex == 0)
            {
                dt = mr.viewRepair();
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_RepCatagory.SelectedIndex == 1)
            {
                dt = ar.viewRepair();
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_RepCatagory.SelectedIndex == 0)
            {
                dt = mr.viewRepairVehicle(cmb_vehicle.Text);
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_RepCatagory.SelectedIndex == 1)
            {
                dt = ar.viewRepairVehicle(cmb_vehicle.Text);
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }

        private void date_repair_CalendarClosed(object sender, RoutedEventArgs e)
        {
             if (cmb_RepCatagory.SelectedIndex == 0)
            {
                dt = mr.viewRepairDate(date_repair.SelectedDate.Value.ToString("yyyy-MM-dd"));
                dg_repair.ItemsSource = dt.DefaultView;
                
            }
            else if (cmb_RepCatagory.SelectedIndex == 1)
            {
                dt = ar.viewRepairVehicle(date_repair.SelectedDate.Value.ToString("yyyy-MM-dd"));
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            cmb_RepCatagory_DropDownClosed(this, null);
        }
    }
}
