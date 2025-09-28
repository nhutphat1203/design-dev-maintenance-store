using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.BusinessObject;
using CuahangNongduoc.Controller;
using CuahangNongduoc.Dataset;
using Microsoft.Reporting.WinForms;

namespace CuahangNongduoc
{
    public partial class frmSoLuongBan : Form
    {
        private Dataset.CHND.SoLuongBanDataTable danhSachDataTable = new CHND.SoLuongBanDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmSoLuongBan()
        {
            InitializeComponent();
            //reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
            
            //reportViewer.LocalReport.ExecuteReportInSandboxAppDomain();
        }

        private void frmSoLuongBan_Load(object sender, EventArgs e)
        {
            cmbThang.SelectedIndex = DateTime.Now.Month - 1;
            numNam.Value = DateTime.Now.Year;
        }

        ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();

        
        private void btnXemNgay_Click(object sender, EventArgs e)
        {
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ngay", "Ngày " + dtNgay.Value.Date.ToString("dd/MM/yyyy")));

            var data = ctrl.ChiTietPhieuBan(dtNgay.Value.Date);
            LoadReport(data, param);
        }

        private void btnXemThang_Click(object sender, EventArgs e)
        {
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ngay",
                "Tháng " + Convert.ToString(cmbThang.SelectedIndex + 1) + "/" + numNam.Value.ToString()));

            var data = ctrl.ChiTietPhieuBan(cmbThang.SelectedIndex + 1, Convert.ToInt32(numNam.Value));
            LoadReport(data, param);
        }

        private void LoadReport(IList<ChiTietPhieuBan> data, IList<ReportParameter> param)
        {
            danhSachDataTable.Clear();
            foreach (var row in data)
            {
                danhSachDataTable.AddSoLuongBanRow
                    (
                    row.MaSanPham.Id,
                    row.DonGia,
                    row.SoLuong,
                    row.ThanhTien,
                    row.MaSanPham.SanPham.TenSanPham
                    );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCHND";
            reportDataSource.Value = danhSachDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptSoLuongBan.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            this.reportViewer.LocalReport.SetParameters(param);
            this.reportViewer.RefreshReport();
        }
    }
}