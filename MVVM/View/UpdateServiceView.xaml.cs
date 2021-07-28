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
    /// Interaction logic for UpdateServiceView.xaml
    /// </summary>
    public partial class UpdateServiceView : UserControl
    {
        public UpdateServiceView()
        {
            InitializeComponent();
            loadData();
        }
        Vehicle vehicle = new Vehicle();
        Service service = new Service();
        DataTable dt = new DataTable();

        public void loadData()
        {
            dt = vehicle.viewVehicle();
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "Plate No";
            cmb_vid.SelectedValuePath = "Plate No";

            dt = service.viewService();
            cmb_sID.ItemsSource = dt.DefaultView;
            cmb_sID.DisplayMemberPath = "Service ID";
            cmb_sID.SelectedValuePath = "Service ID";
            
        }

        private void cmb_sID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_sID.SelectedItem == null)
            {
                error_msg.Text = "Please Select SID";
            }
            else
            {
                dt = service.viewServiceID(cmb_sID.Text);
                cmb_vid.Text = dt.Rows[0][0].ToString();
                txt_details.Text = dt.Rows[0][2].ToString();
                txt_sLocation.Text = dt.Rows[0][3].ToString();
                dte_service.Text = dt.Rows[0][4].ToString();
                txt_mileage.Text = dt.Rows[0][5].ToString();
                txt_nxtMileage.Text = dt.Rows[0][6].ToString();
                txt_sCost.Text = dt.Rows[0][7].ToString();
            }
        }

        private void cmb_vid_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_vid.SelectedItem == null)
            {
                error_msg.Text = "Please SelectVehicle ID";
            }
            else { error_msg.Text = ""; }
        }

        private void dte_service_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (dte_service.Text == null)
                error_msg.Text = "Please enter a serviced date";
            else
                error_msg.Text = "";
        }

        private void txt_mileage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(txt_mileage.Text, "^[0-9]*$"))
                    error_msg.Text = "Please enter numbers only";
                else if (txt_mileage.Text != "")
                {
                    error_msg.Text = "";
                    int next = Int32.Parse(txt_mileage.Text);
                    txt_nxtMileage.Text = (next + 2500).ToString();
                }
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the form properly " + ex.Message);
                msg.Show();
            }
        }

        private void txt_sLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sLocation.Text.Length == 0)
                error_msg.Text = "Please Enter Location ";
            else
                error_msg.Text = "";
        }

        private void txt_sCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sCost.Text.Length == 0)
                error_msg.Text = "Please Enter cost";
            else if (!Regex.IsMatch(txt_sCost.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_nxtMileage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_nxtMileage.Text.Length == 0)
                error_msg.Text = "Please Enter Next Milage";
            else if (!Regex.IsMatch(txt_nxtMileage.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {
        if (txt_details.Text.Length == 0)
            error_msg.Text = "Please Enter Details";
        else
            error_msg.Text = "";
    }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
           txt_sLocation.Clear();
           txt_mileage.Clear();
           dte_service.SelectedDate = null;
           txt_nxtMileage.Clear();
           txt_sCost.Clear();
           txt_details.Clear();
           cmb_vid.SelectedIndex = -1;
           cmb_sID.SelectedIndex = -1;
           error_msg.Text = "";
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = service.deleteService(cmb_sID.Text);
                if (i == 1)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.Show();
                    loadData();
                    btn_cls_Click(this, null);
                }
                else
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Sorry, couldn't delete your data.Please try again");
                    msg.Show();

                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Please fill the form correctly.");
                msg.Show();
            }
            catch (Exception ex)
            {
                ExternalForms.Message msg = new ExternalForms.Message();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text == "")
            {
                try
                {
                    Service upService = new Service(cmb_sID.Text, txt_details.Text, txt_sLocation.Text, dte_service.Text, Int32.Parse(txt_mileage.Text), Int32.Parse(txt_nxtMileage.Text), Int32.Parse(txt_sCost.Text));
                    int i = upService.updateService(cmb_vid.Text);
                    if (i == 1)
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Data updated successfully!");
                        msg.Show();
                    }
                    else
                    {
                        ExternalForms.Message msg = new ExternalForms.Message();
                        msg.errorMsg("Sorry, couldn't save your data.Please try again");
                        msg.Show();
                    }
                }

                catch (System.Data.SqlClient.SqlException)
                {
                    ExternalForms.Message msg = new ExternalForms.Message();
                    msg.errorMsg("Please fill the form correctly.");
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
}
