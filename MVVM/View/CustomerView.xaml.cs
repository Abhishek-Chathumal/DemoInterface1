using DemoInterface1.MVVM.ModelView;
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

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }
        Database db = new Database();

        private void rBtn_cusUpdte_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rBtn_cusAdd_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rBtn_cusView_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
