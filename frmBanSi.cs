using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;
using CuahangNongduoc.BusinessObject;

namespace CuahangNongduoc
{
    public partial class frmBanSi: Form
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        KhachHangController ctrlKhachHang = new KhachHangController();
        MaSanPhamController ctrlMaSanPham = new MaSanPhamController();
        PhieuBanController ctrlPhieuBan = new PhieuBanController();
        ChiTietPhieuBanController ctrlChiTiet = new ChiTietPhieuBanController();
        SoLuongTonLoController ctrlTonLo = new SoLuongTonLoController();
        IList<MaSanPham> deleted = new List<MaSanPham>();


        Controll status = Controll.Normal;

        public frmBanSi()
        {
            InitializeComponent();
            
            status = Controll.AddNew;
        }


        public frmBanSi(PhieuBanController ctrlPB)
            : this()
        {
            this.ctrlPhieuBan = ctrlPB;
            status = Controll.Normal;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {

            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
            ctrlMaSanPham.HienThiDataGridViewComboBox(colMaSanPham);
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, true);

            cmbSanPham.SelectedIndexChanged += new EventHandler(cmbSanPham_SelectedIndexChanged);
            ctrlPhieuBan.HienthiPhieuBan(bindingNavigator, cmbKhachHang, txtMaPhieu, dtNgayLapPhieu, numTongTien, numDaTra, numConNo);

            bindingNavigator.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            bindingNavigator.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);

            if (status == Controll.AddNew)
            {
                txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
                Allow(true);
            }
            else
            {
                Allow(false);
            }

