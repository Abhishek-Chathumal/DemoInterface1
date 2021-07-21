namespace DemoInterface1.Reports
{
    partial class RViewVehicleAccident
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cmb_vehicle = new MetroFramework.Controls.MetroComboBox();
            this.crvVehicleAccident = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(298, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "License Plate";
            // 
            // cmb_vehicle
            // 
            this.cmb_vehicle.FormattingEnabled = true;
            this.cmb_vehicle.ItemHeight = 23;
            this.cmb_vehicle.Location = new System.Drawing.Point(390, 22);
            this.cmb_vehicle.Name = "cmb_vehicle";
            this.cmb_vehicle.Size = new System.Drawing.Size(155, 29);
            this.cmb_vehicle.TabIndex = 7;
            this.cmb_vehicle.UseSelectable = true;
            this.cmb_vehicle.DropDownClosed += new System.EventHandler(this.cmb_vehicle_DropDownClosed);
            // 
            // crvVehicleAccident
            // 
            this.crvVehicleAccident.ActiveViewIndex = -1;
            this.crvVehicleAccident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVehicleAccident.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVehicleAccident.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVehicleAccident.Location = new System.Drawing.Point(20, 60);
            this.crvVehicleAccident.Name = "crvVehicleAccident";
            this.crvVehicleAccident.Size = new System.Drawing.Size(760, 370);
            this.crvVehicleAccident.TabIndex = 6;
            this.crvVehicleAccident.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewVehicleAccident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmb_vehicle);
            this.Controls.Add(this.crvVehicleAccident);
            this.Name = "RViewVehicleAccident";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Vehicle Accident";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewVehicleAccident_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cmb_vehicle;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVehicleAccident;
    }
}