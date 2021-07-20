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
    /// Interaction logic for UpdateVehiclesView.xaml
    /// </summary>
    public partial class UpdateVehiclesView : UserControl
    {
        public UpdateVehiclesView()
        {
            InitializeComponent();
            loadData();
        }
        Database db;
        Vehicle vehicle = new Vehicle();
        ModelPricing model = new ModelPricing();
        DataTable dt = new DataTable();
        Insurance insurance = new Insurance();
        Owner owner = new Owner();
        string insID;
        string path;
        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_plateNo.ItemsSource = dt.DefaultView;
            cmb_plateNo.DisplayMemberPath = "Plate No";
            cmb_plateNo.SelectedValuePath = "Plate No";
            dt = model.viewPricing();
            cmb_modelID.ItemsSource = dt.DefaultView;
            cmb_modelID.DisplayMemberPath = "Model ID";
            cmb_modelID.SelectedValuePath = "Model ID";
            dt = insurance.viewInsurance();
            cmb_ins.ItemsSource = dt.DefaultView;
            cmb_ins.DisplayMemberPath = "insName";
            cmb_ins.SelectedValuePath = "insName";
            dt = owner.viewOwner();
            cmb_ownerNIC.ItemsSource = dt.DefaultView;
            cmb_ownerNIC.DisplayMemberPath = "NIC";
            cmb_ownerNIC.SelectedValuePath = "NIC";
        }
        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\Vehicles\\" + cmb_plateNo.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_plateNo.Text + ".jpg");
            return appStartPath;
        }

        private void cmb_plateNo_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_plateNo.SelectedItem == null)
                {
                    error_msg.Text = "Please Select Vehicle Number";
                }
                else
                {
                    dt = vehicle.viewVehicle(cmb_plateNo.Text);
                    cmb_modelID.Text = dt.Rows[0][1].ToString();
                    cmb_category.Text = dt.Rows[0][2].ToString();
                    txt_year.Text = dt.Rows[0][3].ToString();
                    txt_make.Text = dt.Rows[0][4].ToString();
                    txt_model.Text = dt.Rows[0][5].ToString();
                    cmb_color.Text = dt.Rows[0][6].ToString();
                    cmb_trans.Text = dt.Rows[0][7].ToString();
                    cmb_Ecapacity.Text = dt.Rows[0][8].ToString();
                    cmb_Ftype.Text = dt.Rows[0][9].ToString();
                    cmb_noPassengers.Text = dt.Rows[0][10].ToString();
                    //insID = dt.Rows[0][].ToString();
                    path = dt.Rows[0][25].ToString();
                    date_licenseStart.Text = dt.Rows[0][12].ToString();
                    date_LicenseEnd.Text = dt.Rows[0][13].ToString();
                    cmb_ins.Text = dt.Rows[0][15].ToString();
                    date_InsuranceStart.Text = dt.Rows[0][16].ToString();
                    date_InsuranceEnd.Text = dt.Rows[0][17].ToString();
                    cmb_ownerNIC.Text = dt.Rows[0][18].ToString();
                    txt_oName.Text = dt.Rows[0][19].ToString();
                    date_lend.Text = dt.Rows[0][20].ToString();
                    txt_oPay.Text = dt.Rows[0][21].ToString();
                    txt_wName.Text = dt.Rows[0][22].ToString();
                    txt_wAdd.Text = dt.Rows[0][23].ToString();
                    txt_wContact.Text = dt.Rows[0][24].ToString();
                    cmb_ins_DropDownClosed(this, null);

                    if (path != "")
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = new Uri(path);
                        image.EndInit();
                        img_vehicle.Source = image;
                    }
                    else
                    {
                        img_vehicle.Source = null;
                    }
                }
            }
            catch (FileNotFoundException Ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Photo could not be located");
                msg.Show();
                img_vehicle.Source = null;
            }
            catch (Exception Ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops something went wrong" + Ex.Message);
                msg.Show();
            }
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

        private void cmb_modelID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_modelID.SelectedItem == null)
            {
                error_msg.Text = "Please Select Model";
            }
            else
            {
                dt = model.viewPricing(cmb_modelID.Text);
                //modelID = dt.Rows[0][0].ToString();
                cmb_category.Text = dt.Rows[0][1].ToString();
                txt_make.Text = dt.Rows[0][3].ToString();
                txt_model.Text = dt.Rows[0][4].ToString();
                txt_year.Text = dt.Rows[0][2].ToString();
            }
        }

        private void cmb_ins_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ins.SelectedItem == null)
            {
                error_msg.Text = "Please Select Company";
            }
            else
            {
                dt = insurance.viewInsurance(cmb_ins.Text);
                insID = dt.Rows[0][0].ToString();
            }
        }

        private void cmb_ownerNIC_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ownerNIC.SelectedItem == null)
            {
                error_msg.Text = "Please Select Owner NIC";
            }
            else
            {
                dt = owner.viewOwner(cmb_ownerNIC.Text);
                txt_oName.Text = dt.Rows[0][1].ToString();
            }
        }

        private void txt_wName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wName.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Name";
            else if (txt_wName.Text.Any(char.IsDigit))
                error_msg.Text = "Witness Name cannot have Numbers";
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

        private void date_lend_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_lend.SelectedDate == null)
            {
                error_msg.Text = "Please Select a Lend Date";
            }
            else { error_msg.Text = ""; }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            img_vehicle.Source = null;
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_modelID.SelectedIndex = -1;
            cmb_category.SelectedIndex = -1;
            txt_make.Clear();
            txt_model.Clear();
            cmb_color.SelectedIndex = -1;
            txt_year.Clear();
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
           /* try
            {*/
                int i = vehicle.deleteVehicle(cmb_plateNo.Text);
                if (i == 1)
                {
                    String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    string dir = appStartPath + "\\Vehicles\\" + cmb_plateNo.Text;
                    var folder = new DirectoryInfo(dir);
                    if (Directory.Exists(dir))
                    {
                        folder.Delete(true);
                    }
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Data deleted successfully!");
                    msg.Show();
                    btn_cls_Click(this, null);
                    btn_remove_Click(this, null);
                    loadData();
                }
                else
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Could not delete data,Please try agian");
                    msg.Show();
                }
            /*}
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
            }*/

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {
                    string name = System.IO.Path.GetFileName(path);
                    string destinationPath = GetDestinationPath(name);
                    Vehicle vehicle = new Vehicle(cmb_plateNo.Text, cmb_category.Text, cmb_color.Text, destinationPath, cmb_trans.Text, Int32.Parse(cmb_Ecapacity.Text), Int32.Parse(cmb_noPassengers.Text), date_licenseStart.Text, date_LicenseEnd.Text, date_InsuranceEnd.Text, date_InsuranceStart.Text, cmb_Ftype.Text, date_lend.Text, Int32.Parse(txt_oPay.Text), txt_wName.Text, txt_wAdd.Text, Int32.Parse(txt_wContact.Text));
                    int i = vehicle.updateVehicle(cmb_modelID.Text, insID, cmb_ownerNIC.Text);
                    if (i == 1)
                    {
                        File.Copy(path, destinationPath, true);
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.informationMsg("Data updated successfully!");
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
        }
    }
}
