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
    public partial class RViewAccidentHistory : MetroFramework.Forms.MetroForm
    {
        public RViewAccidentHistory()
        {
            InitializeComponent();
        }

        private void RViewAccidentHistory_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthBefore = today.AddDays(-31);
            date_start.Text = monthBefore.ToString();

            CrystalReports.crvAccident acc = new CrystalReports.crvAccident();
            acc.SetParameterValue("@start", monthBefore.ToShortDateString());
            acc.SetParameterValue("@end", today.ToShortDateString());
            crvAccident.ReportSource = null;
            crvAccident.ReportSource = acc;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(date_start.Text);
            DateTime end = Convert.ToDateTime(date_end.Text);

            CrystalReports.crvAccident acc = new CrystalReports.crvAccident();
            acc.SetParameterValue("@start", start.ToShortDateString());
            acc.SetParameterValue("@end", end.ToShortDateString());
            crvAccident.ReportSource = null;
            crvAccident.ReportSource = acc;
        }
    }
}
