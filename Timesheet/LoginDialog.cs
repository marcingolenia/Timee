using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timesheet
{
    public partial class LoginDialog : Form
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
           // txtLogin.Text = Environment.UserName;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Login = txtLogin.Text;
            this.Password = txtPassword.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
