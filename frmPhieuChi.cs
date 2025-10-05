using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;

namespace CuahangNongduoc
{
    public partial class frmPhieuChi : Form
    {
        LyDoChiController ctrlLyDo = new LyDoChiController();
        PhieuChiController ctrl = new PhieuChiController();
        public frmPhieuChi()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            ctrlLyDo.HienthiAutoComboBox(cmbLyDoChi);
            ctrlLyDo.HienthiDataGridviewComboBox(colLyDoChi);
            ctrl.HienthiPhieuChi(bindingNavigator, dataGridView, cmbLyDoChi, txtMaPhieu, dtNgayChi, numTongTien, txtGhiChu);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu.Text;
            string lyDoChi = cmbLyDoChi.SelectedValue.ToString();
            decimal tongTien = numTongTien.Value;
            DateTime ngayChi = dtNgayChi.Value.Date;
            string ghiChu = txtGhiChu.Text;

            if (lyDoChi == "" || tongTien == 0 || ngayChi == null)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin phiếu chi!", "Phiếu Chi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(tongTien < 0)
            {
                MessageBox.Show("Tổng tiền không được nhỏ hơn 0!", "Phiếu Chi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long maphieu = ThamSo.PhieuChi;
            ThamSo.PhieuChi=maphieu+1;

            DataRow row = ctrl.NewRow();
            row["ID"] = maphieu;
            row["ID_LY_DO_CHI"] = lyDoChi;
            row["NGAY_CHI"] = ngayChi;
            row["TONG_TIEN"] = tongTien;
            row["GHI_CHU"] = ghiChu;
            ctrl.Add(row);
            bindingNavigator.BindingSource.MoveLast();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phiếu chi này không?", "Phieu Chi",   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phiếu chi này không?", "Phieu Chi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
                ctrl.Save();
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Focus();
            bindingNavigator.BindingSource.MoveNext();
            ctrl.Save();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row != null)
            {
                PhieuChiController ctrlChi = new PhieuChiController();
                String ma_phieu = row["ID"].ToString();
                CuahangNongduoc.BusinessObject.PhieuChi ph = ctrlChi.LayPhieuChi(ma_phieu);
                frmInPhieuChi InPhieu = new frmInPhieuChi(ph);
                InPhieu.Show();
            }
        }

        private void btnThemLyDoChi_Click(object sender, EventArgs e)
        {
            frmLyDoChi Chi = new frmLyDoChi();
            Chi.ShowDialog();
            ctrlLyDo.HienthiAutoComboBox(cmbLyDoChi);
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimPhieuChi Tim = new frmTimPhieuChi();
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            Tim.Location = p;
            Tim.ShowDialog();
            if (Tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimPhieuChi(bindingNavigator, dataGridView, cmbLyDoChi, txtMaPhieu, dtNgayChi, numTongTien, txtGhiChu, Convert.ToInt32(Tim.cmbLyDo.SelectedValue), dtNgayChi.Value.Date);
                
            }
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            var lyDo = row.Cells["ID_LY_DO_CHI"].Value;
            var tongTien = row.Cells["TONG_TIEN"].Value;
            var ngayChi = row.Cells["NGAY_CHI"].Value;
            if (lyDo == null || string.IsNullOrWhiteSpace(lyDo.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Lý do chi không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["ID_LY_DO_CHI"];
            }
            if(tongTien == null || string.IsNullOrWhiteSpace(tongTien.ToString()) || Convert.ToDecimal(tongTien) <= 0)
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Tổng tiền phải lớn hơn 0";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["TONG_TIEN"];
            }
            if(ngayChi == null || string.IsNullOrWhiteSpace(ngayChi.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Ngày chi không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["NGAY_CHI"];
            }
            dataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(dataGridView.Columns[e.RowIndex].Name == "ID")
            {
                e.Cancel = true;
            }
        }
    }
}