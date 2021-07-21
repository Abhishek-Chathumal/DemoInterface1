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
    public partial class RViewServiceHistory : MetroFramework.Forms.MetroForm
    {
        public RViewServiceHistory()
        {
            InitializeComponent();
        }

        private void RViewServiceHistory_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthBefore = today.AddDays(-31);
            date_start.Text = monthBefore.ToString();

            CrystalReports.crvService serv = new CrystalReports.crvService();
            serv.SetParameterValue("@start", monthBefore.ToShortDateString());
            serv.SetParameterValue("@end", today.ToShortDateString());
            crvService.ReportSource = null;
            crvService.ReportSource = serv;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(date_start.Text);
            DateTime end = Convert.ToDateTime(date_end.Text);

            CrystalReports.crvService serv = new CrystalReports.crvService();
            serv.SetParameterValue("@start", start.ToShortDateString());
            serv.SetParameterValue("@end", end.ToShortDateString());
            crvService.ReportSource = null;
            crvService.ReportSource = serv;
        }
    }
}
