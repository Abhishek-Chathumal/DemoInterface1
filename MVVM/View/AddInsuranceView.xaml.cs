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
    /// Interaction logic for AddInsuranceView.xaml
    /// </summary>
    public partial class AddInsuranceView : UserControl
    {
        public AddInsuranceView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Insurance ins = new Insurance();
        public void loadData()
        {
            dt = db.getData("Select max(insID) from Insurance ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_AddinsID.Text = "I001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_AddinsID.Text = newString;
            }
            InsuranceView obj = new InsuranceView();
            dt = ins.viewInsurance();
            obj.dg_ins.ItemsSource = dt.DefaultView;
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_AddinsComp.Clear();
            loadData();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Insurance insurance = new Insurance(txt_AddinsID.Text, txt_AddinsComp.Text);
            int i = insurance.addInsurance();
            if (i == 1)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.Show();
                btn_cls_Click(this, null);
            }
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }
    }
}
