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
using System.Data;

namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for ViewOwnersView.xaml
    /// </summary>
    public partial class ViewOwnersView : UserControl
    {
        public ViewOwnersView()
        {
            InitializeComponent();
            loadData();
        }
        Owner owner = new Owner();
        DataTable dt = new DataTable();

        public void loadData()
        {
            txt_oNIC.Clear();
            txt_OwnName.Clear();
            dt = owner.viewOwner();
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void btn_searchOwnNIC_Click(object sender, RoutedEventArgs e)
        {
            dt = owner.viewOwner(txt_oNIC.Text);
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void btn_searchOwnName_Click(object sender, RoutedEventArgs e)
        {
            dt = owner.searchOwner(txt_OwnName.Text);
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void txt_oNIC_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_OwnName.Clear();
        }

        private void txt_OwnName_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_oNIC.Clear();
        }
    }
}
