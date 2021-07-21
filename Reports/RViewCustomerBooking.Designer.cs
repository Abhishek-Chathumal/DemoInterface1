namespace DemoInterface1.Reports
{
    partial class RViewCustomerBooking
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
            this.crvCustomerBooking = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmb_cus = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(364, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(92, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Customer NIC";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // crvCustomerBooking
            // 
            this.crvCustomerBooking.ActiveViewIndex = -1;
            this.crvCustomerBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustomerBooking.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCustomerBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustomerBooking.Location = new System.Drawing.Point(20, 60);
            this.crvCustomerBooking.Name = "crvCustomerBooking";
            this.crvCustomerBooking.Size = new System.Drawing.Size(760, 370);
            this.crvCustomerBooking.TabIndex = 4;
            this.crvCustomerBooking.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cmb_cus
            // 
            this.cmb_cus.FormattingEnabled = true;
            this.cmb_cus.ItemHeight = 23;
            this.cmb_cus.Location = new System.Drawing.Point(460, 23);
            this.cmb_cus.Name = "cmb_cus";
            this.cmb_cus.Size = new System.Drawing.Size(151, 29);
            this.cmb_cus.TabIndex = 3;
            this.cmb_cus.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmb_cus.UseSelectable = true;
            this.cmb_cus.DropDownClosed += new System.EventHandler(this.cmb_cus_DropDownClosed);
            // 
            // RViewCustomerBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.crvCustomerBooking);
            this.Controls.Add(this.cmb_cus);
            this.Name = "RViewCustomerBooking";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Customer Booking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewCustomerBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustomerBooking;
        private MetroFramework.Controls.MetroComboBox cmb_cus;
    }
}