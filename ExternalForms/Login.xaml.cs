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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            HashCode hc = new HashCode();
            User user = new User(txt_uname.Text, hc.PassHash(txt_pass.Password));
            int i = user.authorizeAccount();
            if (i == 1)
            {
                string type = user.getUserType();
                SplashScreen splash = new SplashScreen(type, txt_uname.Text);
                this.Close();
                splash.Show();
            }
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Sorry,Invalid username or password");
                msg.Show();
            }
        }

        private void lbl_forgot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetPassword obj = new ResetPassword();
            obj.Show();
            this.Close();
        }
    }
}
