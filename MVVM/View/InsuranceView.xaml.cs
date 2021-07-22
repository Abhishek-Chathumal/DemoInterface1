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
    /// Interaction logic for InsuranceView.xaml
    /// </summary>
    public partial class InsuranceView : UserControl
    {
        public InsuranceView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Insurance ins = new Insurance();
        public void loadData()
        {
            dt = ins.viewInsurance();
            dg_ins.ItemsSource = dt.DefaultView;
        }
    }
}
