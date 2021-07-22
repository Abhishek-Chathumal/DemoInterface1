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
using System.Windows.Shapes;
using System.Data;
using System.Text.RegularExpressions;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for ViewInsuranceView.xaml
    /// </summary>
    public partial class ViewInsuranceView : UserControl
    {
        public ViewInsuranceView()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Insurance ins = new Insurance();
        public void loadData()
        {
            InsuranceView obj = new InsuranceView();
            dt = ins.viewInsurance();
            obj.dg_ins.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            loadData();
        }
    }
}
