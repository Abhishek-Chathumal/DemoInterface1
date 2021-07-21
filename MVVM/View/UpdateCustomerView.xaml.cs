﻿using System;
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
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Text.RegularExpressions;


namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for UpdateCustomerView.xaml
    /// </summary>
    public partial class UpdateCustomerView : UserControl
    {
        public UpdateCustomerView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Customer customer = new Customer();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\Customers\\" + cmb_nic.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_nic.Text + ".jpg");
            return appStartPath;
        }
        public void loadData()
        {
            dt = customer.viewCustomer();
            cmb_nic.ItemsSource = dt.DefaultView;
            cmb_nic.DisplayMemberPath = "NIC";
            cmb_nic.SelectedValuePath = "NIC";
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public string getAddress(string no, string street, string city)
        {
            string address = (no + "," + street + "," + city);
            return address;
        }
        public string[] seperateAddress(string address)
        {
            string[] fields = address.Split(',');
            return fields;
        }

        private void cmb_nic_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_nic.SelectedItem == null)
                {
                    error_msg.Text = "Please Select NIC";
                }

                else
                {
                    dt = customer.viewCustomerNIC(cmb_nic.Text);

                    txt_CusFname.Text = dt.Rows[0][1].ToString();
                    txt_CusLname.Text = dt.Rows[0][2].ToString();
                    string[] fields = seperateAddress(dt.Rows[0][3].ToString());
                    txt_cusHouseNo.Text = fields[0];
                    txt_cusStreetNme.Text = fields[1];
                    txt_cusCity.Text = fields[2];
                    string[] wfields = seperateAddress(dt.Rows[0][8].ToString());
                    txt_CusWorkIns.Text = fields[0];
                    txt_cusWorkStrNme.Text = fields[1];
                    txt_cusWorkCity.Text = fields[2];
                    txt_CusTelHome.Text = dt.Rows[0][5].ToString();
                    txt_CusTelMobile.Text = dt.Rows[0][4].ToString();
                    txt_CusTelWork.Text = dt.Rows[0][9].ToString();
                    txt_CusEmail.Text = dt.Rows[0][6].ToString();
                    txt_CusProfession.Text = dt.Rows[0][7].ToString();
                    path = dt.Rows[0][13].ToString();
                    txt_CusKinName.Text = dt.Rows[0][10].ToString();
                    txt_CusKinkAdrs.Text = dt.Rows[0][11].ToString();
                    txt_CusKinConatct.Text = dt.Rows[0][12].ToString();

                    if (path != "")
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = new Uri(path);
                        image.EndInit();
                        img_customer.Source = image;
                    }
                    else
                    {
                        img_customer.Source = null;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Photo could not be located");
                msg.Show();
                img_customer.Source = null;
            }
            catch (Exception Ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops something went wrong" + Ex.Message);
                msg.Show();
            }
           
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            img_customer.Source = null;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                bool? result = open.ShowDialog();

                if (result == true)
                {
                    path = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                    img_customer.Source = imgsource;
                }
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {
                    string name = System.IO.Path.GetFileName(path);
                    string destinationPath = GetDestinationPath(name);                  
                    Customer upCustomer = new Customer(txt_CusFname.Text, txt_CusLname.Text, cmb_nic.Text, txt_CusEmail.Text, getAddress(txt_cusHouseNo.Text,txt_cusStreetNme.Text,txt_cusCity.Text), Int32.Parse(txt_CusTelHome.Text), Int32.Parse(txt_CusTelMobile.Text), txt_CusProfession.Text, getAddress(txt_CusWorkIns.Text,txt_cusWorkStrNme.Text,txt_cusWorkCity.Text), Int32.Parse(txt_CusTelWork.Text), txt_CusKinName.Text, txt_CusKinkAdrs.Text, Int32.Parse(txt_CusKinConatct.Text), destinationPath); ;
                    int i = upCustomer.updateCustomer();
                    if (i == 1)
                    {
                        File.Copy(path, destinationPath, true);
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.Show();
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Could not save data,Please try agian");
                        msg.Show();
                    }
                }
                catch (ArgumentNullException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please upload a photo");
                    msg.Show();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly. Database Error");
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
                msg.errorMsg("Please fill the form correctly. Database Error");
                msg.Show();
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cmb_nic.SelectedIndex = -1;
            txt_CusFname.Clear();
            txt_CusLname.Clear();

            txt_cusHouseNo.Clear();
            txt_cusStreetNme.Clear();
            txt_cusCity.Clear();
            txt_CusWorkIns.Clear();
            txt_cusWorkStrNme.Clear();
            txt_cusWorkCity.Clear();
            txt_CusTelHome.Clear();
            txt_CusTelMobile.Clear();
            txt_CusTelWork.Clear();
            txt_CusEmail.Clear();
            txt_CusProfession.Clear();
            txt_CusKinName.Clear();
            txt_CusKinkAdrs.Clear();
            txt_CusKinConatct.Clear();
            error_msg.Text = "";
        }

        private void txt_CusFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusFname.Text.Length == 0)
                error_msg.Text = "Please Enter Customer First Name  ";
            else if (!Regex.IsMatch(txt_CusFname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "First name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusLname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusLname.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer last Name  ";
            else if (!Regex.IsMatch(txt_CusLname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Last name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Email  ";
            else if (!IsValid(txt_CusEmail.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }


        private void txt_CusTelHome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelHome.Text.Length == 0)
                error_msg.Text = "Please Enter Customer  Home Telephone ";
            else if (!Regex.IsMatch(txt_CusTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Mobile Number ";
            else if (!Regex.IsMatch(txt_CusTelMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Profession  ";
            else
                error_msg.Text = "";
        }



        private void txt_CusTelWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelWork.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Work Telephone Number ";
            else if (!Regex.IsMatch(txt_CusTelWork.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinName.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Kin Name ";
            else if (!Regex.IsMatch(txt_CusKinName.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Kin name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinkAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinkAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Kin Address ";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinConatct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinConatct.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
            else if (!Regex.IsMatch(txt_CusKinConatct.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int line = customer.deleteCustomer(cmb_nic.Text);
            if (line == 1)
            {
                String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                string dir = appStartPath + "\\Customers\\" + cmb_nic.Text;
                var folder = new DirectoryInfo(dir);
                folder.Delete(true);
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Data deleted successfully");
                msg.Show();
                btn_clear_Click(this, null);
            }

            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Could not save data,Please try agian");
                msg.Show();
            }
        }

        private void txt_cusHouseNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusHouseNo.Text.Length == 0)
                error_msg.Text = "Please Enter Customer House No ";
            else
                error_msg.Text = "";
        }

        private void txt_cusStreetNme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusStreetNme.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Street Name ";
            else
                error_msg.Text = "";
        }

        private void txt_cusCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusCity.Text.Length == 0)
                error_msg.Text = "Please Enter Customer City ";
            else
                error_msg.Text = "";
        }

        private void txt_CusWorkIns_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusWorkIns.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Working Institute";
            else
                error_msg.Text = "";
        }

        private void txt_cusWorkStrNme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusWorkStrNme.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Working Street Address";
            else
                error_msg.Text = "";
        }

        private void txt_cusWorkCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusWorkCity.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Working City";
            else
                error_msg.Text = "";
        }
    }
}
