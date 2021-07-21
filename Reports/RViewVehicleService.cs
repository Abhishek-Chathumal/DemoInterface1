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
    public partial class RViewVehicleService : MetroFramework.Forms.MetroForm
    {
        public RViewVehicleService()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();

        private void RViewVehicleService_Load(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.DataSource = dt.DefaultView;
            cmb_vehicle.DisplayMember = "Plate No";
            cmb_vehicle.ValueMember = "Plate No";
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            CrystalReports.crvVehicleService vServ = new CrystalReports.crvVehicleService();
            vServ.SetParameterValue("@vno", cmb_vehicle.Text);
            crvVehicleService.ReportSource = null;
            crvVehicleService.ReportSource = vServ;
        }
    }
}
