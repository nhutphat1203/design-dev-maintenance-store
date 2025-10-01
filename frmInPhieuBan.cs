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
    public partial class frmInPhieuBan : Form
    {
        CuahangNongduoc.BusinessObject.PhieuBan m_PhieuBan; //code cũ
        private Dataset.CHND.PhieuBanDataTable danhSachPhieuBanDataTable = new Dataset.CHND.PhieuBanDataTable();
        private Dataset.CHND.ChiTietPhieuBanDataTable danhSachChiTietDataTable = new Dataset.CHND.ChiTietPhieuBanDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");

        public frmInPhieuBan(CuahangNongduoc.BusinessObject.PhieuBan ph)
        {
            InitializeComponent();
            //code cũ
            /*reportViewer.LocalReport.ExecuteReportInCurrentAppDomain(System.Reflection.Assembly.GetExecutingAssembly().Evidence);
            this.reportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            */
            m_PhieuBan = ph;
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Clear();
            //e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CuahangNongduoc_BusinessObject_ChiTietPhieuBan", m_PhieuBan.ChiTiet)); // code cũ
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("CHND_ChiTietPhieuBan", (DataTable)danhSachChiTietDataTable));
        }

        private void frmInPhieuBan_Load(object sender, EventArgs e)
        {
            //code cũ
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuBan.TongTien.ToString())));

            /*this.reportViewer.LocalReport.SetParameters(param);
            this.PhieuBanBindingSource.DataSource = m_PhieuBan;
            this.reportViewer.RefreshReport();*/

            danhSachPhieuBanDataTable.Clear();
            danhSachChiTietDataTable.Clear();

            danhSachPhieuBanDataTable.AddPhieuBanRow(
                m_PhieuBan.Id,
                m_PhieuBan.NgayBan,
                m_PhieuBan.TongTien,
                m_PhieuBan.DaTra,
                m_PhieuBan.ConNo,
                m_PhieuBan.KhachHang.HoTen,
                m_PhieuBan.KhachHang.DiaChi,
                m_PhieuBan.KhachHang.DienThoai
            );

            foreach (var ct in m_PhieuBan.ChiTiet)
            {
                danhSachChiTietDataTable.AddChiTietPhieuBanRow(
                    ct.MaSanPham.Id,
                    ct.DonGia,
                    ct.SoLuong,
                    ct.ThanhTien
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CHND_PhieuBan";
            reportDataSource.Value = danhSachPhieuBanDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptPhieuBan.rdlc");

            reportViewer.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

            reportViewer.LocalReport.SetParameters(param);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}