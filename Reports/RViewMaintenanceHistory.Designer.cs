namespace DemoInterface1.Reports
{
    partial class RViewMaintenanceHistory
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
            this.btn_generate = new MetroFramework.Controls.MetroTile();
            this.date_end = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.date_start = new MetroFramework.Controls.MetroDateTime();
            this.crvMaintenance = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.ActiveControl = null;
            this.btn_generate.Location = new System.Drawing.Point(761, 20);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(87, 36);
            this.btn_generate.Style = MetroFramework.MetroColorStyle.Purple;
            this.btn_generate.TabIndex = 22;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseSelectable = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(512, 27);
            this.date_end.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 29);
            this.date_end.TabIndex = 21;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(483, 31);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(22, 19);
            this.metroLabel2.TabIndex = 20;
            this.metroLabel2.Text = "To";
            // 
            // date_start
            // 
            this.date_start.Location = new System.Drawing.Point(276, 26);
            this.date_start.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(200, 29);
            this.date_start.TabIndex = 19;
            // 
            // crvMaintenance
            // 
            this.crvMaintenance.ActiveViewIndex = -1;
            this.crvMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMaintenance.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMaintenance.Location = new System.Drawing.Point(20, 60);
            this.crvMaintenance.Name = "crvMaintenance";
            this.crvMaintenance.Size = new System.Drawing.Size(845, 370);
            this.crvMaintenance.TabIndex = 18;
            this.crvMaintenance.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewMaintenanceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 450);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.crvMaintenance);
            this.Name = "RViewMaintenanceHistory";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Maintenance History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewMaintenanceHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btn_generate;
        private MetroFramework.Controls.MetroDateTime date_end;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime date_start;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMaintenance;
    }
}