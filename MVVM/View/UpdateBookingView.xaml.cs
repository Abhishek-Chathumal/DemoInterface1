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
using System.Text.RegularExpressions;


namespace DemoInterface1.MVVM.View
{
    /// <summary>
    /// Interaction logic for UpdateBookingView.xaml
    /// </summary>
    public partial class UpdateBookingView : UserControl
    {
        public UpdateBookingView()
        {
            InitializeComponent();
            loadData();
        }
        DataTable dt = new DataTable();
        Booking booking = new Booking();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        string vplate;

        public void loadData()
        {
            dt = booking.viewBooking();
            cmb_bid.ItemsSource = dt.DefaultView;
            cmb_bid.DisplayMemberPath = "bookingID";
            cmb_bid.SelectedValuePath = "bookingID";

            dt = vehicle.viewVehicle();
            cmb_vLplate.ItemsSource = dt.DefaultView;
            cmb_vLplate.DisplayMemberPath = "Plate No";
            cmb_vLplate.SelectedValuePath = "Plate No";

            dt = customer.viewCustomer();
            cmb_cNIC.ItemsSource = dt.DefaultView;
            cmb_cNIC.DisplayMemberPath = "NIC";
            cmb_cNIC.SelectedValuePath = "NIC";

            /*cmb_bid.SelectedIndex = -1;
            cmb_cNIC.SelectedIndex = -1;
            txt_cName.Clear();
            cmb_vLplate.SelectedIndex = -1;
            txt_vYear.Clear();
            txt_vMake.Clear();
            txt_vModel.Clear();
            txt_advance.Clear();
            dte_lend.SelectedDate = null;
            dte_return.SelectedDate = null;
            error_msg.Text = "";*/

            book_date.Text = DateTime.Now.ToString();
        }

        private void cmb_bid_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_bid.SelectedItem == null)
            {
                error_msg.Text = "Please Select Booking ID";
            }
            else
            {
                btn_bill.IsEnabled = true;
                dt = booking.viewBookingID(cmb_bid.Text);
                txt_advance.Text = dt.Rows[0][4].ToString();
                dte_lend.Text = dt.Rows[0][2].ToString();
                dte_return.Text = dt.Rows[0][3].ToString();
                dt = booking.viewCustomerBooking(cmb_bid.Text);
                cmb_cNIC.Text = dt.Rows[0][1].ToString();
                cmb_vLplate.Text = dt.Rows[0][2].ToString();
                vplate = dt.Rows[0][2].ToString();
                cmb_cNIC_DropDownClosed(this, null);
                cmb_vLplate_DropDownClosed(this, null);
            }
        }

        private void cmb_cNIC_DropDownClosed(object sender, EventArgs e)
        {           
            dt = customer.viewCustomer(cmb_cNIC.Text);
            txt_cName.Text = dt.Rows[0][1].ToString();
        }

        private void cmb_vLplate_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_bid.SelectedIndex != -1)
            {

                dt = vehicle.viewVehicle(cmb_vLplate.Text);
                string model = dt.Rows[0][1].ToString();
                ModelPricing mp = new ModelPricing();
                dt = mp.viewPricing(model);
                txt_vYear.Text = dt.Rows[0][2].ToString();
                txt_vMake.Text = dt.Rows[0][3].ToString();
                txt_vModel.Text = dt.Rows[0][4].ToString();
            }
            else
            {
                error_msg.Text = "Please select a vehicle";
            }
        }

        private void txt_advance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_advance.Text, @"^[1-9]\d*$"))
                error_msg.Text = "Invalid Amount";
            else
                error_msg.Text = "";
        }

        private void dte_lend_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dte_return.Text != "")
            {
                DateTime lenddate = Convert.ToDateTime(dte_lend.Text);
                DateTime returndate = Convert.ToDateTime(dte_return.Text);
                if (lenddate <= returndate)
                {
                    TimeSpan ts = returndate.Subtract(lenddate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid return date.Please check again";
                }
            }
        }

        private void dte_return_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dte_lend.Text != "")
            {
                DateTime lenddate = Convert.ToDateTime(dte_lend.Text);
                DateTime returndate = Convert.ToDateTime(dte_return.Text);
                if (lenddate <= returndate)
                {
                    TimeSpan ts = returndate.Subtract(lenddate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid return date.Please check again";
                }
            } 
        }

        public void clearScreen()
        {

            cmb_bid.SelectedIndex = -1;
            cmb_cNIC.SelectedIndex = -1;
            txt_cName.Clear();
            cmb_vLplate.SelectedIndex = -1;
            txt_vYear.Clear();
            txt_vMake.Clear();
            txt_vModel.Clear();
            txt_advance.Clear();
            dte_lend.SelectedDate = null;
            dte_return.SelectedDate = null;
            error_msg.Text = "";
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {
                    Booking book = new Booking(cmb_bid.Text, book_date.Text, dte_lend.Text, dte_return.Text, Int32.Parse(txt_advance.Text));
                    int i = book.updateBooking(cmb_cNIC.Text, cmb_vLplate.Text);
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.informationMsg("Data updated successfully!");
                        msg.Show();
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Could not save data,Please try agian");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly");
                    msg.Show();
                }
                catch (Exception ex)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Oops something went worng. " + ex.Message);
                    msg.Show();
                }

            }
        }

        private void btn_bill_Click(object sender, RoutedEventArgs e)
        {
            ExternalForms.BillPrint bill = new ExternalForms.BillPrint(cmb_bid.Text);
            bill.Show();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = booking.deleteBooking(cmb_bid.Text, cmb_cNIC.Text, vplate);
                if (i == 1)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.informationMsg("Data Deleted successfully!");
                    msg.Show();
                    loadData();
                    clearScreen();
                }
                else
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Could not delete data,Please try agian");
                    msg.Show();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the form correctly");
                msg.Show();
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }
    }
}
