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
    public partial class RViewBookingHistory : MetroFramework.Forms.MetroForm
    {
        public RViewBookingHistory()
        {
            InitializeComponent();
        }

        private void RViewBookingHistory_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthBefore = today.AddDays(-31);

            date_start.Text = monthBefore.ToString();

            CrystalReports.crvBooking book = new CrystalReports.crvBooking();
            book.SetParameterValue("@start", monthBefore.ToShortDateString());
            book.SetParameterValue("@end", today.ToShortDateString());
            crvBook.ReportSource = null;
            crvBook.ReportSource = book;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(date_start.Text);
            DateTime end = Convert.ToDateTime(date_end.Text);

            CrystalReports.crvBooking book = new CrystalReports.crvBooking();
            book.SetParameterValue("@start", start.ToShortDateString());
            book.SetParameterValue("@end", end.ToShortDateString());
            crvBook.ReportSource = null;
            crvBook.ReportSource = book;
        }
    }
}
