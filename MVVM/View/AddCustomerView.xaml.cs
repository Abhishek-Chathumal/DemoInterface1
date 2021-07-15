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
            txt_cusResAddress.Clear();
            txt_cusHomeTel.Clear();
            txt_cusMobile.Clear();
            txt_cusProfession.Clear();
            txt_cusWorkAddrs.Clear();
            txt_cusWorkTel.Clear();
            txt_kinName.Clear();
            txt_kinAddrs.Clear();
            txt_kinCntkt.Clear();
        }
    }
}
