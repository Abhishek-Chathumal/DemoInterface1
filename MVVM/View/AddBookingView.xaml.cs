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
    /// Interaction logic for AddBookingView.xaml
    /// </summary>
    public partial class AddBookingView : UserControl
    {
        public AddBookingView()
        {
            InitializeComponent();
            loadData();
        }
        DataTable dt = new DataTable();
        Database db = new Database();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        Booking book = new Booking();
        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_vLplate.ItemsSource = dt.DefaultView;
            cmb_vLplate.DisplayMemberPath = "Plate No";
            cmb_vLplate.SelectedValuePath = "Plate No";

            dt = customer.viewCustomer();
            cmb_cNIC.ItemsSource = dt.DefaultView;
            cmb_cNIC.DisplayMemberPath = "NIC";
            cmb_cNIC.SelectedValuePath = "NIC";

            book_date.Text = DateTime.Now.ToShortDateString();

            dt = db.getData("Select max(bookingID) from Booking ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_bid.Text = "B001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_bid.Text = newString;
            }
        }

        private void cmb_cNIC_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_cNIC.SelectedIndex != -1)
                {
                    txt_error.Text = "";
                    dt = customer.viewCustomer(cmb_cNIC.Text);
                    txt_cName.Text = dt.Rows[0][1].ToString();
                }
                else
                    txt_error.Text = "Please select a customer NIC";
            }
            catch (IndexOutOfRangeException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please select a customer NIC");
                msg.Show();
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void cmb_vLplate_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_vLplate.SelectedIndex != -1)
                {
                    txt_error.Text = "";
                    dt = vehicle.viewVehicle(cmb_vLplate.Text);
                    string model = dt.Rows[0][1].ToString();
                    ModelPricing mp = new ModelPricing();
                    dt = mp.viewPricing(model);
                    txt_vYear.Text = dt.Rows[0][2].ToString();
                    txt_vMake.Text = dt.Rows[0][3].ToString();
                    txt_vModel.Text = dt.Rows[0][4].ToString();
                }
                else
                    txt_error.Text = "Please select a Vehicle";
            }
            catch (IndexOutOfRangeException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please select a vehicle");
                msg.Show();
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void txt_advance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_advance.Text, @"^[1-9]\d*$"))
                txt_error.Text = "Invalid Amount";
            else
                txt_error.Text = "";
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
                    txt_error.Text = "";
                }
                else
                {
                    txt_error.Text = "Invalid return date.Please check again";
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
                    txt_error.Text = "";
                }
                else
                {
                    txt_error.Text = "Invalid return date.Please check again";
                }
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_cNIC.SelectedIndex = -1;
            txt_cName.Clear();
            cmb_vLplate.SelectedIndex = -1;
            txt_vYear.Clear();
            txt_vMake.Clear();
            txt_vModel.Clear();
            txt_advance.Clear();
            dte_lend.SelectedDate = null;
            dte_return.SelectedDate = null;
            loadData() ;
            txt_error.Text = "";
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_error.Text == "")
            {
                try
                {
                    Booking book = new Booking(txt_bid.Text, book_date.Text, dte_lend.Text, dte_return.Text, Int32.Parse(txt_advance.Text));
                    int i = book.addBooking(cmb_cNIC.Text, cmb_vLplate.Text);
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.informationMsg("Data Saved Successfully");
                        msg.Show();
                        btn_bill.IsEnabled = true;                      
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Could not save data,Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly");
                    msg.Show();
                }
                catch (FormatException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form properly");
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
            ExternalForms.BillPrint bill = new ExternalForms.BillPrint(txt_bid.Text);
            bill.Show();
        }
    }
}
