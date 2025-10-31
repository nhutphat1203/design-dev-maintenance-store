using CuahangNongduoc.DTO;
using CuahangNongduoc.Entities;
using CuahangNongduoc.Service.Auth;
using CuahangNongduoc.Utils.Hasher;
using CuahangNongduoc.AppEventArgs;
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
    public partial class frmAuth : Form
    {
        public event EventHandler<AuthEventArgs> LoginSuccess;

        private IAuthService _authService = AuthService.Instance;
        public bool IsAuthenticated { get; private set; } = false;

        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();
            AuthInfo info = _authService.Login(username, password);

            if (info.AuthStatus == AuthStatus.NoExistent)
            {
                MessageBox.Show("Không tồn tại tài khoản này!");
            }
            else if (info.AuthStatus == AuthStatus.WrongPassword)
            {
                MessageBox.Show("Mật khẩu không đúng!");
            }
            else
            {
                IsAuthenticated = true;
                LoginSuccess.Invoke(this, new AuthEventArgs(info.User));
            }
        }

        private void frmAuth_Load(object sender, EventArgs e)
        {
            
        }
    }

}
