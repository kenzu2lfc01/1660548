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
namespace GUI
{
    public partial class frm_SuaChuyen : Form
    {
        frm_QuanLyChuyen frmMain;
        DTO.Chuyen chuyen;
        public frm_SuaChuyen(frm_QuanLyChuyen main, DTO.Chuyen c)
        {
            InitializeComponent();
            frmMain = main;
            chuyen = c;
        }

        private void LoadFrom()
        {
            BUS_Tram.Instance.Tram_CbbTramCuaTuyen(cbbTramBatDau);
            BUS_Tuyen.Instance.Tuyen_FillDGV(cbbTramBatDau, dgvChonChuyen);
            BUS_LoaiXe.Instance.LoaiXe_FillCBB(cbbLoaiXe);
            BUS_Xe.Instance.Xe_FillDGV(dgvXe, cbbLoaiXe);
            BUS_Chuyen.Instance.Chuyen_AutoID(txtMaChuyen);
        }
        private void frm_SuaChuyen_Load(object sender, EventArgs e)
        {
            LoadFrom();
            txtMaChuyen.Text = chuyen.ID.ToString();
            txtGhiChu.Text = chuyen.GhiChi.ToString();
        }

        private void cbbTramBatDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Tuyen.Instance.Tuyen_FillDGV(cbbTramBatDau, dgvChonChuyen);

        }

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Xe.Instance.Xe_FillDGV(dgvXe, cbbLoaiXe);

        }

        private void dgvChonChuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvChonChuyen.CurrentCell.RowIndex;
            txtIDTuyen.Text = dgvChonChuyen.Rows[cr].Cells[0].Value.ToString();
        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvXe.CurrentCell.RowIndex;
            txtIDXe.Text = dgvXe.Rows[cr].Cells[0].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            BUS_TaiXe.Instance.TaiXe_TimKiemTaiXe(dgvTaiXe, txtTenTaiXe);

        }

        private void dgvTaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvTaiXe.CurrentCell.RowIndex;
            txtIDTaiXe.Text = dgvTaiXe.Rows[cr].Cells[0].Value.ToString();
        }
        private DTO.Chuyen InsertToDTO()
        {
            DTO.Chuyen chuyen = new DTO.Chuyen();
            chuyen.ID = Convert.ToInt32(txtMaChuyen.Text);
            chuyen.IDTaiXe = Convert.ToInt32(txtIDTaiXe.Text);
            chuyen.IDTuyen = Convert.ToInt32(txtIDTuyen.Text);
            chuyen.IdXe = Convert.ToInt32(txtIDXe.Text);
            DateTime dt = dtpGioKhoiHanh.Value;
            chuyen.GioKhoiHanh = dt.ToString("HH:mm");
            chuyen.NgayKhoiHanh = Convert.ToDateTime(dtpNgayKhoiHanh.Value);
            chuyen.GhiChi = txtGhiChu.Text;
            return chuyen;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DTO.Chuyen chuyen = InsertToDTO();
            DAO.DAO_Chuyen.Instance.UpdateChuyen(chuyen);
            frmMain.Chuyen_LoadFrom();
        }

    }
}
