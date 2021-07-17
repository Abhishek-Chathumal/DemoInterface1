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
using System.Net;
using System.Net.Mail;

namespace DemoInterface1.ExternalForms
{
    /// <summary>
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }
        string email, randomCode;
        public static string to;

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(txt_uname.Text);
            try
            {
                email = user.getEmail();
                sendEmail();
                txt_vcode.IsEnabled = true;
                btn_verify.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Message msg = new Message();
                msg.errorMsg("Invalid username.Please try again");
                msg.Show();
            }
        }

        private void btn_verify_Click(object sender, RoutedEventArgs e)
        {
            if (txt_vcode.Text == randomCode.ToString())
            {
                /*manageAccount ma = new manageAccount(txt_uname.Text);
                ma.Show();*/
            }
            else
            {
                Message msg = new Message();
                msg.errorMsg("Invalid Code.Please try again");
                msg.Show();
            }
        }

        public void sendEmail()
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = email;
            from = "malshirent@gmail.com";
            pass = "Malshirent@1";
            messageBody = "You rest code is " + randomCode;
            message.To.Add(new MailAddress(to));
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Malshi RCMS - Password Reset Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                tblock_msg.Text = "An verification has been sent to your email " + email + " Please input the verification code to rest your password";
            }
            catch (Exception ex)
            {
                Message msg = new Message();
                msg.errorMsg(ex.Message);
                msg.Show();
            }

        }
    }
}
