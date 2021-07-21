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
using System.Windows.Threading;

namespace DemoInterface1.ExternalForms
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        String utype, uname;
        public SplashScreen()
        {
            InitializeComponent();
            dT.Tick += new EventHandler(dT_Tick);
            dT.Interval = new TimeSpan(0, 0, 5);
            dT.Start();
        }
        public SplashScreen(string utype, string uname)
        {
            InitializeComponent();

            dT.Tick += new EventHandler(dT_Tick);
            dT.Interval = new TimeSpan(0, 0, 7);
            dT.Start();
            this.utype = utype;
            this.uname = uname;
        }
        private void dT_Tick(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow(utype, uname);
            mw.Show();
            dT.Stop();
            this.Close();
        }
    }
}
