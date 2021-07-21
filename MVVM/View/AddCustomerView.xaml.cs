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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : UserControl
    {
        public AddCustomerView()
        {
            InitializeComponent();
        }
        string path;
        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\Customers\\" + txt_CusNIC.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_CusNIC.Text + ".jpg");
            return appStartPath;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
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

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            img_customer.Source = null;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_cusFname.Clear();
            txt_cusLname.Clear();
            txt_CusNIC.Clear();
            txt_cusEmail.Clear();
            txt_cusHouseNo.Clear();
            txt_cusStreetNme.Clear();
            txt_cusCity.Clear();
            txt_cusHomeTel.Clear();
            txt_cusMobile.Clear();
            txt_cusProfession.Clear();
            txt_cusWorkInstitute.Clear();
            txt_cusWorkStrNme.Clear();
            txt_cusWorkCity.Clear();
            txt_cusWorkTel.Clear();
            txt_kinName.Clear();
            txt_kinAddrs.Clear();
            txt_kinCntkt.Clear();
            error_msg.Text = "";
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {
                    string name = System.IO.Path.GetFileName(path);
                    string destinationPath = GetDestinationPath(name);
                    Customer customer = new Customer(txt_cusFname.Text, txt_cusLname.Text, txt_CusNIC.Text, txt_cusEmail.Text, getAddress(txt_cusHouseNo.Text,txt_cusStreetNme.Text,txt_cusCity.Text), Int32.Parse(txt_cusHomeTel.Text), Int32.Parse(txt_cusMobile.Text), txt_cusProfession.Text, getAddress(txt_cusWorkInstitute.Text,txt_cusWorkStrNme.Text,txt_cusWorkCity.Text), Int32.Parse(txt_cusWorkTel.Text), txt_kinName.Text, txt_kinAddrs.Text, Int32.Parse(txt_kinCntkt.Text), destinationPath);
                    int i = customer.addCustomer();
                    if (i == 1)
                    {
                        File.Copy(path, destinationPath, true);
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.Show();
                        btn_clear_Click(this, null);
                        img_customer.Source = null;
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Sorry, couldn't save your data.Please try again");
                        msg.Show();
                    }
                }
                catch (ArgumentNullException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please upload a photo");
                    msg.Show();
                }
                catch (FormatException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form properly");
                    msg.Show();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly.");
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
                msg.errorMsg("Please fill the form correctly.");
                msg.Show();
            }
        }

        private void txt_CusNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusNIC.Text.Length == 0)
                error_msg.Text = "Please Enter Customer NIC  ";
            else if (txt_CusNIC.Text.Length < 10 || txt_CusNIC.Text.Length > 12)
                error_msg.Text = "Invalid NIC  ";
            else
                error_msg.Text = "";
        }

        private void txt_cusFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusFname.Text.Length == 0)
                error_msg.Text = "Please Enter Customer First Name  ";
            else if (!Regex.IsMatch(txt_cusFname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "First name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_cusLname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusLname.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer last Name  ";
            else if (!Regex.IsMatch(txt_cusLname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Last name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_cusEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Email  ";
            else if (!IsValid(txt_cusEmail.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }   

        private void txt_cusHomeTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusHomeTel.Text.Length == 0)
                error_msg.Text = "Please Enter Customer  Home Telephone ";
            else if (!Regex.IsMatch(txt_cusHomeTel.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_cusMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Mobile Number ";
            else if (!Regex.IsMatch(txt_cusMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_cusProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Profession  ";
            else
                error_msg.Text = "";
        }

        private void txt_cusWorkTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusWorkTel.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Work Telephone Number ";
            else if (!Regex.IsMatch(txt_cusWorkTel.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_kinName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_kinName.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Kin Name ";
            else if (!Regex.IsMatch(txt_kinName.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Kin name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_kinAddrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_kinAddrs.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Kin Address ";
            else
                error_msg.Text = "";
        }

        private void txt_kinCntkt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_kinCntkt.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
            else if (!Regex.IsMatch(txt_kinCntkt.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
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

        private void txt_cusWorkInstitute_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cusWorkInstitute.Text.Length == 0)
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
