namespace DemoInterface1.Reports
{
    partial class RViewServiceHistory
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
            this.crvService = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.ActiveControl = null;
            this.btn_generate.Location = new System.Drawing.Point(691, 19);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(87, 36);
            this.btn_generate.Style = MetroFramework.MetroColorStyle.Purple;
            this.btn_generate.TabIndex = 17;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseSelectable = true;
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(442, 26);
            this.date_end.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 29);
            this.date_end.TabIndex = 16;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(413, 30);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(22, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "To";
            // 
            // date_start
            // 
            this.date_start.Location = new System.Drawing.Point(206, 25);
            this.date_start.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(200, 29);
            this.date_start.TabIndex = 14;
            // 
            // crvService
            // 
            this.crvService.ActiveViewIndex = -1;
            this.crvService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvService.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvService.Location = new System.Drawing.Point(20, 60);
            this.crvService.Name = "crvService";
            this.crvService.Size = new System.Drawing.Size(760, 370);
            this.crvService.TabIndex = 13;
            this.crvService.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewServiceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.crvService);
            this.Name = "RViewServiceHistory";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Service History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btn_generate;
        private MetroFramework.Controls.MetroDateTime date_end;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime date_start;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvService;
    }
}