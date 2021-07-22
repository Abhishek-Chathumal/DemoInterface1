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
    /// Interaction logic for AddModelsView.xaml
    /// </summary>
    public partial class AddModelsView : UserControl
    {
        public AddModelsView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        ModelPricing price = new ModelPricing();
        public void loadData()
        {
            dt = price.viewPricing();
            dg_model.ItemsSource = dt.DefaultView;

            dt = db.getData("Select max(pID) from Pricing ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_modelID.Text = "P001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_modelID.Text = newString;
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_cat.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_year.SelectedIndex = -1;
            txt_model.Clear();
            txt_short.Clear();
            txt_long.Clear();
            txt_extra.Clear();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_error.Text == "")
            {
                try
                {
                    ModelPricing price = new ModelPricing(txt_modelID.Text, cmb_cat.Text, Int32.Parse(cmb_year.Text), cmb_make.Text, txt_model.Text, Int32.Parse(txt_short.Text), Int32.Parse(txt_long.Text), float.Parse(txt_extra.Text));
                    int i = price.addPricing();
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.Show();
                        loadData();
                        btn_cls_Click(this, null);
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Sorry, couldn't save your data.Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly. ");
                    msg.Show();
                }
                catch (Exception ex)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Oops something went worng. " + ex.Message);
                    msg.Show();
                }
            }
        }

        private void cmb_cat_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_cat.SelectedIndex == -1)
                txt_error.Text = "Please select a vehicle category";
            else
                txt_error.Text = "";
        }

        private void cmb_make_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_make.SelectedIndex == -1)
                txt_error.Text = "Please select a vehicle make";
            else
                txt_error.Text = "";
        }

        private void txt_model_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_extra.Text.Length == 0)
                txt_error.Text = "Please Enter a Vehicle Model";
            else
                txt_error.Text = "";
        }

        private void cmb_year_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_year.SelectedIndex == -1)
                txt_error.Text = "Please select a vehicle year";
            else
                txt_error.Text = "";
        }

        private void txt_short_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_short.Text.Length == 0)
                txt_error.Text = "Please Enter Short Rent";
            else if (!Regex.IsMatch(txt_short.Text, "^[0-9]*$"))
                txt_error.Text = "Please enter numbers only";
            else
                txt_error.Text = "";
        }

        private void txt_long_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_long.Text.Length == 0)
                txt_error.Text = "Please Enter Long Rent";
            else if (!Regex.IsMatch(txt_long.Text, "^[0-9]*$"))
                txt_error.Text = "Please enter numbers only";
            else
                txt_error.Text = "";
        }

        private void txt_extra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_extra.Text.Length == 0)
                txt_error.Text = "Please Enter extra milage";
            else if (!Regex.IsMatch(txt_extra.Text, "^[0-9]*$"))
                txt_error.Text = "Please enter numbers only";
            else
                txt_error.Text = "";
        }
    }
}
