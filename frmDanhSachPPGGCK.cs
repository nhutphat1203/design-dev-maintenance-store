using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
using CuahangNongduoc.DataLayer;
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
    public partial class frmDanhSachPPGGCK : Form
    {
        private Dataset.CHND.PhuPhiGiamGiaChietKhauDataTable danhSachDataTable = new CHND.PhuPhiGiamGiaChietKhauDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");

        PhieuBanController ctrlPB = new PhieuBanController();
        KhachHangController ctrlKH = new KhachHangController();
        GiamGiaController ctrlGG = new GiamGiaController();
        PhuPhiController ctrlPP = new PhuPhiController();
        ChietKhauController ctrlCK = new ChietKhauController();

        public frmDanhSachPPGGCK()
        {
            InitializeComponent();
        }

        private void btnXemNgay_Click(object sender, EventArgs e)
        {
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

            string id;
            KhachHang kh;
            DataTable PB = ctrlPB.DanhSachPBTuNgayDenNgay(tuNgay, denNgay);
            foreach (DataRow dr in PB.AsEnumerable())
            {
                var newRow = danhSachDataTable.NewRow();
                id = Convert.ToString(dr["ID"]);
                kh = ctrlKH.LayKhachHang(Convert.ToString(dr["ID_KHACH_HANG"]));
                newRow["PhieuBanID"] = id;
                newRow["TenKhachHang"] = kh.HoTen;
                newRow["TongPhuPhi"] = ctrlPP.TongTien(id);
                newRow["SoTienGiamGia"] = ctrlGG.LayTheoPhieuBan(id);
                newRow["SoTienChietKhau"] = ctrlCK.LayChietKhauApDung(id);
                newRow["ThanhTienCuoi"] = Convert.ToInt64(dr["TONG_TIEN"]);
                newRow["NgayLap"] = Convert.ToDateTime(dr["NGAY_BAN"]);
                danhSachDataTable.Rows.Add(newRow);
            }
            LoadReport(param);
        }

        private void LoadReport(IList<ReportParameter> param)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "PhuPhiGiamGiaChietKhau";
            reportDataSource.Value = danhSachDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptDanhSachGiamGiaPhuPhiChietKhau.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.LocalReport.SetParameters(param);
            this.reportViewer.RefreshReport();
        }
    }
}
