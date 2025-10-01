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
    public partial class frmDunoKhachhang : Form
    {
        public frmDunoKhachhang()
        {
            InitializeComponent();
        }
        DuNoKhachHangController ctrl = new DuNoKhachHangController();
        KhachHangController ctrlKH = new KhachHangController();
        private void frmDunoKhachhang_Load(object sender, EventArgs e)
        {

            this.toolThang.SelectedIndex = DateTime.Now.Month - 1;
            this.toolNam.Text = DateTime.Now.Year.ToString();
            ctrlKH.HienthiKhachHangChungDataGridviewComboBox(colKhachHang);

        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            
            
        }

        private void toolNam_Validating(object sender, CancelEventArgs e)
        {
            bool ok = true;
            try
            {
                long nam = Convert.ToInt32(toolNam.Text);
                if (nam < 2000 || nam > 9999)
                {
                    ok = false;
                }
            }
            catch
            {
                ok = false;
            }
            if (!ok)
            {
                MessageBox.Show("Thông tin năm không hợp lệ!", "Tong Hop Du No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void toolTongHop_Click(object sender, EventArgs e)
        {
            toolProgress.Visible = true;
            ctrl.Tonghop(toolThang.SelectedIndex + 1, Convert.ToInt32(toolNam.Text), toolProgress, dataGridView, bindingNavigator);
            toolProgress.Visible = false;
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                toolThang.Focus();
                ctrl.Save();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tổng hợp trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                KhachHangController ctrlKH = new KhachHangController();
                DuNoKhachHang dn = new DuNoKhachHang();

                dn.Thang = Convert.ToInt32(row["THANG"]);
                dn.Nam = Convert.ToInt32(row["NAM"]);
                dn.DauKy = Convert.ToInt64(row["DAU_KY"]);
                dn.PhatSinh = Convert.ToInt64(row["PHAT_SINH"]);
                dn.DaTra = Convert.ToInt64(row["DA_TRA"]);
                dn.CuoiKy = Convert.ToInt64(row["CUOI_KY"]);
                dn.KhachHang = ctrlKH.LayKhachHang(Convert.ToString(row["ID_KHACH_HANG"]));

                frmInDunoKhachHang InDuNo = new frmInDunoKhachHang(dn);
                InDuNo.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tổng hợp trước khi in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolInDanhSach_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                KhachHangController ctrlKH = new KhachHangController();

                List<DuNoKhachHang> danhSachDuNo = new List<DuNoKhachHang>();

                foreach (DataRowView row in bindingNavigator.BindingSource)
                {
                    DuNoKhachHang dn = new DuNoKhachHang
                    {
                        Thang = Convert.ToInt32(row["THANG"]),
                        Nam = Convert.ToInt32(row["NAM"]),
                        DauKy = Convert.ToInt64(row["DAU_KY"]),
                        PhatSinh = Convert.ToInt64(row["PHAT_SINH"]),
                        DaTra = Convert.ToInt64(row["DA_TRA"]),
                        CuoiKy = Convert.ToInt64(row["CUOI_KY"]),
                        KhachHang = ctrlKH.LayKhachHang(Convert.ToString(row["ID_KHACH_HANG"]))
                    };

                    danhSachDuNo.Add(dn);
                }

                frmInDanhSachDunoKhachHang frm = new frmInDanhSachDunoKhachHang(danhSachDuNo);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tổng hợp trước khi in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}