using CuahangNongduoc.Service.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class frmUserManagement : Form
    {
        private UserService _userService = UserService.Instance;
        private MutateUser _frmMutateUser = null;
        public frmUserManagement()
        {
            InitializeComponent();
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false;

            addColumn();
            loadData();
            styleDataGridView();
        }
        private void styleDataGridView()
        {
            dgvMain.BorderStyle = BorderStyle.None;
            dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvMain.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMain.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvMain.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvMain.BackgroundColor = Color.White;

            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.RowTemplate.Height = 30;
        }
        private void addColumn()
        {
            dgvMain.Columns.Clear();
            List<DataGridViewColumn> list = new List<DataGridViewColumn>()
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "ID",
                    DataPropertyName = "ID",
                    Visible = false,
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "Name",
                    HeaderText = "Họ tên",
                    DataPropertyName = "Name"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "Account",
                    HeaderText = "Tài khoản",
                    DataPropertyName = "Account"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "PhoneNumber",
                    HeaderText = "Số điện thoại",
                    DataPropertyName = "PhoneNumber",

                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "RoleID",
                    DataPropertyName = "RoleID",
                    Visible = false
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "RoleName",
                    DataPropertyName = "RoleName",
                    HeaderText = "Chức vụ"
                }
            };

            dgvMain.Columns.AddRange(list.ToArray());
            // ======= Cột hình nút Sửa =========
            DataGridViewImageColumn editCol = new DataGridViewImageColumn();
            editCol.Name = "Edit";
            editCol.HeaderText = "";
            editCol.Image = Properties.Resources.sua1; // ảnh từ Resources
            editCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editCol.Width = 20;
            dgvMain.Columns.Add(editCol);

            // ======= Cột hình nút Xóa =========
            DataGridViewImageColumn deleteCol = new DataGridViewImageColumn();
            deleteCol.Name = "Delete";
            deleteCol.HeaderText = "";
            deleteCol.Image = Properties.Resources.xoa1;
            deleteCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteCol.Width = 20;
            dgvMain.Columns.Add(deleteCol);
        }
        private void loadData()
        {
            var data = _userService.getAll();
            dgvMain.DataSource = null;
            dgvMain.DataSource = data;
        }
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua header

            // Lấy ID của dòng được click
            int id = Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells["ID"].Value);

            // Nếu click vào cột Sửa
            if (dgvMain.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (_frmMutateUser != null)
                {
                    _frmMutateUser.Close();
                    _frmMutateUser.Dispose();
                }
                _frmMutateUser = new MutateUser(id);
                _frmMutateUser.FormClosed += (s, ev) => { this.loadData(); };
                _frmMutateUser.ShowDialog();
            }

            // Nếu click vào cột Xóa
            else if (dgvMain.Columns[e.ColumnIndex].Name == "Delete")
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa người dùng này?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _userService.delete(id);
                    loadData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_frmMutateUser != null)
            {
                _frmMutateUser.Close();
                _frmMutateUser.Dispose();
            }
            _frmMutateUser = new MutateUser();
            _frmMutateUser.FormClosed += (s, ev) => { this.loadData(); };
            _frmMutateUser.ShowDialog();
        }
    }
}