            if (cmbSanPham.Items.Count > 0)
            {
                toolcmbPPXuat.SelectedIndex = 0;
                toolcmbPPXuat_SelectedIndexChanged(sender, e);
                cmbSanPham.SelectedIndex = 0;
                cmbSanPham_SelectedIndexChanged(cmbSanPham, EventArgs.Empty);
                cmbMaSanPham.SelectedIndex = 0;
                cmbMaSanPham_SelectedIndexChanged(sender, e);
                cmbTinhDonGia.SelectedIndex = 0;
            }
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (status == Controll.Normal)
            {
                ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            }
        }


        void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMaSanPham.Enabled = true;
            if (cmbSanPham.SelectedValue != null)
            {
                MaSanPhamController ctrlMSP = new MaSanPhamController();

                cmbMaSanPham.SelectedIndexChanged -= cmbMaSanPham_SelectedIndexChanged;
                if (toolcmbPPXuat.Text == "Nhập trước xuất trước (FIFO)")
                    ctrlMSP.HienThiAutoComboBoxFIFO(cmbSanPham.SelectedValue.ToString(), cmbMaSanPham);
                else
                    ctrlMSP.HienThiAutoComboBox(cmbSanPham.SelectedValue.ToString(), cmbMaSanPham);

                cmbMaSanPham.SelectedIndexChanged += cmbMaSanPham_SelectedIndexChanged;

                if (cmbMaSanPham.Items.Count > 0)
                    cmbMaSanPham_SelectedIndexChanged(sender, e);
                else
                    cmbMaSanPham.Text = "";
            }

            if (toolcmbPPXuat.Text == "Nhập trước xuất trước (FIFO)")
                cmbMaSanPham.Enabled = false;
        }

        void cmbMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbMaSanPham.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn Mã số!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string idMaSanPham = cmbMaSanPham.SelectedValue.ToString();
                MaSanPhamController ctrl = new MaSanPhamController();
                MaSanPham masp = ctrl.LayMaSanPham(idMaSanPham);
                //numDonGia.Value = masp.SanPham.GiaBanSi;
                txtGiaNhap.Text = masp.GiaNhap.ToString("#,###0");
                txtSLTonLo.Text = ctrlTonLo.LaySoLuongTon(idMaSanPham).ToString("#,###0");
                txtGiaBanSi.Text = masp.SanPham.GiaBanSi.ToString("#,###0");
                txtGiaBQGQ.Text = masp.SanPham.DonGiaNhap.ToString("#,###0");
                txtNgayNhap.Text = masp.NgayNhap.ToString("dd/MM/yyyy");
                txtNgayHetHan.Text = masp.NgayHetHan.ToString("dd/MM/yyyy");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (cmbSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbTinhDonGia.Text))
            {
                MessageBox.Show("Vui lòng chọn phương pháp tính đơn giá!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbMaSanPham.Text.ToString()))
            {
                MessageBox.Show("Vui lòng chọn mã số!", "Phiếu Bán Lẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idSanPham = cmbSanPham.SelectedValue.ToString();
            int soLuongCan = (int)numSoLuong.Value;
            string phuongPhap = toolcmbPPXuat.Text;
            int soLuongConLai;
            decimal donGia = cmbTinhDonGia.Text == "BQGQ" ? decimal.Parse(txtGiaBQGQ.Text) : decimal.Parse(txtGiaBanSi.Text);

            if (phuongPhap == "Nhập trước xuất trước (FIFO)")
            {
                DataTable dsLo = ctrlSanPham.LayNhieuLoHangFIFO(idSanPham);
                soLuongConLai = soLuongCan;

                if (dsLo.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn hàng tồn cho sản phẩm này!", "Thông báo");
                    return;
                }

                foreach (DataRow lo in dsLo.Rows)
                {
                    int tonLo = Convert.ToInt32(lo["SO_LUONG_TON"]);
                    int xuat = Math.Min(soLuongConLai, tonLo);

                    DataRow row = ctrlChiTiet.NewRow();
                    row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                    row["ID_MA_SAN_PHAM"] = lo["ID_MA_SAN_PHAM"];
                    row["DON_GIA"] = donGia;
                    row["SO_LUONG"] = xuat;
                    row["THANH_TIEN"] = xuat * donGia;
                    ctrlChiTiet.Add(row);

                    numTongTien.Value += xuat * donGia;
                    soLuongConLai -= xuat;

                    if (soLuongConLai <= 0)
                        break;
                }

                if (soLuongConLai > 0)
                    MessageBox.Show($"Không đủ hàng! Còn thiếu {soLuongConLai} sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cmbMaSanPham.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn lô hàng cần xuất!", "Phiếu Bán Sỉ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                soLuongConLai = ctrlTonLo.LaySoLuongTon(cmbMaSanPham.SelectedValue.ToString());
                if (soLuongConLai < numSoLuong.Value)
                {
                    MessageBox.Show("Lô hàng không đủ số lượng!", "Phiếu Bán Sỉ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = ctrlChiTiet.NewRow();
                row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                row["ID_MA_SAN_PHAM"] = cmbMaSanPham.SelectedValue;
                row["DON_GIA"] = donGia;
                row["SO_LUONG"] = numSoLuong.Value;
                row["THANH_TIEN"] = numSoLuong.Value * donGia;
                ctrlChiTiet.Add(row);
                numTongTien.Value += numSoLuong.Value * donGia;
            }
        }

        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTinhDonGia.Text != null || cmbTinhDonGia.Text != "")
            {
                decimal DonGia = cmbTinhDonGia.Text == "BQGQ" ? decimal.Parse(txtGiaBQGQ.Text) : decimal.Parse(txtGiaBanSi.Text);
                numThanhTien.Value = DonGia * numSoLuong.Value;
            }
            else
                MessageBox.Show("Vui lòng chọn phương pháp tính đơn giá!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void numTongTien_ValueChanged(object sender, EventArgs e)
        {
            numDaTra.Maximum = numTongTien.Value;

            if (numDaTra.Value > numDaTra.Maximum)
                numDaTra.Value = numDaTra.Maximum;
            else
            {
                decimal conno = numTongTien.Value - numDaTra.Value;
                if (conno <= 0)
                    numConNo.Value = 0;
                else
                    numConNo.Value = conno;
            }
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            bindingNavigatorPositionItem.Focus();
            this.Luu();
            status = Controll.Normal;
            this.Allow(false);

        }
        void Luu()
        {
            if (status == Controll.AddNew)
            {
                ThemMoi();
            }
            else
            {
                CapNhat();
            }
        }
        void CapNhat()
        {
            foreach (MaSanPham masp in deleted)
                ctrlTonLo.TangSoLuongTon(masp.Id, masp.SoLuong);
            deleted.Clear();

            ctrlChiTiet.Save();

            foreach (DataRow row in ctrlChiTiet.Data.Rows)
            {
                string idMaSP = row["ID_MA_SAN_PHAM"].ToString();
                int soLuong = Convert.ToInt32(row["SO_LUONG"]);
                ctrlTonLo.GiamSoLuongTon(idMaSP, soLuong);
            }

            ctrlTonLo.Save();
            ctrlPhieuBan.Update();
        }
        void ThemMoi()
        {
            DataRow row = ctrlPhieuBan.NewRow();
            row["ID"] = txtMaPhieu.Text;
            row["ID_KHACH_HANG"] = cmbKhachHang.SelectedValue;
            row["NGAY_BAN"] = dtNgayLapPhieu.Value.Date;
            row["TONG_TIEN"] = numTongTien.Value;
            row["DA_TRA"] = numDaTra.Value;
            row["CON_NO"] = numConNo.Value;
            ctrlPhieuBan.Add(row);

            PhieuBanController ctrl = new PhieuBanController();

            if (ctrl.LayPhieuBan(txtMaPhieu.Text) != null)
            {
                MessageBox.Show("Mã Phiếu bán này đã tồn tại !", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ThamSo.LaSoNguyen(txtMaPhieu.Text))
            {
                long so = Convert.ToInt64(txtMaPhieu.Text);
                if (so >= ThamSo.LayMaPhieuBan())
                {
                    ThamSo.GanMaPhieuBan(so + 1);
                }
            }

            ctrlPhieuBan.Save();

            ctrlChiTiet.Save();

            foreach (DataRow chiTietRow in ctrlChiTiet.Data.Rows)
            {
                string idMaSP = chiTietRow["ID_MA_SAN_PHAM"].ToString();
                int soLuong = Convert.ToInt32(chiTietRow["SO_LUONG"]);
                ctrlTonLo.GiamSoLuongTon(idMaSP, soLuong);
            }

            ctrlTonLo.Save();
        }

        private void toolLuu_Them_Click(object sender, EventArgs e)
        {
            ctrlPhieuBan = new PhieuBanController();
            status = Controll.AddNew;
            txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            numTongTien.Value = 0;
            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);
            this.Allow(true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvDanhsachSP.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BindingSource bs = ((BindingSource)dgvDanhsachSP.DataSource);
                    DataRowView row = (DataRowView)bs.Current;
                    numTongTien.Value -= Convert.ToInt64(row["THANH_TIEN"]);
                    deleted.Add(new MaSanPham(Convert.ToString(row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])));
                    bs.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("Danh sách rỗng!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dgvDanhsachSP_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                BindingSource bs = ((BindingSource)dgvDanhsachSP.DataSource);
                DataRowView row = (DataRowView)bs.Current;
                numTongTien.Value -= Convert.ToInt64(row["THANH_TIEN"]);
                deleted.Add(new MaSanPham(Convert.ToString( row["ID_MA_SAN_PHAM"]), Convert.ToInt32(row["SO_LUONG"])) );
            }
        }

        private void toolLuuIn_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                MessageBox.Show("Vui lòng lưu lại Phiếu bán hiện tại!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                String ma_phieu = txtMaPhieu.Text;

                PhieuBanController ctrlPB = new PhieuBanController();

                CuahangNongduoc.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);

                frmInPhieuBan InPhieuBan = new frmInPhieuBan(ph);

                InPhieuBan.Show();

            }
        }

        private void dgvDanhsachSP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void toolChinhSua_Click(object sender, EventArgs e)
        {
            status = Controll.Edit;
            this.Allow(true);
        }

        void Allow(bool val)
        {
            //txtMaPhieu.Enabled = val;
            dtNgayLapPhieu.Enabled = val;
            //numTongTien.Enabled = val;
            btnAdd.Enabled = val;
            if (dgvDanhsachSP.RowCount > 0)
                btnRemove.Enabled = val;
            else
                btnRemove.Enabled = false;
            //dgvDanhsachSP.Enabled = val;
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            if (status != Controll.Normal)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại Phiếu bán này không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Luu();
                }

            }
            this.Close();
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
             DataRowView view =  (DataRowView)bindingNavigator.BindingSource.Current;
             if (view != null)
             {
                 if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                    ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                    IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(view["ID"].ToString());
                    foreach (ChiTietPhieuBan ct in ds)
                    {
                        ctrlTonLo.TangSoLuongTon(ct.MaSanPham.Id, ct.SoLuong);
                    }
                    bindingNavigator.BindingSource.RemoveCurrent();
                    ctrlPhieuBan.Save();
                }
             }
        }

        private void btnThemDaiLy_Click(object sender, EventArgs e)
        {
            frmDaiLy DaiLy = new frmDaiLy();
            DaiLy.ShowDialog();
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, true);
            
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham SanPham = new frmSanPham();
            SanPham.ShowDialog();
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
        }

        private void toolcmbPPXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolcmbPPXuat.Text == "Nhập trước xuất trước (FIFO)")
                cmbMaSanPham.Enabled = false;
            else
                cmbMaSanPham.Enabled = true;
            cmbSanPham.SelectedIndex = 0;
            cmbSanPham_SelectedIndexChanged(sender, e);
        }

        private void cmbTinhDonGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            numDonGia_ValueChanged(sender, e);
        }

        private void dgvDanhsachSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhsachSP.CurrentRow != null && dgvDanhsachSP.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvDanhsachSP.CurrentRow;

                if (row.Cells["colMaSanPham"].Value != null)
                {
                    string idMaSanPham = row.Cells["colMaSanPham"].Value.ToString();

                    MaSanPhamController ctrlMSP = new MaSanPhamController();
                    MaSanPham masp = ctrlMSP.LayMaSanPham(idMaSanPham);

                    if (masp != null)
                    {
                        cmbSanPham.SelectedValue = masp.SanPham.Id;

                        ctrlMSP.HienThiAutoComboBox(masp.SanPham.Id, cmbMaSanPham);
                        cmbMaSanPham.SelectedValue = masp.Id;

                        if (row.Cells["colSoLuong"].Value != null)
                        {
                            numSoLuong.Value = Convert.ToDecimal(row.Cells["colSoLuong"].Value);
                            numDonGia_ValueChanged(sender, e);
                        }
                    }
                }
            }
        }
    }
}
