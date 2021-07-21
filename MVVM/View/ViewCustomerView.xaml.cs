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
    /// Interaction logic for ViewCustomerView.xaml
    /// </summary>
    public partial class ViewCustomerView : UserControl
    {
        public ViewCustomerView()
        {
            InitializeComponent();
            loadData();
        }
        Customer customer = new Customer();
        Database db = new Database();
        DataTable dt = new DataTable();

        public void loadData()
        {
            dt = customer.viewCustomer();
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            txt_CusName.Clear();
            txt_CusNIC.Clear();
            loadData();
        }

        private void btn_searchNIC_Click(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomerNIC(txt_CusNIC.Text);
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void btn_searchName_Click(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomerName(txt_CusName.Text);
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void txt_CusNIC_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_CusName.Clear();
        }

        private void txt_CusName_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_CusNIC.Clear();
        }
    }
}
