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
using System.Net.Mail;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for AccountsView.xaml
    /// </summary>
    public partial class AccountsView : UserControl
    {
        public AccountsView()
        {
            InitializeComponent();
            loadData();
        }
        User user = new User();
        DataTable dt = new DataTable();
        
        public void loadData()
        {
            dt = user.viewUser();
            dg_accounts.ItemsSource = dt.DefaultView;
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public void clearScreen()
        {
            cmb_type.SelectedIndex = -1;
            txt_uname.Clear();
            txt_email.Clear();
            txt_pass.Clear();
            txt_retype.Clear();
            error_msg.Text = "";
        }

        private void cmb_type_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_type.SelectedItem == null)
                error_msg.Text = "Please Select Use Type";
            else { error_msg.Text = ""; }
        }

        private void txt_uname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_uname.Text.Length == 0)
                error_msg.Text = "Please Enter a UserName  ";
            else if (txt_uname.Text.Length <= 5)
                error_msg.Text = "Username to short ";
            else
            {
                dt = user.checkUser(txt_uname.Text);
                if (dt.Rows.Count == 1)
                {
                    error_msg.Text = "Sorry Username already taken";
                    txt_uname.Focus();
                }
                else
                {
                    error_msg.Text = "";
                }
            }
        }

        private void txt_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_email.Text.Length == 0)
                error_msg.Text = "Please enter a email address  ";
            else if (!IsValid(txt_email.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(txt_pass.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"))
                error_msg.Text = "Invalid Password";
            else
                error_msg.Text = "";
        }

        private void txt_retype_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_pass.Password != txt_retype.Password)
                error_msg.Text = "Passwords do not match";
            else if (txt_pass.Password == txt_retype.Password)
                error_msg.Text = "";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (txt_uname.Text != "" && txt_retype.Password != "" && error_msg.Text == "")
            {
                try
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    HashCode hc = new HashCode();
                    User user = new User(cmb_type.Text, txt_uname.Text, hc.PassHash(txt_pass.Password), txt_email.Text);
                    int i = user.addAccount();
                    if (i == 1)
                    {
                        msg.informationMsg("Account Successfully Registered!");
                        msg.Show();
                        clearScreen();
                        loadData();
                    }
                    else
                    {
                        msg.errorMsg("Sorry, couldn't create Account.Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly. ");
                    msg.Show();
                }
                catch (System.FormatException)
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
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the Form Properly");
                msg.Show();
            }
        }

        private void rbtn_add_Checked(object sender, RoutedEventArgs e)
        {
            rbtn_update.IsChecked = false;
            btn_add.IsEnabled = true;
            btn_update.IsEnabled = false;
            btn_del.IsEnabled = false;
            dg_accounts.IsEnabled = false;
            txt_uname.IsEnabled = true;
            clearScreen();

        }

        private void rbtn_update_Checked(object sender, RoutedEventArgs e)
        {
            rbtn_add.IsChecked = false;
            btn_add.IsEnabled = false;
            btn_update.IsEnabled = true;
            btn_del.IsEnabled = true;
            dg_accounts.IsEnabled = true;
            txt_uname.IsEnabled = false;
            clearScreen();
        }

        private void dg_accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dg_accounts.SelectedItem;
            if (dataRow != null)
            {
                int index = dg_accounts.CurrentCell.Column.DisplayIndex;
                cmb_type.Text = dataRow.Row.ItemArray[0].ToString();
                txt_uname.Text = dataRow.Row.ItemArray[1].ToString();
                txt_email.Text = dataRow.Row.ItemArray[2].ToString();
                error_msg.Text = null;
            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(txt_uname.Text);
            int i = user.deleteAccount();
            if (i == 1)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.informationMsg("Account Deleted Successfully!");
                msg.Show();
                loadData();
                clearScreen();
            }
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Error.Please try again");
                msg.Show();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (txt_uname.Text != "" && txt_retype.Password != "" && error_msg.Text == "")
            {
                try
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    HashCode hc = new HashCode();
                    User user = new User(cmb_type.Text, txt_uname.Text, hc.PassHash(txt_pass.Password), txt_email.Text);
                    int i = user.updateAccount();
                    if (i == 1)
                    {
                        msg.informationMsg("Account Successfully Update!");
                        msg.Show();
                        clearScreen();
                        loadData();
                    }
                    else
                    {
                        msg.errorMsg("Sorry, couldn't update Account.Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly. ");
                    msg.Show();
                }
                catch (System.FormatException)
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
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the Form Properly");
                msg.Show();
            }
        }
    }
}
