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

namespace DemoInterface1.ExternalForms
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public Message()
        {
            InitializeComponent();
        }
        public void errorMsg(string msg)
        {
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
            txt_msg.Text = msg;
        }
        public void informationMsg(string msg)
        {
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.InfoCircle;
            txt_msg.Text = msg;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
