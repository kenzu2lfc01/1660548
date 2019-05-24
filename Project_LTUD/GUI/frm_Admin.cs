using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace GUI
{
    public partial class frm_Admin : Form
    {
        public frm_Admin()
        {
            InitializeComponent();
        }
        private void LoadFromUser()
        {
            BUS_Users.Instance.Users_FillDGV(dgvUsers);
        }
        private void frm_Admin_Load(object sender, EventArgs e)
        {
            LoadFromUser();
        }
        private DTO.Users AddToDTO()
        {
            DTO.Users user = new DTO.Users();
            user.Username1 = txtUsername.Text;
            user.Password1 = txtPassword.Text;
            user.Email1 = txtEmail.Text;
            return user;
        }
        private void ClearFrom()
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtUsername.Clear();
            cbxQLChuyen.Checked = false;
            cbxQLTuyen.Checked = false;
            cbxQLKhach.Checked = false;
            cbxQLTaiXe.Checked = false;
            cbxQLXe.Checked = false;
            cbxQLDatBanVe.Checked = false;
        }
        private bool CheckEmpty()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập username");
                return false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập password");
                return false;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email");
                return false;
            }
            else if (cbxQLChuyen.Checked == false && cbxQLTuyen.Checked == false && cbxQLKhach.Checked == false && cbxQLTaiXe.Checked == false && cbxQLXe.Checked == false && cbxQLDatBanVe.Checked == false)
            {
                MessageBox.Show("Vui lòng phân quyền");
                return false;
            }
            else return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckEmpty() == true)
            {
                if (BUS_Users.Instance.CheckUser(txtUsername) != 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                }
                else
                {
                    DTO.Users user = AddToDTO();
                    BUS.BUS_Users.Instance.Users_AddUser(user);
                    if (cbxQLChuyen.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 2);
                    }
                    if (cbxQLTuyen.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 3);
                    }
                    if (cbxQLKhach.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 4);
                    }
                    if (cbxQLTaiXe.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 5);
                    }
                    if (cbxQLXe.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 6);
                    }
                    if (cbxQLDatBanVe.Checked == true)
                    {
                        BUS_Users.Instance.Users_AddRole(txtUsername.Text, 7);
                    }
                    MessageBox.Show("Thêm thành công!!!");
                    LoadFromUser();
                    ClearFrom();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int cr = dgvUsers.CurrentCell.RowIndex;
            string Username = dgvUsers.Rows[cr].Cells[0].Value.ToString();
            DAO.DAO_Users.Instance.Delete(Username);
            LoadFromUser();
        }

        int demclick = 0;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (demclick == 0)
            {
                int cr = dgvUsers.CurrentCell.RowIndex;
                txtUsername.Text = dgvUsers.Rows[cr].Cells[0].Value.ToString();
                txtPassword.Text = dgvUsers.Rows[cr].Cells[1].Value.ToString();
                txtEmail.Text = dgvUsers.Rows[cr].Cells[2].Value.ToString();
                demclick = 1;
                btnUpdate.Text = "Lưu";
            }
            else
            {
                DTO.Users user = AddToDTO();
                DAO.DAO_Users.Instance.UpdateUser(user);
                LoadFromUser();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lsvQuyen.Items.Clear();
            int cr = dgvUsers.CurrentCell.RowIndex;
            string userid = dgvUsers.Rows[cr].Cells[0].Value.ToString();
            BUS_Users.Instance.Users_FillListView(lsvQuyen, userid);
        }
    }
}
