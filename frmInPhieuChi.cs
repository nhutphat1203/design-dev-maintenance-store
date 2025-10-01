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
    public partial class frmInPhieuChi : Form
    {
        CuahangNongduoc.BusinessObject.PhieuChi m_PhieuChi;
        private Dataset.CHND.PhieuChiDataTable dataTable = new Dataset.CHND.PhieuChiDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmInPhieuChi(CuahangNongduoc.BusinessObject.PhieuChi ph)
        {
            InitializeComponent();
            m_PhieuChi = ph;
        }

        private void frmInPhieuChi_Load(object sender, EventArgs e)
        {
            Num2Str num = new Num2Str();
            IList<Microsoft.Reporting.WinForms.ReportParameter> param = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            CuahangNongduoc.BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("ten_cua_hang", ch.TenCuaHang));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dia_chi", ch.DiaChi));
            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("dien_thoai", ch.DienThoai));

            param.Add(new Microsoft.Reporting.WinForms.ReportParameter("bang_chu", num.NumberToString(m_PhieuChi.TongTien.ToString())));
            
            dataTable.Clear();
            dataTable.AddPhieuChiRow(m_PhieuChi.Id, m_PhieuChi.LyDoChi.LyDo, m_PhieuChi.NgayChi, m_PhieuChi.TongTien, m_PhieuChi.GhiChu);

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCHND";
            reportDataSource.Value = dataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptPhieuChi.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.LocalReport.SetParameters(param);
            reportViewer.RefreshReport();

        }
    }
}