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
    public partial class frmInDunoKhachHang : Form
    {
        CuahangNongduoc.BusinessObject.DuNoKhachHang m_DuNo;
        private Dataset.CHND.DuNoKhachHangDataTable danhSachDuNoKhachHangDataTable = new Dataset.CHND.DuNoKhachHangDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmInDunoKhachHang(CuahangNongduoc.BusinessObject.DuNoKhachHang  dn)
        {
            InitializeComponent();
            m_DuNo = dn;
        }

        private void frmInDunoKhachHang_Load(object sender, EventArgs e)
        {
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_DuNo.CuoiKy.ToString())));

            /*this.reportViewer.LocalReport.SetParameters(param);
            this.DuNoKhachHangBindingSource.DataSource = m_DuNo;
            this.reportViewer.RefreshReport();*/

            danhSachDuNoKhachHangDataTable.Clear();

            danhSachDuNoKhachHangDataTable.AddDuNoKhachHangRow(
                m_DuNo.CuoiKy,
                m_DuNo.DaTra,
                m_DuNo.DauKy,
                m_DuNo.PhatSinh,
                m_DuNo.Thang,
                m_DuNo.Nam,
                m_DuNo.KhachHang.HoTen,
                m_DuNo.KhachHang.DiaChi,
                m_DuNo.KhachHang.DienThoai
            );

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CHND_DuNoKhachHang";
            reportDataSource.Value = danhSachDuNoKhachHangDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptDuNoKhachHang.rdlc");

            reportViewer.LocalReport.SetParameters(param);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}