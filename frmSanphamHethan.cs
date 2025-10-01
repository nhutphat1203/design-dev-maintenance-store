using CuahangNongduoc.BusinessObject;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmSanphamHethan : Form
    {
        private Dataset.CHND.SanPhamHetHanDataTable dataTable = new Dataset.CHND.SanPhamHetHanDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmSanphamHethan()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            IList<CuahangNongduoc.BusinessObject.MaSanPham> data = CuahangNongduoc.Controller.MaSanPhamController.LayMaSanPhamHetHan(dt.Value.Date);
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ngay_tinh", dt.Value.Date.ToString("dd/MM/yyyy")));
            dataTable.Clear();
            foreach (var row in data)
            {
                dataTable.AddSanPhamHetHanRow(
                    row.SanPham.Id,
                    row.NgayNhap,
                    row.NgayHetHan,
                    row.NgaySanXuat,
                    row.SanPham.TenSanPham,
                    row.SoLuong,
                    row.ThanhTien,
                    row.GiaNhap
                    );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCHND";
            reportDataSource.Value = dataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptSanPhamHetHan.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.LocalReport.SetParameters(param);
            reportViewer.RefreshReport();
        }

        private void frmSanphamHethan_Load(object sender, EventArgs e)
        {

        }
    }
}