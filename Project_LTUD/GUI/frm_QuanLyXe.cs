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
namespace GUI
{
    public partial class frm_QuanLyXe : Form
    {
        public frm_QuanLyXe()
        {
            InitializeComponent();
            txtMaXe.ReadOnly = true;
        }
        private void LoadFrom()
        {
            BUS_LoaiXe.Instance.LoaiXe_FillCBB(cbbLoaiXe);
            BUS_LoaiXe.Instance.LoaiXe_FillCBB(cbbLoaiXeThem);
            BUS_Xe.Instance.Xe_FillDGV(dgvDSXE,cbbLoaiXe);
            BUS_Xe.Instance.Xe_AutoMaXe(txtMaXe);
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            txtSoDangKy.Clear();
            txtTenXe.Clear();
        }
        private void frm_QuanLyXe_Load(object sender, EventArgs e)
        {
            LoadFrom();
        }
        private DTO.Xe InsertDTOXe()
        {
            DTO.Xe xe = new DTO.Xe();
            xe.ID = Convert.ToInt32(txtMaXe.Text);
            xe.TenXe = txtTenXe.Text;
            xe.SoDangKy = txtSoDangKy.Text;
            xe.IdLoai = DAO_LoaiXe.Instance.FindIDByTenXe(cbbLoaiXeThem.SelectedValue.ToString());
            return xe;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO.Xe xe = InsertDTOXe();
            BUS_Xe.Instance.Xe_ThemXe(xe);
            LoadFrom();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            BUS_Xe.Instance.Xe_XoaXe(dgvDSXE);
            LoadFrom();
        }
        int demclick = 0;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (demclick == 0)
            {
                int cr = dgvDSXE.CurrentCell.RowIndex;
                txtMaXe.Text = dgvDSXE.Rows[cr].Cells[0].Value.ToString();
                txtTenXe.Text = dgvDSXE.Rows[cr].Cells[1].Value.ToString();
                txtSoDangKy.Text = dgvDSXE.Rows[cr].Cells[2].Value.ToString();
                btnSua.Text = "Lưu";
                demclick = 1;
            }
            else
            {
                DTO.Xe xe = InsertDTOXe();
                BUS_Xe.Instance.Xe_UpdateXe(xe);
                btnSua.Text = "Sửa";
                demclick = 0;
                LoadFrom();
            }
        }

        private void btnXemGhe_Click(object sender, EventArgs e)
        {

            frm_Ghe frmghe = new frm_Ghe(Convert.ToInt32(cbbLoaiXe.SelectedIndex));
            frmghe.Show();
        }

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Xe.Instance.Xe_FillDGV(dgvDSXE, cbbLoaiXe);

        }
    }
}
