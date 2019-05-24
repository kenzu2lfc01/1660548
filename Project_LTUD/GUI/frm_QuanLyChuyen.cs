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
    public partial class frm_QuanLyChuyen : Form
    {

        public frm_QuanLyChuyen()
        {
            InitializeComponent();
        }

        private void frm_QuanLyChuyen_Load(object sender, EventArgs e)
        {
            Chuyen_LoadFrom();
        }
        public void Chuyen_LoadFrom()
        {
            BUS_Chuyen.Instance.Chuyen_FillDGV(dgvChuyenXe);
        }
        private void btnThemChuyen_Click_1(object sender, EventArgs e)
        {
            frm_ThemChuyen frmAddChuyen = new frm_ThemChuyen(this);
            frmAddChuyen.Show();
        }

        private void btnShowXe_Click_1(object sender, EventArgs e)
        {
            frm_QuanLyXe frmqlxe = new frm_QuanLyXe();
            frmqlxe.Show();
        }

        private void btnShowTaiXe_Click_1(object sender, EventArgs e)
        {
            frm_TaiXe frmqlTaiXe = new frm_TaiXe();
            frmqlTaiXe.Show();
        }

        private void btnXoaChuyen_Click_1(object sender, EventArgs e)
        {
            BUS_Chuyen.Instance.Chuyen_XoaChuyen(dgvChuyenXe);
            Chuyen_LoadFrom();
        }

        private void btnSuaChuyen_Click_1(object sender, EventArgs e)
        {
            DTO.Chuyen chuyen = new DTO.Chuyen();
            int cr = dgvChuyenXe.CurrentCell.RowIndex;
            chuyen.ID = Convert.ToInt32(dgvChuyenXe.Rows[cr].Cells[0].Value);
            chuyen.NgayKhoiHanh = Convert.ToDateTime(dgvChuyenXe.Rows[cr].Cells[3].Value);
            chuyen.GioKhoiHanh = dgvChuyenXe.Rows[cr].Cells[4].Value.ToString();
            chuyen.GhiChi = dgvChuyenXe.Rows[cr].Cells[7].Value.ToString();
            frm_SuaChuyen frmUpdateChuyen = new frm_SuaChuyen(this, chuyen);
            frmUpdateChuyen.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int cr = dgvChuyenXe.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvChuyenXe.Rows[cr].Cells[0].Value);
            frm_QuanLyVe qlv = new frm_QuanLyVe(id);
            qlv.Show();
        }
    }
}
