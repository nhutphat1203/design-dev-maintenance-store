using CuahangNongduoc.Entities;
using CuahangNongduoc.Service.Role;
using CuahangNongduoc.Service.User;
using CuahangNongduoc.Utils.Hasher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace CuahangNongduoc
{
    public partial class MutateUser : Form
    {
        private bool _isEdit = false;
        private IUserService _userService = UserService.Instance;
        private IHasher _passwordHasher = PasswordHasher.Instance;
        private IRoleService _roleService = RoleService.Instance;
        private int id = -1;
        private User _user;
        public MutateUser(int id = -1)
        {
            InitializeComponent();
            this.id = id;
        }

        private void MutateUser_Load(object sender, EventArgs e)
        {
            _isEdit = id != -1;

            cboRole.DisplayMember = "Name";
            cboRole.ValueMember = "ID";
            cboRole.DataSource = _roleService.getAll();

            if (_isEdit)
            {
                pnlPassword.Visible = false;
                attachInfo();
            }
            else
            {
                pnlPassword.Visible = true;
            }
        }
        private void attachInfo()
        {
            var user = _userService.getById(id);
            if (user == null)
            {
                MessageBox.Show("Không có người dùng này!");
                return;
            }
            _user = user;
            txtID.Text = user.ID.ToString();
            txtName.Text = user.Name.ToString();
            txtAccount.Text = user.Account;
            txtPN.Text = user.PhoneNumber;
        }
        private void update()
        {
            _user.PhoneNumber = txtPN.Text;
            _user.Account = txtAccount.Text;
            _user.Name = txtName.Text;
            _user.RoleID = int.Parse(cboRole.SelectedValue.ToString());
            _userService.update(_user);
            _user = null;
        }
        private void add()
        {
            User user = new User
            {
                Account = txtAccount.Text,
                PasswordHash = _passwordHasher.hash(txtPassword.Text),
                PhoneNumber = txtPN.Text,
                Name = txtName.Text,
                RoleID = int.Parse(cboRole.SelectedValue.ToString())
            };
            _userService.add(user);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_isEdit)
            {
                update();
            }
            else
            {
                add();
            }
            this.Close();
        }
    }
}
