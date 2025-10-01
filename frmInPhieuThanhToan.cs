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
    public partial class frmInPhieuThanhToan : Form
    {
        CuahangNongduoc.BusinessObject.PhieuThanhToan m_PhieuThanhToan;
        private Dataset.CHND.ThanhToanDataTable dataTable = new Dataset.CHND.ThanhToanDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmInPhieuThanhToan(CuahangNongduoc.BusinessObject.PhieuThanhToan ph)
        {
            InitializeComponent();
            m_PhieuThanhToan = ph;
        }

        private void frmPhieuThanhToan_Load(object sender, EventArgs e)
        {
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuThanhToan.TongTien.ToString())));
            dataTable.Clear();
            dataTable.AddThanhToanRow(
                m_PhieuThanhToan.Id, 
                m_PhieuThanhToan.KhachHang.HoTen, 
                m_PhieuThanhToan.NgayThanhToan, 
                m_PhieuThanhToan.GhiChu,
                m_PhieuThanhToan.TongTien,
                m_PhieuThanhToan.KhachHang.DiaChi, 
                m_PhieuThanhToan.KhachHang.DienThoai);

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCHND";
            reportDataSource.Value = dataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThanhToan.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.LocalReport.SetParameters(param);
            reportViewer.RefreshReport();
        }
    }
}