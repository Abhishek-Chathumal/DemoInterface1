using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoInterface1.Reports
{
    public partial class RViewCustomerBooking : MetroFramework.Forms.MetroForm
    {
        public RViewCustomerBooking()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Customer customer = new Customer();

        private void RViewCustomerBooking_Load(object sender, EventArgs e)
        {
            dt = customer.viewCustomer();
            cmb_cus.DataSource = dt.DefaultView;
            cmb_cus.DisplayMember = "NIC";
            cmb_cus.ValueMember = "NIC";
        }
        private void cmb_cus_DropDownClosed(object sender, EventArgs e)
        {
            CrystalReports.crvCustomerBookings cusBK = new CrystalReports.crvCustomerBookings();
            cusBK.SetParameterValue("@cno", cmb_cus.Text);
            crvCustomerBooking.ReportSource = null;
            crvCustomerBooking.ReportSource = cusBK;
        }
    }
}
