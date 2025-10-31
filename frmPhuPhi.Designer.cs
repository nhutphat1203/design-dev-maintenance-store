namespace CuahangNongduoc
{
    partial class frmPhuPhi
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.grpThongtin = new System.Windows.Forms.GroupBox();
            this.txtTenPhuPhi = new System.Windows.Forms.TextBox();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numSoTien = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenPhuPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSotien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.grpThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grpThongtin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 469);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Controls.Add(this.bindingNavigator);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(868, 324);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Phiếu chi";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTenPhuPhi,
            this.colSotien,
            this.colGhiChu});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(4, 70);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(860, 250);
            this.dataGridView.TabIndex = 1;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.CountItem = null;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolDelete});
            this.bindingNavigator.Location = new System.Drawing.Point(4, 19);
            this.bindingNavigator.MoveFirstItem = null;
            this.bindingNavigator.MoveLastItem = null;
            this.bindingNavigator.MoveNextItem = null;
            this.bindingNavigator.MovePreviousItem = null;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = null;
            this.bindingNavigator.Size = new System.Drawing.Size(860, 51);
            this.bindingNavigator.TabIndex = 0;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::CuahangNongduoc.Properties.Resources.add;
            this.toolAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.RightToLeftAutoMirrorImage = true;
            this.toolAdd.Size = new System.Drawing.Size(50, 48);
            this.toolAdd.Text = "Thêm";
            this.toolAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::CuahangNongduoc.Properties.Resources.remove;
            this.toolDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.RightToLeftAutoMirrorImage = true;
            this.toolDelete.Size = new System.Drawing.Size(55, 48);
            this.toolDelete.Text = "  Xóa  ";
            this.toolDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // grpThongtin
            // 
            this.grpThongtin.Controls.Add(this.txtTenPhuPhi);
            this.grpThongtin.Controls.Add(this.txtMaPhieu);
            this.grpThongtin.Controls.Add(this.label4);
            this.grpThongtin.Controls.Add(this.txtGhiChu);
            this.grpThongtin.Controls.Add(this.label2);
            this.grpThongtin.Controls.Add(this.numSoTien);
            this.grpThongtin.Controls.Add(this.label3);
            this.grpThongtin.Controls.Add(this.label1);
            this.grpThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongtin.Location = new System.Drawing.Point(0, 0);
            this.grpThongtin.Margin = new System.Windows.Forms.Padding(4);
            this.grpThongtin.Name = "grpThongtin";
            this.grpThongtin.Padding = new System.Windows.Forms.Padding(4);
            this.grpThongtin.Size = new System.Drawing.Size(868, 145);
            this.grpThongtin.TabIndex = 6;
            this.grpThongtin.TabStop = false;
            this.grpThongtin.Text = "Thông tin";
            // 
            // txtTenPhuPhi
            // 
            this.txtTenPhuPhi.Location = new System.Drawing.Point(153, 68);
            this.txtTenPhuPhi.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenPhuPhi.Name = "txtTenPhuPhi";
            this.txtTenPhuPhi.Size = new System.Drawing.Size(203, 22);
            this.txtTenPhuPhi.TabIndex = 15;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Location = new System.Drawing.Point(152, 36);
            this.txtMaPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(203, 22);
            this.txtMaPhieu.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã phiếu";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(479, 39);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(364, 87);
            this.txtGhiChu.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ghi chú";
            // 
            // numSoTien
            // 
            this.numSoTien.Location = new System.Drawing.Point(153, 101);
            this.numSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.numSoTien.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numSoTien.Name = "numSoTien";
            this.numSoTien.Size = new System.Drawing.Size(202, 22);
            this.numSoTien.TabIndex = 5;
            this.numSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSoTien.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 125;
            // 
            // colTenPhuPhi
            // 
            this.colTenPhuPhi.DataPropertyName = "TEN";
            this.colTenPhuPhi.HeaderText = "Phụ phí";
            this.colTenPhuPhi.MinimumWidth = 6;
            this.colTenPhuPhi.Name = "colTenPhuPhi";
            this.colTenPhuPhi.Width = 125;
            // 
            // colSotien
            // 
            this.colSotien.DataPropertyName = "SO_TIEN";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.colSotien.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSotien.HeaderText = "Số tiền";
            this.colSotien.MinimumWidth = 6;
            this.colSotien.Name = "colSotien";
            this.colSotien.Width = 125;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GHI_CHU";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MinimumWidth = 6;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Width = 150;
            // 
            // frmPhuPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 469);
            this.Controls.Add(this.panel1);
            this.Name = "frmPhuPhi";
            this.Text = "PHU PHI";
            this.Load += new System.EventHandler(this.frmPhuPhi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.grpThongtin.ResumeLayout(false);
            this.grpThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpThongtin;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSoTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.TextBox txtTenPhuPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenPhuPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSotien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}