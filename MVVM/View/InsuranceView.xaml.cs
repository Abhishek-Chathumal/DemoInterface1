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

            dt = db.getData("Select max(insID) from Insurance ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_insID.Text = "I001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_insID.Text = newString;
            }
        }
        public void clearScreen()
        {
            txt_insComp.Clear();
            txt_insID.Clear();
        }

        private void rbtn_add_Checked(object sender, RoutedEventArgs e)
        {
            txt_View.Text = (string)rbtn_add.Content;
            btn_add.IsEnabled = true;
            btn_update.IsEnabled = false;
            btn_del.IsEnabled = false;
            dg_ins.IsEnabled = false;
            clearScreen();
            loadData();
        }

        private void rbtn_update_Checked(object sender, RoutedEventArgs e)
        {
            txt_View.Text = (string)rbtn_update.Content;
            btn_add.IsEnabled = false;
            btn_update.IsEnabled = true;
            btn_del.IsEnabled = true;
            dg_ins.IsEnabled = true;
            loadData();
            clearScreen();
        }

        private void dg_ins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dg_ins.SelectedItem;
            if (dataRow != null)
            {
                int index = dg_ins.CurrentCell.Column.DisplayIndex;
                txt_insID.Text = dataRow.Row.ItemArray[0].ToString();
                txt_insComp.Text = dataRow.Row.ItemArray[1].ToString();

            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if(txt_insComp.Text != "")
            {
                try
                {
                    Insurance insurance = new Insurance(txt_insID.Text, txt_insComp.Text);
                    int i = insurance.addInsurance();
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
          
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if(txt_insComp.Text != "")
            {
                try
                {
                    Insurance insurance = new Insurance(txt_insID.Text, txt_insComp.Text);
                    int i = insurance.updateInsurance();
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.informationMsg("Data Updated Successfully!");
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

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if(txt_insID.Text != "")
            {
                try
                {
                    int i = ins.deleteInsurance(txt_insID.Text);
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.informationMsg("Data Deleted Successfully!");
                        msg.Show();
                        rbtn_update_Checked(this, null);
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Sorry, couldn't delete your data.Please try again");
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

        private void txt_insComp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_insComp.Text.Length == 0)
                txt_error.Text = "Please enter a Insurance Name";
            else
                txt_error.Text = "";
        }
    }
}
