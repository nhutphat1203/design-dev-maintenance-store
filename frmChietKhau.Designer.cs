namespace CuahangNongduoc
{
    partial class frmChietKhau
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
            this.cmbLoaiGiaTri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKhachHang = new System.Windows.Forms.ComboBox();
            this.numGiaTri = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTriGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.grpThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaTri)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grpThongtin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
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
            this.groupBox1.Size = new System.Drawing.Size(800, 305);
            this.groupBox1.TabIndex = 9;
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
            this.colGiaTriGiam});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(4, 70);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(792, 231);
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
            this.bindingNavigator.Size = new System.Drawing.Size(792, 51);
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
            this.grpThongtin.Controls.Add(this.cmbLoaiGiaTri);
            this.grpThongtin.Controls.Add(this.label2);
            this.grpThongtin.Controls.Add(this.cmbKhachHang);
            this.grpThongtin.Controls.Add(this.numGiaTri);
            this.grpThongtin.Controls.Add(this.label3);
            this.grpThongtin.Controls.Add(this.label1);
            this.grpThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongtin.Location = new System.Drawing.Point(0, 0);
            this.grpThongtin.Margin = new System.Windows.Forms.Padding(4);
            this.grpThongtin.Name = "grpThongtin";
            this.grpThongtin.Padding = new System.Windows.Forms.Padding(4);
            this.grpThongtin.Size = new System.Drawing.Size(800, 145);
            this.grpThongtin.TabIndex = 8;
            this.grpThongtin.TabStop = false;
            this.grpThongtin.Text = "Thông tin";
            // 
            // cmbLoaiGiaTri
            // 
            this.cmbLoaiGiaTri.FormattingEnabled = true;
            this.cmbLoaiGiaTri.Items.AddRange(new object[] {
            "Phần trăm (%)",
            "Số tiền cụ thể"});
            this.cmbLoaiGiaTri.Location = new System.Drawing.Point(126, 64);
            this.cmbLoaiGiaTri.Name = "cmbLoaiGiaTri";
            this.cmbLoaiGiaTri.Size = new System.Drawing.Size(256, 24);
            this.cmbLoaiGiaTri.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loại giá trị";
            // 
            // cmbKhachHang
            // 
            this.cmbKhachHang.FormattingEnabled = true;
            this.cmbKhachHang.Location = new System.Drawing.Point(126, 28);
            this.cmbKhachHang.Name = "cmbKhachHang";
            this.cmbKhachHang.Size = new System.Drawing.Size(256, 24);
            this.cmbKhachHang.TabIndex = 6;
            // 
            // numGiaTri
            // 
            this.numGiaTri.Location = new System.Drawing.Point(126, 100);
            this.numGiaTri.Margin = new System.Windows.Forms.Padding(4);
            this.numGiaTri.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numGiaTri.Name = "numGiaTri";
            this.numGiaTri.Size = new System.Drawing.Size(256, 22);
            this.numGiaTri.TabIndex = 5;
            this.numGiaTri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numGiaTri.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá trị giảm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khách hàng";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID_KHACH_HANG";
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.Width = 125;
            // 
            // colGiaTriGiam
            // 
            this.colGiaTriGiam.DataPropertyName = "GIA_TRI";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.colGiaTriGiam.DefaultCellStyle = dataGridViewCellStyle1;
            this.colGiaTriGiam.HeaderText = "Giá trị";
            this.colGiaTriGiam.MinimumWidth = 6;
            this.colGiaTriGiam.Name = "colGiaTriGiam";
            this.colGiaTriGiam.Width = 125;
            // 
            // frmChietKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmChietKhau";
            this.Text = "frmChietKhau";
            this.Load += new System.EventHandler(this.frmChietKhau_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.grpThongtin.ResumeLayout(false);
            this.grpThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaTri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.GroupBox grpThongtin;
        private System.Windows.Forms.ComboBox cmbKhachHang;
        private System.Windows.Forms.NumericUpDown numGiaTri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoaiGiaTri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriGiam;
    }
}