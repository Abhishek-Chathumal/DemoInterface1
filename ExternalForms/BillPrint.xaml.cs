using System;
using System.Collections.Generic;
using System.Data;
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
using System.Text.RegularExpressions;

namespace DemoInterface1.ExternalForms
{
    /// <summary>
    /// Interaction logic for BillPrint.xaml
    /// </summary>
    public partial class BillPrint : Window
    {
        public BillPrint()
        {
            InitializeComponent();
        }
        public BillPrint(string bid)
        {
            InitializeComponent();
            txt_bid.Text = bid;
        }

        DataTable dt = new DataTable();
        Database db = new Database();
        Booking booking = new Booking();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        int shortRent, longRent, extra;

        private void form_bill_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_billDate.Content = DateTime.Now.ToString();
            dt = db.getData("Select max(bill_ID) from Billing");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                lbl_billID.Content = "BL001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                lbl_billID.Content = newString;
            }

            dt = booking.viewBillForm(txt_bid.Text);
            txt_cnic.Text = dt.Rows[0][2].ToString();
            txt_bdate.Text = Convert.ToDateTime(dt.Rows[0][1].ToString()).ToShortDateString();
            txt_fname.Text = dt.Rows[0][3].ToString();
            txt_lname.Text = dt.Rows[0][4].ToString();
            txt_lplate.Text = dt.Rows[0][5].ToString();
            txt_year.Text = dt.Rows[0][6].ToString();
            txt_make.Text = dt.Rows[0][7].ToString();
            txt_model.Text = dt.Rows[0][8].ToString();
            txt_lend.Text = Convert.ToDateTime(dt.Rows[0][10].ToString()).ToShortDateString();
            txt_pickup.Text = Convert.ToDateTime(dt.Rows[0][9].ToString()).ToShortDateString();
            txt_adv.Text = dt.Rows[0][14].ToString();
            shortRent = Int32.Parse(dt.Rows[0][11].ToString());
            longRent = Int32.Parse(dt.Rows[0][12].ToString());
            extra = Int32.Parse(dt.Rows[0][13].ToString());

            System.TimeSpan diff = Convert.ToDateTime(txt_pickup.Text) - Convert.ToDateTime(txt_lend.Text);
            int days = diff.Days;
            int months = days / 30;
            txt_months.Text = (days / 30).ToString();
            if (days < 90)
            {
                txt_rent.Text = shortRent.ToString();
                txt_tot_rent.Text = (shortRent * months).ToString();
            }
            else
            {
                txt_rent.Text = longRent.ToString();
                txt_tot_rent.Text = (longRent * months).ToString();
            }
        }
        private void txt_used_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txt_used.Text != "" && txt_allocated.Text != "")
                {
                    if (!Regex.IsMatch(txt_months.Text, "^[0-9]*$"))
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Please enter a valid usage");
                        msg.Show();
                        txt_months.Clear();
                    }
                    else if ((Int32.Parse(txt_used.Text) - Int32.Parse(txt_allocated.Text)) > 0)
                    {
                        txt_extraM.Text = (Int32.Parse(txt_used.Text) - Int32.Parse(txt_allocated.Text)).ToString();
                        txt_extraC.Text = (Int32.Parse(txt_extraM.Text) * extra).ToString();
                    }
                    else
                    {
                        txt_extraM.Text = "0";
                        txt_extraC.Text = "0";
                    }
                }
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

        private void btn_print_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new Bill(lbl_billID.Content.ToString(), lbl_billDate.Content.ToString(), Int32.Parse(txt_extraC.Text), cmb_method.Text);
            int i = bill.addBill(txt_bid.Text, txt_lplate.Text);
            if (i == 1)
            {
                btn_cal.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, lbl_billID.Content.ToString());
                }
            }
            else
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the form properly");
                msg.Show();
            }

        }

        private void txt_months_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_months.Text != "")
            {
                if (!Regex.IsMatch(txt_months.Text, "^[0-9]*$"))
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please enter a valid no of months");
                    msg.Show();
                    txt_months.Clear();
                }
                else if (Int32.Parse(txt_months.Text) <= 3)
                {
                    txt_rent.Text = shortRent.ToString();
                    txt_tot_rent.Text = (shortRent * Int32.Parse(txt_months.Text)).ToString();
                }
                else
                {
                    txt_rent.Text = longRent.ToString();
                    txt_tot_rent.Text = (longRent * Int32.Parse(txt_months.Text)).ToString();
                }
            }

        }

        private void txt_allocated_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_allocated.Text, "^[0-9]*$"))
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please enter a valid allocated milage");
                msg.Show();
                txt_allocated.Clear();
            }
        }

        private void txt_rent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(txt_rent.Text, "^[0-9]*$"))
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please enter a valid rent cost");
                msg.Show();
                txt_rent.Clear();
            }
        }

        private void btn_cal_Click(object sender, RoutedEventArgs e)
        {
            if (txt_tot_rent.Text != "" && txt_extraC.Text != "")
            {
                txt_totCost.Text = (Int32.Parse(txt_tot_rent.Text) + Int32.Parse(txt_extraC.Text)).ToString();
                txt_due.Text = (Int32.Parse(txt_totCost.Text) - Int32.Parse(txt_adv.Text)).ToString();
            }
        }
    }
}
