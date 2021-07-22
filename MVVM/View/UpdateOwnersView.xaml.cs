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
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for UpdateOwnersView.xaml
    /// </summary>
    public partial class UpdateOwnersView : UserControl
    {
        public UpdateOwnersView()
        {
            InitializeComponent();
            loadData();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Owner owner = new Owner();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\Owners\\" + cmb_onic.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_onic.Text + ".jpg");
            return appStartPath;
        }
        public void loadData()
        {
            dt = owner.viewOwner();
            cmb_onic.ItemsSource = dt.DefaultView;
            cmb_onic.DisplayMemberPath = "NIC";
            cmb_onic.SelectedValuePath = "NIC";
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

        private void cmb_onic_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_onic.SelectedItem == null)
                {
                    error_msg.Text = "Please Select NIC";
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = owner.viewOwner(cmb_onic.Text);
                    txt_OwnFname.Text = dt.Rows[0][1].ToString();
                    txt_OwnLname.Text = dt.Rows[0][2].ToString();
                    txt_OwnEmail.Text = dt.Rows[0][9].ToString();
                    string[] fields = seperateAddress(dt.Rows[0][3].ToString());
                    txt_OwnHouseNo.Text = fields[0];
                    txt_OwnStreetNme.Text = fields[1];
                    txt_OwnCity.Text = fields[2];
                    txt_OwnTelHome.Text = dt.Rows[0][4].ToString();
                    txt_OwnTelMobile.Text = dt.Rows[0][5].ToString();
                    txt_OwnProfession.Text = dt.Rows[0][6].ToString();
                    fields = seperateAddress(dt.Rows[0][7].ToString());
                    txt_OwnWorkInstitute.Text = fields[0];
                    txt_OwnWorkStrNme.Text = fields[1];
                    txt_OwnWorkCity.Text = fields[2];
                    txt_OwnTelWork.Text = dt.Rows[0][8].ToString();
                    path = dt.Rows[0][10].ToString();
                    if (path != "")
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = new Uri(path);
                        image.EndInit();
                        img_owner.Source = image;

                    }
                    else
                    {
                        img_owner.Source = null;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Photo could not be located");
                msg.Show();
                img_owner.Source = null;
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
                    img_owner.Source = imgsource;
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
            img_owner.Source = null;
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_OwnFname.Clear();
            txt_OwnLname.Clear();
            txt_OwnEmail.Clear();
            txt_OwnHouseNo.Clear();
            txt_OwnStreetNme.Clear();
            txt_OwnCity.Clear();
            txt_OwnTelHome.Clear();
            txt_OwnTelMobile.Clear();
            txt_OwnProfession.Clear();
            txt_OwnWorkInstitute.Clear();
            txt_OwnWorkStrNme.Clear();
            txt_OwnWorkCity.Clear();
            txt_OwnTelWork.Clear();
            img_owner.Source = null;
            cmb_onic.Text = "";
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
                    Owner owner = new Owner(txt_OwnFname.Text, txt_OwnLname.Text, cmb_onic.Text, getAddress(txt_OwnHouseNo.Text, txt_OwnStreetNme.Text, txt_OwnCity.Text), getAddress(txt_OwnWorkInstitute.Text, txt_OwnWorkStrNme.Text, txt_OwnWorkCity.Text), txt_OwnEmail.Text, Int32.Parse(txt_OwnTelMobile.Text), Int32.Parse(txt_OwnTelHome.Text), Int32.Parse(txt_OwnTelWork.Text), txt_OwnProfession.Text, destinationPath);
                    int i = owner.updateOwner();
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int i = owner.deleteOwner(cmb_onic.Text);
            if (i == 1)
            {
                String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                string dir = appStartPath + "\\Owners\\" + cmb_onic.Text;
                var folder = new DirectoryInfo(dir);
                if (Directory.Exists(dir))
                {
                    folder.Delete(true);
                }
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Data deleted successfully");
                msg.Show();
                btn_remove_Click(this, null);
                btn_cls_Click(this, null);
                loadData();
            }
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Could not save data,Please try agian");
                msg.Show();
            }
        }

        private void txt_OwnFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnFname.Text.Length == 0)
                error_msg.Text = "Please Enter Owner First Name  ";
            else if (!Regex.IsMatch(txt_OwnFname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Invalid First Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnLname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnLname.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Last Name  ";
            else if (!Regex.IsMatch(txt_OwnLname.Text, @"^[A-Za-z]+$"))
                error_msg.Text = "Invalid Last Name";
            error_msg.Text = "";
        }

        private void txt_OwnEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_OwnEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Email";
            else if (!IsValid(txt_OwnEmail.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelHome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelHome.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Home Number ";
            else if (!Regex.IsMatch(txt_OwnTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Mobile Number ";
            else if (!Regex.IsMatch(txt_OwnTelMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnStreetNme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnStreetNme.Text.Length == 0)
                error_msg.Text = "Please Enter Street Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnCity.Text.Length == 0)
                error_msg.Text = "Please Enter City Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Profession";
            else
                error_msg.Text = "";
        }

        private void txt_OwnWorkInstitute_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnWorkInstitute.Text.Length == 0)
                error_msg.Text = "Please Enter Institute Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnWorkStrNme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnWorkStrNme.Text.Length == 0)
                error_msg.Text = "Please Enter Work Street Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnWorkCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnWorkCity.Text.Length == 0)
                error_msg.Text = "Please Enter Work City Name";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelWork.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Work Number ";
            else if (!Regex.IsMatch(txt_OwnTelWork.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnHouseNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnHouseNo.Text.Length == 0)
                error_msg.Text = "Please Enter House Number";
            else
                error_msg.Text = "";
        }
    }
}
