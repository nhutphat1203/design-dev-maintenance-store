using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;

namespace CuahangNongduoc
{
    public partial class frmDanhsachPhieuBanSi : Form
    {
        public frmDanhsachPhieuBanSi()
        {
            InitializeComponent();
        }

        PhieuBanController ctrl = new PhieuBanController();
        KhachHangController ctrlKH = new KhachHangController();
        private void frmDanhsachPhieuNhap_Load(object sender, EventArgs e)
        {
            ctrlKH.HienthiDaiLyDataGridviewComboBox(colKhachhang);
            ctrl.HienthiPhieuBanSi(bindingNavigator, dataGridView);
        }
        frmBanSi BanSi = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (BanSi == null || BanSi.IsDisposed)
            {
                BanSi = new frmBanSi(ctrl);
                BanSi.FormClosed += BanSi_FormClosed;
                BanSi.Show();
            }
            else
                BanSi.Activate();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (BanSi == null || BanSi.IsDisposed)
            {
                BanSi = new frmBanSi();
                BanSi.FormClosed += BanSi_FormClosed;
                BanSi.Show();
            }
            else
                BanSi.Activate();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DataRowView view = (DataRowView)bindingNavigator.BindingSource.Current;
                ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(view["ID"].ToString());
                foreach (ChiTietPhieuBan ct in ds)
                {
                    CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(ct.MaSanPham.Id, ct.SoLuong);
                }
                ctrl.Save();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
             DataRowView view =  (DataRowView)bindingNavigator.BindingSource.Current;
             if (view != null)
             {
                 if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                     IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(view["ID"].ToString());
                     foreach (ChiTietPhieuBan ct in ds)
                     {
                         CuahangNongduoc.DataLayer.MaSanPhanFactory.CapNhatSoLuong(ct.MaSanPham.Id, ct.SoLuong);
                     }
                     bindingNavigator.BindingSource.RemoveCurrent();
                     ctrl.Save();
                 }
             }
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row != null)
            {
                PhieuBanController ctrlPB = new PhieuBanController();
                String ma_phieu = row["ID"].ToString();
                CuahangNongduoc.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
                frmInPhieuBan PhieuBan = new frmInPhieuBan(ph);
                PhieuBan.Show();
            }
        }

        private void toolTimKiem_Click(object sender, EventArgs e)
        {
            frmTimPhieuBanLe Tim = new frmTimPhieuBanLe(true);
            Point p = PointToScreen(toolTimKiem.Bounds.Location);
            p.X += toolTimKiem.Width;
            p.Y += toolTimKiem.Height;
            Tim.Location = p;
            Tim.ShowDialog();
            if (Tim.DialogResult == DialogResult.OK)
            {
                ctrl.TimPhieuBan(Tim.cmbNCC.SelectedValue.ToString(), Tim.dtNgayNhap.Value.Date);
            }
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            ctrl.Save();
        }

        private void BanSi_FormClosed(object sender, FormClosedEventArgs e)
        {
            ctrl.HienthiPhieuBanSi(bindingNavigator, dataGridView);
        }
    }
}