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
    /// Interaction logic for ViewServiceView.xaml
    /// </summary>
    public partial class ViewServiceView : UserControl
    {
        public ViewServiceView()
        {
            InitializeComponent();
            loadData();
        }
        Vehicle vehicle = new Vehicle();
        Service service = new Service();
        DataTable dt = new DataTable();
        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";

            dt = service.viewService();
            dg_service.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            dt = service.viewService(cmb_vehicle.Text);
            dg_service.ItemsSource = dt.DefaultView;
        }
    }
}
