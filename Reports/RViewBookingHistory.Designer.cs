namespace DemoInterface1.Reports
{
    partial class RViewBookingHistory
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
            this.crvBook = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_generate = new MetroFramework.Controls.MetroTile();
            this.date_start = new MetroFramework.Controls.MetroDateTime();
            this.date_end = new MetroFramework.Controls.MetroDateTime();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.SuspendLayout();
            // 
            // crvBook
            // 
            this.crvBook.ActiveViewIndex = -1;
            this.crvBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBook.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBook.Location = new System.Drawing.Point(20, 60);
            this.crvBook.Name = "crvBook";
            this.crvBook.Size = new System.Drawing.Size(941, 370);
            this.crvBook.TabIndex = 0;
            this.crvBook.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btn_generate
            // 
            this.btn_generate.ActiveControl = null;
            this.btn_generate.Location = new System.Drawing.Point(834, 14);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(97, 37);
            this.btn_generate.TabIndex = 1;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseSelectable = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // date_start
            // 
            this.date_start.Location = new System.Drawing.Point(300, 20);
            this.date_start.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(200, 29);
            this.date_start.TabIndex = 2;
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(561, 20);
            this.date_end.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 29);
            this.date_end.TabIndex = 3;
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(23, 23);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(515, 24);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(29, 23);
            this.htmlLabel1.TabIndex = 4;
            this.htmlLabel1.Text = "To";
            // 
            // RViewBookingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 450);
            this.Controls.Add(this.htmlLabel1);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.crvBook);
            this.Name = "RViewBookingHistory";
            this.Text = "Report Booking History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewBookingHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBook;
        private MetroFramework.Controls.MetroTile btn_generate;
        private MetroFramework.Controls.MetroDateTime date_start;
        private MetroFramework.Controls.MetroDateTime date_end;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
    }
}