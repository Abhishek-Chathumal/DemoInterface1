
﻿using System.Windows.Controls;
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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Text.RegularExpressions;


namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddVehiclesView.xaml
    /// </summary>
    public partial class AddVehiclesView : UserControl
    {
        public AddVehiclesView()
        {
            InitializeComponent();
            loadData();
        }
        ModelPricing model = new ModelPricing();
        Owner owner = new Owner();
        Insurance insurance = new Insurance();
        Database db = new Database();
        string insID;
        string modelID;
        string filepath;
        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\Vehicles\\" + txt_Lplate.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_Lplate.Text + ".jpg");
            return appStartPath;
        }
        public void loadData()
        {
            DataTable dt = new DataTable();
            dt = model.viewPricing();
            cmb_modelID.ItemsSource = dt.DefaultView;
            cmb_modelID.DisplayMemberPath = "Model ID";
            cmb_modelID.SelectedValuePath = "Model ID";
            dt = owner.viewOwner();
            cmb_ownerNIC.ItemsSource = dt.DefaultView;
            cmb_ownerNIC.DisplayMemberPath = "NIC";
            cmb_ownerNIC.SelectedValuePath = "NIC";
            dt = insurance.viewInsurance();
            cmb_ins.ItemsSource = dt.DefaultView;
            cmb_ins.DisplayMemberPath = "insName";
            cmb_ins.SelectedValuePath = "insName";
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
                    filepath = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                    img_vehicle.Source = imgsource;
                }
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            img_vehicle.Source = null;
        }

        private void cmb_modelID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_modelID.SelectedItem == null)
            {
                error_msg.Text = "Please Select Model";
            }

            else
            {
                DataTable dt = new DataTable();
                dt = model.viewPricing(cmb_modelID.Text);
                modelID = dt.Rows[0][0].ToString();
                txt_catagory.Text = dt.Rows[0][1].ToString();
                txt_make.Text = dt.Rows[0][3].ToString();
                txt_model.Text = dt.Rows[0][4].ToString();
                txt_year.Text = dt.Rows[0][2].ToString();
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_modelID.SelectedIndex = -1;
            txt_catagory.Clear();
            txt_make.Clear();
            txt_model.Clear();
            cmb_color.SelectedIndex = -1;
            txt_year.Clear();
            txt_Lplate.Clear();
            cmb_Ecapacity.SelectedIndex = -1;
            cmb_Ftype.SelectedIndex = -1;
            cmb_noPassengers.SelectedIndex = -1;
            cmb_ins.SelectedIndex = -1;
            date_InsuranceStart.SelectedDate = null;
            date_InsuranceEnd.SelectedDate = null;
            date_licenseStart.SelectedDate = null;
            date_LicenseEnd.SelectedDate = null;
            cmb_ownerNIC.SelectedIndex = -1;
            txt_oName.Clear();
            txt_oPay.Clear();
            txt_wName.Clear();
            txt_wAdd.Clear();
            txt_wContact.Clear();
            img_vehicle.Source = null;
            cmb_trans.SelectedIndex = -1;
            date_lend.SelectedDate = null;
            error_msg.Text = "";
        }

        private void cmb_ins_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ins.SelectedItem == null)
            {
                error_msg.Text = "Please Select Company";
            }
            else
            {
                DataTable dt = new DataTable();
                dt = insurance.viewInsurance(cmb_ins.Text);
                insID = dt.Rows[0][0].ToString();
            }
        }

        private void cmb_ownerNIC_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ownerNIC.SelectedItem == null)
            {
                error_msg.Text = "Please Select Company";
            }
            else
            {
                DataTable dt = new DataTable();
                dt = owner.viewOwner(cmb_ownerNIC.Text);
                txt_oName.Text = dt.Rows[0][1].ToString();
            }
        }

        private void txt_catagory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_catagory.Text.Length == 0)
                error_msg.Text = "Cannot Keep This Empty";
            else
                error_msg.Text = "";
        }

        private void txt_wName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wName.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Name";
            else if (!Regex.IsMatch(txt_wName.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Witness name is not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_wAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wAdd.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Address";
            else
                error_msg.Text = "";
        }

        private void txt_wContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wContact.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Contact Number ";
            else if (!Regex.IsMatch(txt_wContact.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void cmb_trans_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_trans.SelectedItem == null)
            {
                error_msg.Text = "Please Select Transmission";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_color_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_color.SelectedItem == null)
            {
                error_msg.Text = "Please Select Color";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_Ftype_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Ftype.SelectedItem == null)
            {
                error_msg.Text = "Please Select Fuel Type";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_Ecapacity_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Ecapacity.SelectedItem == null)
            {
                error_msg.Text = "Please Select Engine Capacity";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_noPassengers_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_noPassengers.SelectedItem == null)
            {
                error_msg.Text = "Please Select Number of Passengers";
            }
            else { error_msg.Text = ""; }
        }

        private void txt_oPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_oPay.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per month ";
            else if (!Regex.IsMatch(txt_oPay.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void date_InsuranceStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_InsuranceEnd.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_InsuranceStart.Text);
                DateTime exdate = Convert.ToDateTime(date_InsuranceEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid Insurance date.Please check again";
                }
            }
        }

        private void date_InsuranceEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_InsuranceStart.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_InsuranceStart.Text);
                DateTime exdate = Convert.ToDateTime(date_InsuranceEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid Insurance date.Please check again";
                }
            }
        }

        private void date_licenseStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_LicenseEnd.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_licenseStart.Text);
                DateTime exdate = Convert.ToDateTime(date_LicenseEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid License date.Please check again";
                }
            }
        }

        private void date_LicenseEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_licenseStart.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_licenseStart.Text);
                DateTime exdate = Convert.ToDateTime(date_LicenseEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid License date.Please check again";
                }
            }
        }

        private void txt_Lplate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Lplate.Text.Length == 0)
            {
                error_msg.Text = "Please Enter the License Plate Number";
            }
            else { error_msg.Text = ""; }
        }

        private void date_lend_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_lend.SelectedDate ==null)
            {
                error_msg.Text = "Please Select a Lend Date";
            }
            else { error_msg.Text = ""; }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {

                    string name = System.IO.Path.GetFileName(filepath);
                    string destinationPath = GetDestinationPath(name);
                    Vehicle vehicle = new Vehicle(txt_Lplate.Text, txt_catagory.Text, cmb_color.Text, destinationPath, cmb_trans.Text, Int32.Parse(cmb_Ecapacity.Text), Int32.Parse(cmb_noPassengers.Text), date_licenseStart.Text, date_LicenseEnd.Text, date_InsuranceEnd.Text, date_InsuranceStart.Text, cmb_Ftype.Text, date_lend.Text, Int32.Parse(txt_oPay.Text), txt_wName.Text, txt_wAdd.Text, Int32.Parse(txt_wContact.Text));
                    int i = vehicle.addVehicle(modelID, insID, cmb_ownerNIC.Text);
                    if (i == 1)
                    {
                        File.Copy(filepath, destinationPath, true);
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Data Saved Successfully");
                        msg.Show();
                        btn_cls_Click(this, null);
                        btn_remove_Click(this, null);
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Could not save data,Please try again");
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
    }
}
