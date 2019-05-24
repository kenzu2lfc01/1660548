using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Parent = this;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Parent = this;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Parent = this;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int type = BUS.BUS_Users.Instance.CheckLogin(txtUserID, txtPassword);
            if(type != 0)
            {
                List<int> role = BUS.BUS_Users.Instance.Users_FillListRole(txtUserID.Text);
                frm_Main frmMain = new frm_Main(this,role);
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
