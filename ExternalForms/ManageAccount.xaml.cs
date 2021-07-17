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
using System.Text.RegularExpressions;

namespace DemoInterface1.ExternalForms
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : Window
    {
        public ManageAccount()
        {
            InitializeComponent();
        }
        public ManageAccount(string uname)
        {
            InitializeComponent();
            txt_uName.Text = uname;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (txt_info.Text == "")
            {
                try
                {
                    HashCode hc = new HashCode();
                    User user = new User(txt_uName.Text);
                    int i = user.updatePassword(hc.PassHash(txt_pass.Password));
                    if (i == 1)
                    {
                        Message msg = new Message();
                        msg.informationMsg("Password Reseted Successfully!");
                        this.Close();
                        Login login = new Login();
                        login.Show();
                        msg.Show();
                    }
                    else
                    {
                        Message msg = new Message();
                        msg.errorMsg("Error.Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    Message msg = new Message();
                    msg.errorMsg("Please fill the form correctly. ");
                    msg.Show();
                }
                catch (Exception ex)
                {
                    Message msg = new Message();
                    msg.errorMsg("Oops something went worng. " + ex.Message);
                    msg.Show();
                }

            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(txt_uName.Text);
            int i = user.deleteAccount();
            if (i == 1)
            {
                Message msg = new Message();
                msg.informationMsg("Account Deleted Successfully!");
                msg.Show();
            }
            else
            {
                Message msg = new Message();
                msg.errorMsg("Error.Please try again");
                msg.Show();
            }
        }

        public void clearScreen()
        {
            txt_uName.Clear();
            txt_pass.Clear();
            txt_retype.Clear();
        }

        private void txt_retype_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_pass.Password != txt_retype.Password)
                txt_info.Text = "Passwords do not match";
            else if (txt_pass.Password == txt_retype.Password)
                txt_info.Text = "Passwords Match";
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(txt_pass.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"))
                txt_info.Text = "Invalid Password";
            else
                txt_info.Text = "Valid Password";
        }

        private void txt_uName_TextInput(object sender, TextCompositionEventArgs e)
        {
                if (txt_uName.Text.Length == 0)
                    txt_info.Text = "Username cannot be blank ";
                else
                    txt_info.Text = "";
        }
    }
}
