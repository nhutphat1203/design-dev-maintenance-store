using CuahangNongduoc.AppEventArgs;
using CuahangNongduoc.Entities;
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
    public partial class frmManage : Form
    {
        private frmMain _frmMain;
        private frmAuth _frmAuth;
        private frmUserManagement _frmUserManagement;
        private User _user = null;

        public frmManage()
        {
            InitializeComponent();
            this.Load += frmManage_Load;
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            showLogin();
        }

        private void showLogin()
        {
            _frmAuth = new frmAuth();
            _frmAuth.LoginSuccess += onLoginSuccess;
            _frmAuth.FormClosed += (s, e) =>
            {
                if (!_frmAuth.IsAuthenticated)
                    this.Close();
            };
            _frmAuth.ShowDialog();
        }

        private void onLoginSuccess(object sender, AuthEventArgs e)
        {
            _user = e.User;
            _frmAuth.Close();
            _frmMain = new frmMain();
            _frmMain.FormClosed += (s, args) => this.Close();
            showForm();
        }

        private void showForm()
        {
            if (_user.Role.Code == "ADMIN")
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                _frmMain.ShowDialog();
            }
        }

        private void btnBussiness_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _frmMain.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _frmUserManagement = new frmUserManagement();
            _frmUserManagement.FormClosed += (s, ev) =>
            {
                this.Visible = true;
            };
            _frmUserManagement.ShowDialog();
        }
    }

}
