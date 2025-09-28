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
    public partial class frmSoLuongTon : Form
    {
        private Dataset.CHND.SoLuongTonDataTable danhSachSanPhamDataTable = new Dataset.CHND.SoLuongTonDataTable();
        private string reportsFolder = Application.StartupPath.Replace("bin\\Debug", "Report");
        public frmSoLuongTon()
        {
            InitializeComponent();
        }

        private void frmSoLuongTon_Load(object sender, EventArgs e)
        {
            /*
             * Code cu
            IList<CuahangNongduoc.BusinessObject.SoLuongTon> data = CuahangNongduoc.Controller.SanPhamController.LaySoLuongTon();
            this.SoLuongTonBindingSource.DataSource = data;
            this.reportViewer.RefreshReport();
            */

            IList<CuahangNongduoc.BusinessObject.SoLuongTon> data = CuahangNongduoc.Controller.SanPhamController.LaySoLuongTon();

            danhSachSanPhamDataTable.Clear();
            foreach (var row in data)
            {
                danhSachSanPhamDataTable.AddSoLuongTonRow
                    (
                    row.SanPham.Id,
                    row.SanPham.TenSanPham,
                    row.SoLuong,
                    row.SanPham.DonGiaNhap,
                    row.SanPham.GiaBanSi,
                    row.SanPham.GiaBanLe,
                    row.SanPham.DonViTinh.Id,
                    row.SanPham.DonViTinh.Ten,
                    row.SoLuong
                    );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "dsCHND";
            reportDataSource.Value = danhSachSanPhamDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptSoLuongTon.rdlc");
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}