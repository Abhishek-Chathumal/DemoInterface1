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

        private void cmb_nic_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_nic.SelectedItem == null)
            {
                //error_msg.Text = "Please Select NIC";
            }

            else
            {
                dt = customer.viewCustomerNIC(cmb_nic.Text);

                // cmb_nic.Text = dt.Rows[0][0].ToString();
                txt_CusFname.Text = dt.Rows[0][1].ToString();
                txt_CusLname.Text = dt.Rows[0][2].ToString();
                txt_CusResAdrs.Text = dt.Rows[0][3].ToString();
                txt_CusWorkAdrs.Text = dt.Rows[0][8].ToString();
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
               /* MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();*/
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cmb_nic.SelectedIndex = -1;
            txt_CusFname.Clear();
            txt_CusLname.Clear();
            txt_CusResAdrs.Clear();
            txt_CusWorkAdrs.Clear();
            txt_CusTelHome.Clear();
            txt_CusTelMobile.Clear();
            txt_CusTelWork.Clear();
            txt_CusEmail.Clear();
            txt_CusProfession.Clear();
            txt_CusKinName.Clear();
            txt_CusKinkAdrs.Clear();
            txt_CusKinConatct.Clear();
        }
    }
}
