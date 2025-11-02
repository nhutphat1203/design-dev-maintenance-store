using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
using CuahangNongduoc.Dataset;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmNhanVienGiamGia : Form
    {
        private Dataset.CHND.NhanVienGiamGiaDataTable danhSachDataTable = new CHND.NhanVienGiamGiaDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");

        PhieuBanController ctrlPB = new PhieuBanController();
        GiamGiaController ctrlGG = new GiamGiaController();
        UsersController ctrlUser = new UsersController();
        public frmNhanVienGiamGia()
        {
            InitializeComponent();
        }

        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            if (cmbNhanVien.SelectedItem == null || string.IsNullOrEmpty(cmbNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime tuNgay = dtTuNgay.Value.Date;
            DateTime denNgay = dtDenNgay.Value.Date;
            danhSachDataTable.Clear();
            if (denNgay < tuNgay)
            {
                MessageBox.Show("Khoảng ngày không hợp lệ!\nNgày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("tu_ngay", "Từ Ngày " + dtTuNgay.Value.Date.ToString("dd/MM/yyyy")));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("den_ngay", "Đến Ngày " + dtDenNgay.Value.Date.ToString("dd/MM/yyyy")));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_nhan_vien", "Nhân viên: " + cmbNhanVien.Text.ToString()));

            int id = Convert.ToInt32(cmbNhanVien.SelectedValue);
            
            DataTable PB = ctrlPB.DanhSachPBNVTuNgayDenNgay(tuNgay, denNgay, id);
            
            if(PB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportViewer.Clear();
                return;
            }
            string idPB;
            foreach (DataRow dr in PB.AsEnumerable())
            {
                var newRow = danhSachDataTable.NewRow();
                idPB = Convert.ToString(dr["ID"]);
                newRow["PhieuBanID"] = idPB;
                newRow["NgayLap"] = Convert.ToDateTime(dr["NGAY_BAN"]);
                newRow["LoaiGiam"] = ctrlGG.LayLoaiTheoPhieuBan(idPB) ? "Tiền cụ thể" : "Phần trăm (%)";
                newRow["SoTienGiam"] = ctrlGG.LayTheoPhieuBan(idPB);
                danhSachDataTable.Rows.Add(newRow);
            }

            LoadReport(param);
        }

        private void LoadReport(IList<ReportParameter> param)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "NhanVienGiamGia";
            reportDataSource.Value = danhSachDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptNhanVienGiamGia.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.LocalReport.SetParameters(param);
            this.reportViewer.RefreshReport();
        }

        private void frmNhanVienGiamGia_Load(object sender, EventArgs e)
        {
            cmbNhanVien.DataSource = ctrlUser.LayUsers();
            cmbNhanVien.DisplayMember = "Name";
            cmbNhanVien.ValueMember = "ID";
            if (cmbNhanVien.Items.Count > 0)
            {
                cmbNhanVien.SelectedIndex = 0;
                cmbNhanVien_SelectedIndexChanged(sender, e);
            }
        }

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDNV.Text = cmbNhanVien.SelectedValue.ToString();
        }
    }
}
