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
    public partial class frm_QuanLyTuyen : Form
    {
        List<int> lstMonth = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

        public frm_QuanLyTuyen()
        {
            InitializeComponent();
            txtMaTuyen.ReadOnly = true;
            cbbMonth.DataSource = lstMonth;

        }

        private void frm_QuanLyTuyen_Load(object sender, EventArgs e)
        {
            Tuyen_LoadFrom();
        }
        private void Tuyen_TextRong()
        {
            txtKhoangCach.Clear();
            txtThoiGianChay.Clear();
        }
        private DTO.Tuyen Tuyen_InsertDTO()
        {
            DTO.Tuyen tuyen = new DTO.Tuyen();
            tuyen.ID = Convert.ToInt32(txtMaTuyen.Text);
            tuyen.KhoangCach = Convert.ToInt32(txtKhoangCach.Text);
            tuyen.ThoiGian = Convert.ToInt32(txtThoiGianChay.Text);
            tuyen.IDTram1 = Convert.ToInt32(cbbTenTram1.SelectedIndex);
            if (cbbTenTram2.Items.Count > 0)
            {
                int ID_Tram2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbbTenTram2.SelectedValue.ToString());
                tuyen.IDTram2 = Convert.ToInt32(ID_Tram2);
            }
            return tuyen;
        }
        public void Tuyen_LoadFrom()
        {
            BUS_Tram.Instance.Tram_CbbTramCuaTuyen(cbbTenTram);
            BUS_Tram.Instance.Tram_CbbTramDi(cbbTenTram1);
            BUS_Tuyen.Instance.Tuyen_FillDGV(cbbTenTram, dgvTuyenXe);
            BUS_Tuyen.Instance.Tuyen_AuToId(txtMaTuyen);
            Tuyen_TextRong();
        }
        private void cbbTenTram1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            BUS_Tram.Instance.Tram_CbbTramDen(cbbTenTram2, cbbTenTram1);

        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            DTO.Tuyen tuyen = Tuyen_InsertDTO();
            BUS_Tuyen.Instance.Tuyen_ThemTuyen(tuyen);
            Tuyen_LoadFrom();
        }

        private void cbbTenTram_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BUS_Tram.Instance.Tram_LoadDataByCBB(cbbTenTram, dgvTuyenXe);
        }
        private int demclick = 0;
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (demclick == 0)
            {
                int cr = dgvTuyenXe.CurrentCell.RowIndex;
                txtMaTuyen.Text = dgvTuyenXe.Rows[cr].Cells[0].Value.ToString();
                txtKhoangCach.Text = dgvTuyenXe.Rows[cr].Cells[1].Value.ToString();
                txtThoiGianChay.Text = dgvTuyenXe.Rows[cr].Cells[2].Value.ToString();
                int idTram1 = DAO_Tram.Instance.Find_IDTramByName(dgvTuyenXe.Rows[cr].Cells[3].Value.ToString());
                cbbTenTram1.SelectedIndex = idTram1;
                btnUpdate.Text = "Lưu";
                demclick = 1;
            }
            else
            {
                DTO.Tuyen tuyen = Tuyen_InsertDTO();
                BUS_Tuyen.Instance.Tuyen_SuaTuyen(cbbTenTram2, tuyen);
                btnUpdate.Text = "Sửa";
                demclick = 0;
                Tuyen_LoadFrom();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            BUS_Tuyen.Instance.Tuyen_XoaTuyen(dgvTuyenXe);
            Tuyen_LoadFrom();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_QLTramXe frmTram = new frm_QLTramXe(this);
            frmTram.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int maChuyen = Convert.ToInt32(txtMaChuyen.Text);
            int Thang = Convert.ToInt32(cbbMonth.SelectedValue);
            frmRP_TuyenTrongChuyen frmrp = new frmRP_TuyenTrongChuyen(maChuyen, Thang);
            frmrp.Show();
        }

        private void dgvTuyenXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvTuyenXe.CurrentCell.RowIndex;
            txtMaChuyen.Text = dgvTuyenXe.Rows[cr].Cells[0].Value.ToString();
        }
    }
}
