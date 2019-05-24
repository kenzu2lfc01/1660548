using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using BUS;
namespace GUI
{
    public partial class frm_Main : Form
    {
        frm_Login frmlogin = new frm_Login();
        List<int> roles = new List<int>();
        public frm_Main(frm_Login frmlgn,List<int> rl)
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Parent = this;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Parent = this;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Parent = this;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Parent = this;
            frmlogin = frmlgn;
            roles = rl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_TaiXe tx = new frm_TaiXe();
            tx.Show();
        }

        private void btnQuanLyVe_Click(object sender, EventArgs e)
        {
            frm_DatBanVe frmdbv = new frm_DatBanVe();
            frmdbv.Show();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            frm_QuanLyKhachHang qlkh = new frm_QuanLyKhachHang();
            qlkh.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_QuanLyChuyen frmqlc = new frm_QuanLyChuyen();
            frmqlc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_QuanLyTuyen frmqlt = new frm_QuanLyTuyen();
            frmqlt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_QuanLyXe frmqlx = new frm_QuanLyXe();
            frmqlx.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmlogin.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_Admin admin = new frm_Admin();
            admin.Show();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            foreach (int role in roles)
            {
                if(role == 1)
                {
                    btnQuanLyChuyen.Enabled = true;
                    btnQuanLyKhachHang.Enabled = true;
                    btnQuanLyTaiXe.Enabled = true;
                    btnQuanLyTuyen.Enabled = true;
                    btnQuanLyVe.Enabled = true;
                    btnQuanLyXe.Enabled = true;
                    button2.Visible = true;
                }
                else
                {
                    if(role == 2)
                    {
                        btnQuanLyChuyen.Enabled = true;
                    }
                    if (role == 3)
                    {
                        btnQuanLyTuyen.Enabled = true;
                    }
                    if (role == 4)
                    {
                        btnQuanLyKhachHang.Enabled = true;
                    }
                    if (role == 5)
                    {
                        btnQuanLyTaiXe.Enabled = true;
                    }
                    if (role == 6)
                    {
                        btnQuanLyXe.Enabled = true;
                    }
                    if (role == 7)
                    {
                        btnQuanLyVe.Enabled = true;
                    }
                }
            }
        }
    }
}
