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
    public partial class frmPhuPhi : Form
    {
        PhuPhiController ctrl = new PhuPhiController();
        public frmPhuPhi(string idPhienBan)
        {
            InitializeComponent();
            txtMaPhieu.Text = idPhienBan;
            dataGridView.AutoGenerateColumns = false;
        }

        private void frmPhuPhi_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = ctrl.LayTheoPhieuBan(txtMaPhieu.Text);
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhuPhi.Text))
            {
                MessageBox.Show("Tên phụ phí không được để trống", "Phu phi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrl.Add(txtMaPhieu.Text, txtTenPhuPhi.Text, numSoTien.Value, txtGhiChu.Text);
            frmPhuPhi_Load(sender, e);
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            ctrl.Save();
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa phụ phí này không?", "Phu phi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ctrl.Delete(Convert.ToInt32(dataGridView.CurrentRow.Cells["colID"].Value));
                frmPhuPhi_Load(sender, e);
            }
        }
    }
}
