using CuahangNongduoc.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmChietKhau : Form
    {
        ChietKhauController ctrl = new ChietKhauController();
        KhachHangController ctrlKH = new KhachHangController();

        public frmChietKhau()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            ctrlKH.HienthiChungAutoComboBox(cmbKhachHang);
        }

        public frmChietKhau(bool loai)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            ctrlKH.HienthiAutoComboBox(cmbKhachHang, loai);
        }

        private void frmChietKhau_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ctrl.DanhSachChietKhau();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            decimal giaTri = numGiaTri.Value;
            if (cmbLoaiGiaTri.Text == "Phần trăm (%)")
            {
                if (giaTri > 100)
                {
                    MessageBox.Show("Giá trị chiết khấu không được lớn hơn 100%!", "Chiết khấu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ctrl.CapNhatChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString(), giaTri / 100);
            }
            else
            {
                ctrl.CapNhatChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString(), giaTri);
            }
            dataGridView.DataSource = ctrl.DanhSachChietKhau();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phụ phí này không?", "Phu phi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctrl.XoaChietKhauKhachHang(dataGridView.CurrentRow.Cells["colID"].Value.ToString());
                dataGridView.DataSource = ctrl.DanhSachChietKhau();
            }
        }
    }
}
