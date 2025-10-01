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
    public partial class frmInPhieuNhap : Form
    {
        CuahangNongduoc.BusinessObject.PhieuNhap m_PhieuNhap;
        private Dataset.CHND.PhieuNhapDataTable danhSachPhieuNhapDataTable = new Dataset.CHND.PhieuNhapDataTable();
        private Dataset.CHND.ChiTietPhieuNhapDataTable danhSachChiTietDataTable = new Dataset.CHND.ChiTietPhieuNhapDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmInPhieuNhap(CuahangNongduoc.BusinessObject.PhieuNhap ph)
        {
            m_PhieuNhap = ph;
            InitializeComponent();

            /* code cũ
            reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
            this.reportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            */
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Clear();
            //e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CuahangNongduoc_BusinessObject_MaSanPham", m_PhieuNhap.ChiTiet)); //code cũ
            e.DataSources.Add(new ReportDataSource("CHND_ChiTietPhieuNhap", (DataTable)danhSachChiTietDataTable));
        }

        private void frmInPhieuNhap_Load(object sender, EventArgs e)
        {
            //code cũ
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuNhap.TongTien.ToString())));

            /*
            this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuNhapBindingSource.DataSource = m_PhieuNhap;
            this.reportViewer.RefreshReport();
            */

            danhSachPhieuNhapDataTable.Clear();
            danhSachChiTietDataTable.Clear();

            danhSachPhieuNhapDataTable.AddPhieuNhapRow(
                m_PhieuNhap.Id,                
                m_PhieuNhap.NgayNhap,
                m_PhieuNhap.TongTien,
                m_PhieuNhap.NhaCungCap.HoTen
            );

            foreach (var ct in m_PhieuNhap.ChiTiet)
            {
                danhSachChiTietDataTable.AddChiTietPhieuNhapRow(
                    ct.SanPham.TenSanPham,
                    ct.Id,
                    ct.GiaNhap,
                    ct.SoLuong,
                    ct.ThanhTien,
                    ct.NgaySanXuat,
                    ct.NgayHetHan
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CHND_PhieuNhap";
            reportDataSource.Value = danhSachPhieuNhapDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptPhieuNhap.rdlc");

            reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            reportViewer.LocalReport.SetParameters(param);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}