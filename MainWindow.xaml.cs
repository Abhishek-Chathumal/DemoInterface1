using System.Windows;
using System.Windows.Input;

namespace DemoInterface1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string utype, string uname)
        {
            InitializeComponent();
            //lbl_user.Text = uname;
            /*if (utype == "Manager")
            {
                list_report.Visibility = Visibility.Visible;
                list_accounts.Visibility = Visibility.Visible;
            }*/
        }


        private void Btn_Menu_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}
