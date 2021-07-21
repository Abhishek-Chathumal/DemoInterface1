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
    public partial class RViewMaintenanceHistory : MetroFramework.Forms.MetroForm
    { 
        public RViewMaintenanceHistory()
        {
            InitializeComponent();
        }

        private void RViewMaintenanceHistory_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime monthBefore = today.AddDays(-31);
            date_start.Text = monthBefore.ToString();

            CrystalReports.crvMaintenance mr = new CrystalReports.crvMaintenance();
            mr.SetParameterValue("@start", monthBefore.ToShortDateString());
            mr.SetParameterValue("@end", today.ToShortDateString());
            crvMaintenance.ReportSource = null;
            crvMaintenance.ReportSource = mr;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(date_start.Text);
            DateTime end = Convert.ToDateTime(date_end.Text);

            CrystalReports.crvMaintenance mr = new CrystalReports.crvMaintenance();
            mr.SetParameterValue("@start", start.ToShortDateString());
            mr.SetParameterValue("@end", end.ToShortDateString());
            crvMaintenance.ReportSource = null;
            crvMaintenance.ReportSource = mr;
        }
    }
}
