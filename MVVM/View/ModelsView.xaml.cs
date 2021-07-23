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
    /// Interaction logic for ModelsView.xaml
    /// </summary>
    public partial class ModelsView : UserControl
    {
        public ModelsView()
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
        public void clearScreen()
        {
            txt_modelID.Clear();
            cmb_cat.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_year.SelectedIndex = -1;
            txt_model.Clear();
            txt_short.Clear();
            txt_long.Clear();
            txt_extra.Clear();
            txt_error.Text = "";
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
                        clearScreen();
                        loadData();
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
            if (txt_model.Text.Length == 0)
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
            if (txt_short.Text.Length == 0)
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

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (txt_error.Text == "")
            {
                try
                {
                    ModelPricing upPrice = new ModelPricing(txt_modelID.Text, cmb_cat.Text, Int32.Parse(cmb_year.Text), cmb_make.Text, txt_model.Text, Int32.Parse(txt_short.Text), Int32.Parse(txt_long.Text), float.Parse(txt_extra.Text));
                    int i = upPrice.updatePricing();
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.Show();
                        rbtn_update_Checked(this, null);
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

        private void rbtn_add_Checked(object sender, RoutedEventArgs e)
        {
            rbtn_update.IsChecked = false;
            dg_model.IsEnabled = false;
            btn_save.IsEnabled = true;
            btn_update.IsEnabled = false;
            btn_del.IsEnabled = false;
            clearScreen();
            loadData();
        }

        private void rbtn_update_Checked(object sender, RoutedEventArgs e)
        {
            rbtn_add.IsChecked = false;
            dg_model.IsEnabled = true;
            btn_save.IsEnabled = false;
            btn_update.IsEnabled = true;
            btn_del.IsEnabled = true;
            loadData();
            clearScreen();          
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = price.deletePricing(txt_modelID.Text);
                if (i == 1)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.Show();
                    rbtn_add_Checked(this, null);
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

        private void dg_model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dg_model.SelectedItem;
            if (dataRow != null)
            {
                int index = dg_model.CurrentCell.Column.DisplayIndex;
                txt_modelID.Text = dataRow.Row.ItemArray[0].ToString();
                cmb_cat.Text = dataRow.Row.ItemArray[1].ToString();
                cmb_year.Text = dataRow.Row.ItemArray[2].ToString();
                cmb_make.Text = dataRow.Row.ItemArray[3].ToString();
                txt_model.Text = dataRow.Row.ItemArray[4].ToString();
                txt_short.Text = dataRow.Row.ItemArray[5].ToString();
                txt_long.Text = dataRow.Row.ItemArray[6].ToString();
                txt_extra.Text = dataRow.Row.ItemArray[7].ToString();
            }
        }
    }
}
