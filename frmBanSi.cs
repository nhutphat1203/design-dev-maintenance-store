using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CuahangNongduoc.Controller;
using CuahangNongduoc.BusinessObject;
using System.Linq;
using CuahangNongduoc.GiamGia;

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
        PhuPhiController ctrlPhuPhi = new PhuPhiController();
        ChietKhauController ctrlChietKhau = new ChietKhauController();
        GiamGiaController ctrlGiamGia = new GiamGiaController();
        IList<MaSanPham> deleted = new List<MaSanPham>();
        IList<MaSanPham> added = new List<MaSanPham>();

        Controll status = Controll.Normal;

        public frmBanSi()
        {
            InitializeComponent();
            
            status = Controll.AddNew;
        }


        public frmBanSi(string maPhieu)
            : this()
        {
            txtMaPhieu.Text = maPhieu;
            status = Controll.Normal;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {

            ctrlSanPham.HienthiAutoComboBox(cmbSanPham);
            ctrlMaSanPham.HienThiDataGridViewComboBox(colMaSanPham);

            cmbSanPham.SelectedIndexChanged += new EventHandler(cmbSanPham_SelectedIndexChanged);

            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang, true);
            if (cmbKhachHang.Items.Count > 0)
                cmbKhachHang.SelectedIndex = 0;
            //ctrlPhieuBan.HienthiPhieuBan(bindingNavigator, cmbKhachHang, txtMaPhieu, dtNgayLapPhieu, numTongTien, numDaTra, numConNo);

            //bindingNavigator.BindingSource.CurrentChanged -= new EventHandler(BindingSource_CurrentChanged);
            //bindingNavigator.BindingSource.CurrentChanged += new EventHandler(BindingSource_CurrentChanged);

            ctrlChiTiet.HienThiChiTiet(dgvDanhsachSP, txtMaPhieu.Text);

            if (status == Controll.AddNew)
            {
                txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
                Allow(true);
                cmbLoaiGiaTri.SelectedIndex = 0;
                txtSoTienGiamCK.Text = "0";
            }
            else
            {
                Allow(false);
                LoadPhieuBan();
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
            decimal giaTri = ctrlChietKhau.LayChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString());
            if (giaTri <= 1)
                txtGiaTriCK.Text = (giaTri * 100).ToString() + "%";
            else
                txtGiaTriCK.Text = giaTri.ToString("#,###0");
        }

        private void toolXemLai_Click(object sender, EventArgs e)
        {
            if (ctrlPhieuBan.TonTaiPhieuBan(txtMaPhieu.Text))
            {
                Allow(false);
                LoadPhieuBan();
            }
            else
            {
                cmbSanPham.SelectedIndex = 0;
                cmbMaSanPham.SelectedIndex = 0;
                cmbTinhDonGia.SelectedIndex = 0;
                numSoLuong.Value = 0;
                cmbKhachHang.SelectedIndex = 0;
                dtNgayLapPhieu.Value = DateTime.Now;
            }
        }

        void LoadPhieuBan()
        {
            DataTable dt = ctrlPhieuBan.HienThiPhieuBan(txtMaPhieu.Text);
            dtNgayLapPhieu.Value = Convert.ToDateTime(dt.Rows[0]["NGAY_BAN"]);
            cmbKhachHang.SelectedValue = dt.Rows[0]["ID_KHACH_HANG"].ToString();
            numTongTienCuoi.Value = Convert.ToDecimal(dt.Rows[0]["TONG_TIEN"]);
            numDaTra.Value = Convert.ToDecimal(dt.Rows[0]["DA_TRA"]);
            numConNo.Value = Convert.ToDecimal(dt.Rows[0]["CON_NO"]);

            cmbLoaiGiaTri.SelectedIndex = ctrlGiamGia.LayLoaiTheoPhieuBan(txtMaPhieu.Text) ? 1 : 0;

            txtSoTienGiamCK.Text = ctrlChietKhau.LayChietKhauApDung(txtMaPhieu.Text).ToString("#,###0");
            txtSoTienGiamGia.Text = ctrlGiamGia.LayTheoPhieuBan(txtMaPhieu.Text).ToString("#,###0");
            txtTongPhuPhi.Text = ctrlPhuPhi.TongTien(txtMaPhieu.Text).ToString("#,###0");

            numTongTien.Value = numTongTienCuoi.Value + decimal.Parse(txtSoTienGiamCK.Text) + decimal.Parse(txtSoTienGiamGia.Text) - decimal.Parse(txtTongPhuPhi.Text);
            if (cmbLoaiGiaTri.SelectedIndex == 0)
                numGiaTriGiamGia.Value = (decimal.Parse(txtSoTienGiamGia.Text) / numTongTien.Value) * 100;
            else
                numGiaTriGiamGia.Value = decimal.Parse(txtSoTienGiamGia.Text);
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
                    string idLo = lo["ID_MA_SAN_PHAM"].ToString();

                    if (DaTonTaiSanPham(idLo))
                    {
                        DataRow existing = ctrlChiTiet.Data.Rows
                            .Cast<DataRow>()
                            .First(r => r["ID_MA_SAN_PHAM"].ToString() == idLo);

                        int slHienTai = Convert.ToInt32(existing["SO_LUONG"]);
                        existing["SO_LUONG"] = slHienTai + xuat;
                        existing["THANH_TIEN"] = (slHienTai + xuat) * donGia;
                    }
                    else
                    {
                        DataRow row = ctrlChiTiet.NewRow();
                        row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                        row["ID_MA_SAN_PHAM"] = idLo;
                        row["DON_GIA"] = donGia;
                        row["SO_LUONG"] = xuat;
                        row["THANH_TIEN"] = xuat * donGia;
                        ctrlChiTiet.Add(row);
                    }

                    added.Add(new MaSanPham(idLo, xuat));

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

                string idLo = cmbMaSanPham.SelectedValue.ToString();
                soLuongConLai = ctrlTonLo.LaySoLuongTon(idLo);
                if (soLuongConLai < numSoLuong.Value)
                {
                    MessageBox.Show("Lô hàng không đủ số lượng!", "Phiếu Bán Sỉ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DaTonTaiSanPham(idLo))
                {
                    DataRow existing = ctrlChiTiet.Data.Rows
                        .Cast<DataRow>()
                        .First(r => r["ID_MA_SAN_PHAM"].ToString() == idLo);

                    int slHienTai = Convert.ToInt32(existing["SO_LUONG"]);
                    existing["SO_LUONG"] = slHienTai + Convert.ToInt32(numSoLuong.Value);
                    existing["THANH_TIEN"] = (slHienTai + Convert.ToInt32(numSoLuong.Value)) * donGia;
                }
                else
                {
                    DataRow row = ctrlChiTiet.NewRow();
                    row["ID_PHIEU_BAN"] = txtMaPhieu.Text;
                    row["ID_MA_SAN_PHAM"] = idLo;
                    row["DON_GIA"] = donGia;
                    row["SO_LUONG"] = numSoLuong.Value;
                    row["THANH_TIEN"] = numSoLuong.Value * donGia;
                    ctrlChiTiet.Add(row);
                }

                added.Add(new MaSanPham(idLo, Convert.ToInt32(numSoLuong.Value)));

                numTongTien.Value += numSoLuong.Value * donGia;
            }
            CapNhatTongTien();
        }

        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTinhDonGia.Text != null || cmbTinhDonGia.Text != "")
            {
                if (string.IsNullOrWhiteSpace(txtGiaBQGQ.Text) || string.IsNullOrWhiteSpace(txtGiaBanSi.Text))
                {
                    return;
                }

                decimal DonGia = cmbTinhDonGia.Text == "BQGQ" ? decimal.Parse(txtGiaBQGQ.Text) : decimal.Parse(txtGiaBanSi.Text);
                numThanhTien.Value = DonGia * numSoLuong.Value;
            }
            else
                MessageBox.Show("Vui lòng chọn phương pháp tính đơn giá!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void numTongTien_ValueChanged(object sender, EventArgs e)
        {
            numDaTra.Maximum = numTongTienCuoi.Value;

            if (numDaTra.Value > numDaTra.Maximum)
                numDaTra.Value = numDaTra.Maximum;
            else
            {
                decimal conno = numTongTienCuoi.Value - numDaTra.Value;
                if (conno <= 0)
                    numConNo.Value = 0;
                else
                    numConNo.Value = conno;
            }
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
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
            {
                ctrlTonLo.TangSoLuongTon(masp.Id, masp.SoLuong);
            }
            deleted.Clear();

            foreach (MaSanPham masp in added)
            {
                ctrlTonLo.TangSoLuongTon(masp.Id, masp.SoLuong);
            }
            added.Clear();

            ctrlChiTiet.Save();

            ctrlPhieuBan.Update(txtMaPhieu.Text, numTongTienCuoi.Value, numDaTra.Value, numConNo.Value);
            ctrlChietKhau.CapNhatChietKhauApDung(txtMaPhieu.Text, decimal.Parse(txtSoTienGiamCK.Text));
            bool loai = cmbLoaiGiaTri.SelectedIndex == 0 ? true : false;
            ctrlGiamGia.CapNhat(txtMaPhieu.Text, loai, decimal.Parse(txtSoTienGiamGia.Text));
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
            ctrlChietKhau.CapNhatChietKhauApDung(txtMaPhieu.Text, decimal.Parse(txtSoTienGiamCK.Text));
            bool loai = cmbLoaiGiaTri.SelectedIndex == 0 ? true : false;
            ctrlGiamGia.CapNhat(txtMaPhieu.Text, loai, decimal.Parse(txtSoTienGiamGia.Text));
        }

        private void toolLuu_Them_Click(object sender, EventArgs e)
        {
            ctrlPhieuBan = new PhieuBanController();
            status = Controll.AddNew;
            txtMaPhieu.Text = ThamSo.LayMaPhieuBan().ToString();
            numTongTien.Value = 0;
            numTongTienCuoi.Value = 0;
            cmbLoaiGiaTri.SelectedIndex = 0;
            numGiaTriGiamGia.Value = 0;
            txtSoTienGiamGia.Text = "0";
            txtTongPhuPhi.Text = "0";
            decimal giaTri = ctrlChietKhau.LayChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString());
            if (giaTri <= 1)
                txtGiaTriCK.Text = (giaTri * 100).ToString() + "%";
            else
                txtGiaTriCK.Text = giaTri.ToString("#,###0");
            cmbKhachHang.SelectedIndex = 0;
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
                    CapNhatTongTien();
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
                CapNhatTongTien();
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
            btnThemPhuPhi.Enabled = val;
            btnThemChietKhau.Enabled = val;
            numGiaTriGiamGia.Enabled = val;
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
            if (!ctrlPhieuBan.TonTaiPhieuBan(txtMaPhieu.Text))
            {
                MessageBox.Show("Phiếu bán này không tồn tại!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Si", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                IList<ChiTietPhieuBan> ds = ctrl.ChiTietPhieuBan(txtMaPhieu.Text);
                foreach (ChiTietPhieuBan ct in ds)
                {
                    ctrlTonLo.TangSoLuongTon(ct.MaSanPham.Id, ct.SoLuong);
                }
                ctrlPhieuBan.XoaPhieuBan(txtMaPhieu.Text);
            }
            this.Close();
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

        bool DaTonTaiSanPham(string idMaSP)
        {
            foreach (DataRow r in ctrlChiTiet.Data.Rows)
            {
                if (r.RowState != DataRowState.Deleted && r["ID_MA_SAN_PHAM"].ToString() == idMaSP)
                    return true;
            }
            return false;
        }

        private void btnThemChietKhau_Click(object sender, EventArgs e)
        {
            if (!ctrlPhieuBan.TonTaiPhieuBan(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng lưu Phiếu bán hiện tại!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmChietKhau chietKhau = new frmChietKhau(true);
            chietKhau.ShowDialog();
            decimal giaTri = ctrlChietKhau.LayChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString());
            if (giaTri <= 1)
                txtGiaTriCK.Text = (giaTri * 100).ToString() + "%";
            else
                txtGiaTriCK.Text = giaTri.ToString("#,###0");
            TinhTongTienCuoi();
            toolLuu_Click(sender, e);
        }

        private void btnThemPhuPhi_Click(object sender, EventArgs e)
        {
            if (!ctrlPhieuBan.TonTaiPhieuBan(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng lưu Phiếu bán hiện tại!", "Phieu Ban Si", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmPhuPhi phuPhi = new frmPhuPhi(txtMaPhieu.Text);
            phuPhi.ShowDialog();
            txtTongPhuPhi.Text = ctrlPhuPhi.TongTien(txtMaPhieu.Text).ToString("#,###0");
            TinhTongTienCuoi();
            toolLuu_Click(sender, e);
        }

        void TinhGiamCK(decimal tongCuoi)
        {
            try
            {
                decimal giaTriCK = 0;

                if (cmbKhachHang.SelectedValue != null)
                    giaTriCK = ctrlChietKhau.LayChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString());
                IGiamGiaStrategy strategy;
                GiamGiaContext context;

                if (giaTriCK > 0 && giaTriCK <= 1)
                {
                    strategy = new GiamTheoPhanTram();
                    context = new GiamGiaContext(strategy);
                    txtGiaTriCK.Text = (giaTriCK * 100).ToString() + "%";
                    txtSoTienGiamCK.Text = context.TinhGiam(tongCuoi, giaTriCK * 100).ToString("#,###0");
                }
                else if (giaTriCK > 1 && giaTriCK <= tongCuoi)
                {
                    strategy = new GiamTheoSoTien();
                    context = new GiamGiaContext(strategy);
                    txtGiaTriCK.Text = giaTriCK.ToString("#,###0");
                    txtSoTienGiamCK.Text = context.TinhGiam(tongCuoi, giaTriCK).ToString("#,###0");
                }
                else
                    txtSoTienGiamCK.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính chiết khấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TinhGiamGia()
        {
            try
            {
                if (string.IsNullOrEmpty(cmbLoaiGiaTri.Text))
                {
                    MessageBox.Show("Vui lòng chọn loại giá trị giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal tongTien = numTongTien.Value;
                decimal giaTri = numGiaTriGiamGia.Value;
                IGiamGiaStrategy strategy;

                if (cmbLoaiGiaTri.Text == "Phần trăm (%)")
                {
                    if (giaTri < 0 || giaTri > 100)
                    {
                        MessageBox.Show("Giá trị phần trăm phải nằm trong khoảng 0 - 100!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    strategy = new GiamTheoPhanTram();
                }
                else
                {
                    if (giaTri < 0)
                    {
                        MessageBox.Show("Giá trị giảm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    strategy = new GiamTheoSoTien();
                }
                GiamGiaContext context = new GiamGiaContext(strategy);
                decimal soTienGiamGia = context.TinhGiam(tongTien, giaTri);
                txtSoTienGiamGia.Text = soTienGiamGia.ToString("#,###0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính giảm giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TinhTongTienCuoi()
        {
            decimal tongTien = numTongTien.Value;
            decimal soTienGiamGia = 0;
            decimal.TryParse(txtSoTienGiamGia.Text, out soTienGiamGia);
            decimal tongPhuPhi = 0;
            decimal.TryParse(txtTongPhuPhi.Text, out tongPhuPhi);
            decimal tongCuoi = tongTien - soTienGiamGia + tongPhuPhi;

            decimal soTienChietKhau = 0;
            TinhGiamCK(tongCuoi);
            decimal.TryParse(txtSoTienGiamCK.Text, out soTienChietKhau);

            numTongTienCuoi.Value = tongCuoi - soTienChietKhau;
        }

        void CapNhatTongTien()
        {
            TinhGiamGia();
            TinhTongTienCuoi();
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal giaTri = ctrlChietKhau.LayChietKhauKhachHang(cmbKhachHang.SelectedValue.ToString());
            if (giaTri <= 1)
                txtGiaTriCK.Text = (giaTri * 100).ToString() + "%";
            else
                txtGiaTriCK.Text = giaTri.ToString("#,###0");
        }

        private void numGiaTriGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }
    }
}
