namespace CuahangNongduoc
{
    partial class frmDanhSachPPGGCK
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXemNgay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 128);
            this.panel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.dtTuNgay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtDenNgay);
            this.groupBox2.Controls.Add(this.btnXemNgay);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(320, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(506, 117);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xem từ ngày đến ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(330, 27);
            this.dtDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(141, 22);
            this.dtDenNgay.TabIndex = 6;
            // 
            // btnXemNgay
            // 
            this.btnXemNgay.Image = global::CuahangNongduoc.Properties.Resources.reload;
            this.btnXemNgay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemNgay.Location = new System.Drawing.Point(200, 79);
            this.btnXemNgay.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemNgay.Name = "btnXemNgay";
            this.btnXemNgay.Size = new System.Drawing.Size(107, 30);
            this.btnXemNgay.TabIndex = 7;
            this.btnXemNgay.Text = "Xem";
            this.btnXemNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemNgay.UseVisualStyleBackColor = true;
            this.btnXemNgay.Click += new System.EventHandler(this.btnXemNgay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Từ ngày:";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(90, 28);
            this.dtTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(141, 22);
            this.dtTuNgay.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đến ngày:";
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "CuahangNongduoc_BusinessObject_ChiTietPhieuBan";
            reportDataSource5.Value = null;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CuahangNongduoc.Report.rptSoLuongBan.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 128);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1147, 537);
            this.reportViewer.TabIndex = 13;
            // 
            // frmDanhSachPPGGCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 665);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panel1);
            this.Name = "frmDanhSachPPGGCK";
            this.Text = "frmDanhSachPPGGCK";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Button btnXemNgay;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}