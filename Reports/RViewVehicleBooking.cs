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
    public partial class RViewVehicleBooking : MetroFramework.Forms.MetroForm
    {
        public RViewVehicleBooking()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();

        private void RViewVehicleBooking_Load(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.DataSource = dt.DefaultView;
            cmb_vehicle.DisplayMember = "Plate No";
            cmb_vehicle.ValueMember = "Plate No";
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            CrystalReports.crvVehicleBooking vehicleBK = new CrystalReports.crvVehicleBooking();
            vehicleBK.SetParameterValue("@vno", cmb_vehicle.Text);
            crvVehicleBooking.ReportSource = null;
            crvVehicleBooking.ReportSource = vehicleBK;
        }
    }
}
