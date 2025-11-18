using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmInDanhSachDunoKhachHang : Form
    {
        List<CuahangNongduoc.BusinessObject.DuNoKhachHang> m_DuNo;
        private Dataset.CHND.DuNoKhachHangDataTable danhSachDuNoKhachHangDataTable = new Dataset.CHND.DuNoKhachHangDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmInDanhSachDunoKhachHang(List<CuahangNongduoc.BusinessObject.DuNoKhachHang> dn)
        {
            InitializeComponent();
            m_DuNo = dn;
        }

        private void frmInDanhSachDunoKhachHang_Load(object sender, EventArgs e)
        {
            /*this.reportViewer.LocalReport.SetParameters(param);
            this.DuNoKhachHangBindingSource.DataSource = m_DuNo;
            this.reportViewer.RefreshReport();*/

            danhSachDuNoKhachHangDataTable.Clear();

            foreach (var dn in m_DuNo)
            {
                danhSachDuNoKhachHangDataTable.AddDuNoKhachHangRow(
                    dn.CuoiKy,
                    dn.DaTra,
                    dn.DauKy,
                    dn.PhatSinh,
                    dn.Thang,
                    dn.Nam,
                    dn.KhachHang.HoTen,
                    dn.KhachHang.DiaChi,
                    dn.KhachHang.DienThoai
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CHND_DuNoKhachHang";
            reportDataSource.Value = danhSachDuNoKhachHangDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptDsDuNoKhachHang.rdlc");

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}
