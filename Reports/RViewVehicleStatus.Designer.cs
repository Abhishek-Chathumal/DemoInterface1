namespace DemoInterface1.Reports
{
    partial class RViewVehicleStatus
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
            this.crvStatus = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvStatus
            // 
            this.crvStatus.ActiveViewIndex = -1;
            this.crvStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvStatus.Location = new System.Drawing.Point(20, 60);
            this.crvStatus.Name = "crvStatus";
            this.crvStatus.Size = new System.Drawing.Size(760, 370);
            this.crvStatus.TabIndex = 0;
            this.crvStatus.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewVehicleStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvStatus);
            this.Name = "RViewVehicleStatus";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Vehicle Status";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewVehicleStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvStatus;
    }
}