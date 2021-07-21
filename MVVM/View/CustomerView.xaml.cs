using DemoInterface1.MVVM.ModelView;
using System.Windows;
using System.Windows.Controls;

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
        CustomerViewModel obj = new CustomerViewModel();


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
