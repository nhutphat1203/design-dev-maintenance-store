using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc
{
    public partial class frmNhaCungCap : Form
    {
        CuahangNongduoc.Controller.NhaCungCapController ctrl = new CuahangNongduoc.Controller.NhaCungCapController();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Nha Cung Cap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Nha Cung Cap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bindingNavigator.BindingSource.RemoveCurrent();
            }
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            long maso = ThamSo.NhaCungCap;
            ThamSo.NhaCungCap = maso + 1;

            DataRowView row = (DataRowView)bindingNavigator.BindingSource.AddNew();
            row["ID"] = maso;
            
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            ctrl.Save();
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolTimNhaCungCap_Enter(object sender, EventArgs e)
        {
            toolTimNhaCungCap.Text = "";
            toolTimNhaCungCap.ForeColor = Color.Black;
        }

        private void toolTimNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (toolTimHoTen.Checked)
                {
                    ctrl.TimHoTen(toolTimNhaCungCap.Text);
                }
                else
                {
                    ctrl.TimDiaChi(toolTimNhaCungCap.Text);
                }
            }
        }

        private void toolTimNhaCungCap_Leave(object sender, EventArgs e)
        {
            if (toolTimHoTen.Checked == true)
                toolTimNhaCungCap.Text = "Tìm theo Nhà cung cấp";
            else
                toolTimNhaCungCap.Text = "Tìm theo Địa chỉ";

            toolTimNhaCungCap.ForeColor = Color.FromArgb(224, 224, 224);
        }

        private void toolTimHoTen_Click(object sender, EventArgs e)
        {
            toolTimDiaChi.Checked = !toolTimDiaChi.Checked;
            toolTimHoTen.Checked = !toolTimDiaChi.Checked;
            toolTimNhaCungCap.Text = "Tìm theo Nhà cung cấp";
            bindingNavigator.Focus();
        }

        private void toolTimDiaChi_Click(object sender, EventArgs e)
        {
            toolTimHoTen.Checked = !toolTimHoTen.Checked;
            toolTimDiaChi.Checked = !toolTimHoTen.Checked;
            toolTimNhaCungCap.Text = "Tìm theo Địa chỉ";
            bindingNavigator.Focus();
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            var tenNCC = row.Cells["HO_TEN"].Value;
            var diaChi = row.Cells["DIA_CHI"].Value;
            var soDienThoai = row.Cells["DIEN_THOAI"].Value;

            if (tenNCC == null || string.IsNullOrWhiteSpace(tenNCC.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Tên nhà cung cấp không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["HO_TEN"];
            }
            if (diaChi == null || string.IsNullOrWhiteSpace(diaChi.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Địa chỉ không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["DIA_CHI"];
            }
            if (soDienThoai == null || string.IsNullOrWhiteSpace(soDienThoai.ToString()))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Số điện thoại không được để trống";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["DIEN_THOAI"];
            }
            if(!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai.ToString(), @"^\d{10,11}$"))
            {
                dataGridView.Rows[e.RowIndex].ErrorText = "Số điện thoại không hợp lệ";
                e.Cancel = true;
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["DIEN_THOAI"];
            }

            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                if (r.Index != e.RowIndex && !r.IsNewRow)
                {
                    var tenNCC2 = r.Cells["HO_TEN"].Value;
                    if (tenNCC2 != null && tenNCC2.ToString() == tenNCC.ToString())
                    {
                        dataGridView.Rows[e.RowIndex].ErrorText = "Tên nhà cung cấp đã tồn tại";
                        e.Cancel = true;
                        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["HO_TEN"];
                    }
                }
            }


            dataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "ID")
            {
                e.Cancel = true;
            }
        }
    }
}