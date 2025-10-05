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
    public partial class frmSanPham : Form
    {
        SanPhamController ctrl = new SanPhamController();
        DonViTinhController ctrlDVT = new DonViTinhController();

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ctrlDVT.HienthiAutoComboBox(cmbDVT);
            dataGridView.Columns.Add(ctrlDVT.HienthiDataGridViewComboBoxColumn());
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator,
                 txtMaSanPham, txtTenSanPham, cmbDVT, numSoLuong, numDonGiaNhap, numGiaBanSi, numGiaBanLe);
        }


        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSanPham.Text;
            string dvt = cmbDVT.SelectedValue.ToString();
            decimal donGiaNhap = numDonGiaNhap.Value;
            int soLuong = (int)numSoLuong.Value;
            decimal giaBanSi = numGiaBanSi.Value;
            decimal giaBanLe = numGiaBanLe.Value;

            if (tenSP == "" || dvt == "" || donGiaNhap == 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin sản phẩm!", "Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(donGiaNhap < 0 || giaBanSi < 0 || giaBanLe < 0 || soLuong < 0)
            {
                MessageBox.Show("Đơn giá, số lượng, giá bán sĩ, giá bán lẻ không được nhỏ hơn 0!", "Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow row = ctrl.NewRow();
            long maso = ThamSo.SanPham;
            ThamSo.SanPham = maso+1;
            row["ID"] = maso;
            row["TEN_SAN_PHAM"] = tenSP;
            row["SO_LUONG"] = soLuong;
            row["DON_GIA_NHAP"] = donGiaNhap;
            row["GIA_BAN_SI"] = giaBanSi;
            row["GIA_BAN_LE"] = giaBanLe;
            ctrl.Add(row);
            bindingNavigator.BindingSource.MoveLast();
            
        }

      
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "San Pham", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
            }
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            
        }

        private void btnThemDVT_Click(object sender, EventArgs e)
        {
            frmDonViTinh DVT = new frmDonViTinh();
            DVT.ShowDialog();
            ctrlDVT.HienthiAutoComboBox(cmbDVT);
        }


        private void toolTimMaSanPham_Click(object sender, EventArgs e)
        {
            toolTimMaSanPham.Checked = true;
            toolTimTenSanPham.Checked = false;
            toolTimSanPham.Text = "";

        }

        private void mnuTimTenSanPham_Click(object sender, EventArgs e)
        {
            toolTimMaSanPham.Checked = false;
            toolTimTenSanPham.Checked = true;
            toolTimSanPham.Text = "";
        }

        private void toolTimSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimSanPham();
            }
        }

        private void toolTimSanPham_Leave(object sender, EventArgs e)
        {
            TimSanPham();
        }

        void TimSanPham()
        {
            if (toolTimMaSanPham.Checked == true)
            {
                ctrl.TimMaSanPham(toolTimSanPham.Text);
            }
            else
            {
                ctrl.TimTenSanPham(toolTimSanPham.Text);
            }
        }

        private void toolTimSanPham_Enter(object sender, EventArgs e)
        {
            toolTimSanPham.Text = "";
            toolTimSanPham.ForeColor = Color.Black;
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            var tenSP = row.Cells["TEN_SAN_PHAM"].Value;
            var dvt = row.Cells["ID_DON_VI_TINH"].Value;
            var donGiaNhap = row.Cells["DON_GIA_NHAP"].Value;
            var soLuong = row.Cells["SO_LUONG"].Value;
            var giaBanSi = row.Cells["GIA_BAN_SI"].Value;
            var giaBanLe = row.Cells["GIA_BAN_LE"].Value;

            if (tenSP == null || string.IsNullOrWhiteSpace(tenSP.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Tên sản phẩm không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["TEN_SAN_PHAM"];
            }
            if(dvt == null || string.IsNullOrWhiteSpace(dvt.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Đơn vị tính không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["ID_DON_VI_TINH"];
            }
            if(donGiaNhap == null || string.IsNullOrWhiteSpace(donGiaNhap.ToString()) || Convert.ToDecimal(donGiaNhap) < 0)
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Đơn giá nhập không được để trống hoặc nhỏ hơn 0";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["DON_GIA_NHAP"];
            }
            if(soLuong == null || string.IsNullOrWhiteSpace(soLuong.ToString()) || Convert.ToInt32(soLuong) < 0)
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Số lượng không được để trống hoặc nhỏ hơn 0";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["SO_LUONG"];
            }
            if(giaBanSi == null || string.IsNullOrWhiteSpace(giaBanSi.ToString()) || Convert.ToDecimal(giaBanSi) < 0)
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Giá bán sĩ không được để trống hoặc nhỏ hơn 0";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["GIA_BAN_SI"];
            }
            if(giaBanLe == null || string.IsNullOrWhiteSpace(giaBanLe.ToString()) || Convert.ToDecimal(giaBanLe) < 0)
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Giá bán lẻ không được để trống hoặc nhỏ hơn 0";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["GIA_BAN_LE"];
            }
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                if (r.Index != e.RowIndex && !r.IsNewRow)
                {
                    var tenSP2 = r.Cells["TEN_SAN_PHAM"].Value;
                    if (tenSP2 != null && tenSP2.ToString() == tenSP.ToString())
                    {
                        dataGridView.Rows[e.RowIndex].ErrorText = "Tên sản phẩm đã tồn tại";
                        e.Cancel = true;
                        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["TEN_SAN_PHAM"];
                    }
                }
            }
            dataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(dataGridView.Columns[e.ColumnIndex].Name == "ID")
            {
                e.Cancel = true;
            }
        }
    }
}