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
    public partial class RViewVehicleAccident : MetroFramework.Forms.MetroForm
    {
        public RViewVehicleAccident()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();

        private void RViewVehicleAccident_Load(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.DataSource = dt.DefaultView;
            cmb_vehicle.DisplayMember = "Plate No";
            cmb_vehicle.ValueMember = "Plate No";
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            CrystalReports.crvVehicleAccident vAcc = new CrystalReports.crvVehicleAccident();
            vAcc.SetParameterValue("@vehicle", cmb_vehicle.Text);
            crvVehicleAccident.ReportSource = null;
            crvVehicleAccident.ReportSource = vAcc;
        }
    }
}
