namespace DemoInterface1.Reports
{
    public partial class RViewVehicleStatus : MetroFramework.Forms.MetroForm
    {
        public RViewVehicleStatus()
        {
            InitializeComponent();
        }

        private void RViewVehicleStatus_Load(object sender, EventArgs e)
        {
            CrystalReports.crvVehicleStatus status = new CrystalReports.crvVehicleStatus();
            crvStatus.ReportSource = null;
            crvStatus.ReportSource = status;
        }
    }
}
