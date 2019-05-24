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
    public partial class frm_DatBanVe : Form
    {
        public frm_DatBanVe()
        {
            InitializeComponent();
        }
        public void Ve_LoadFrom()
        {
            BUS_Ve.Instance.Ve_FillCbb(ve_CbbTramDi);
            BUS_Ve.Instance.Ve_FillCbb(cbb_BVTramDiBanVe);
        }
        private void ClearTxtVe()
        {
            txtIDGhe.Clear();
            txtTang.Clear();
            txtCot.Clear();
            txtDong.Clear();
            txtSoGhe.Clear();
        }
        private void ClearTxtBanVe()
        {
            txtIDGheBanVe.Clear();
            txtTangBanVe.Clear();
            txtCotBanVe.Clear();
            txtDongBanVe.Clear();
            txtSoGheBanVe.Clear();
        }
        private void AfterThanhToan()
        {
            txtHoTenBanVe.Clear();
            txtBVSoLuongBanVe.Clear();
            txtSDT.Clear();
            grbKhachHangBanVe.Visible = false;
            grbThanhToan.Visible = false;
            grbChonGheBanVe.Visible = false;
            label45.Visible = false;
            label42.Visible = false;
            label37.Visible = false;
            btnNextChonGhe.Enabled = true;
            btnBackChonGhe.Enabled = true;
            btnNextChonChuyen.Enabled = true;
            btnBackKhachHang.Enabled = true;
            btnNextKhachHang.Enabled = true;
        }
        private void frm_DatBanVe_Load(object sender, EventArgs e)
        {
            Ve_LoadFrom();
        }
        private void ve_CbbTramDi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BUS_Tram.Instance.Tram_CbbTramDen(ve_CbbTramDen1, ve_CbbTramDi);

        }
        private void ve_CbbTramDen1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BUS.BUS_Ve.Instance.Ve_FillCbbNgayKhoiHanh(ve_CbbTramDi.SelectedValue.ToString(), ve_CbbTramDen1.SelectedValue.ToString(), ve_CbbNgayKhoiHanh);
        }
        private void ve_CbbNgayKhoiHanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dt = ve_CbbNgayKhoiHanh.SelectedValue.ToString();
            DataTable datable = DAO.DAO_Chuyen.Instance.FillGioKhoiHanh(dt);
            ve_CbbGioKhoiHanh.DataSource = datable;
            ve_CbbGioKhoiHanh.DisplayMember = "GioKhoiHanh";
            ve_CbbGioKhoiHanh.ValueMember = "GioKhoiHanh";
        }
        int soLuong = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            BUS.BUS_Ve.Instance.Ve_FillDGV(ve_CbbTramDi, ve_CbbTramDen1, ve_CbbNgayKhoiHanh, ve_CbbGioKhoiHanh, dgvVe);
            for (int i = 0; i < dgvVe.Rows.Count; i++)
            {
                dgvVe.Rows[i].Cells[9].Style.BackColor = Color.ForestGreen;
            }
            grbChonGhe.Visible = true;
            lblCaiMuiTen1.Visible = true;
            soLuong = Convert.ToInt32(txtSoLuong.Text);
            lblSoLuong.Text = soLuong.ToString();
            button2.Enabled = false;
        }

        private void btnDVChonGhe_Click(object sender, EventArgs e)
        {
            soLuong--;
            lblSoLuong.Text = soLuong.ToString();
            DAO_Ve.Instance.ThayTheTam(Convert.ToInt32(txtIDGhe.Text));
            ClearTxtVe();
            BUS.BUS_Ve.Instance.Ve_FillDGV(ve_CbbTramDi, ve_CbbTramDen1, ve_CbbNgayKhoiHanh, ve_CbbGioKhoiHanh, dgvVe);
            if (soLuong == 0)
            {
                grbThongTinKhachHang.Visible = true;
                lblCaiMuiTen2.Visible = true;
                btnDVChonGhe.Enabled = false;
                btnDVBackChonGhe.Enabled = false;
            }
        }

        private void btnDVBackChonGhe_Click(object sender, EventArgs e)
        {
            lblCaiMuiTen1.Visible = false;
            grbChonGhe.Visible = false;
            button2.Enabled = true;
        }

        private void btnDVXacNhanDat_Click(object sender, EventArgs e)
        {
            int Id = DAO_KhachHang.Instance.IDKH(txtHoTen.Text, txtSoDienThai.Text);
            if (Id == 0)
            {
                BUS_KhachHang.Instance.KhachHang_ThemKHDatVe(txtHoTen.Text, txtSoDienThai.Text);
                Id = DAO_KhachHang.Instance.IDKH(txtHoTen.Text, txtSoDienThai.Text);
                BUS_Ve.Instance.Ve_ThemVe(Id);
            }
            else
            {
                BUS_Ve.Instance.Ve_ThemVe(Id);
            }
            string giokhoihanh = ve_CbbGioKhoiHanh.SelectedValue.ToString();
            string mess = "Xe chạy lúc " + giokhoihanh.ToString();
            MessageBox.Show(mess, "Đặt vé thành công", MessageBoxButtons.OK);
            lblCaiMuiTen2.Visible = false;
            grbThongTinKhachHang.Visible = false;
            lblCaiMuiTen1.Visible = false;
            grbChonGhe.Visible = false;
            button2.Enabled = true;
            btnDVChonGhe.Enabled = true;
            btnDVBackChonGhe.Enabled = true;
            txtHoTen.Clear();
            txtSoDienThai.Clear();
            txtSoLuong.Clear();
        }

        private void btnDVBackTTKHachHang_Click(object sender, EventArgs e)
        {
            lblCaiMuiTen2.Visible = false;
            grbThongTinKhachHang.Visible = false;
            btnDVChonGhe.Enabled = true;
            btnDVBackChonGhe.Enabled = true;
            soLuong = Convert.ToInt32(txtSoLuong.Text);
            DAO_Ve.Instance.RollBAck();
            lblSoLuong.Text = soLuong.ToString();
            BUS.BUS_Ve.Instance.Ve_FillDGV(ve_CbbTramDi, ve_CbbTramDen1, ve_CbbNgayKhoiHanh, ve_CbbGioKhoiHanh, dgvVe);
        }
        private void dgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvVe.CurrentCell.RowIndex;
            txtIDGhe.Text = dgvVe.Rows[cr].Cells[0].Value.ToString();
            txtTang.Text = dgvVe.Rows[cr].Cells[1].Value.ToString();
            txtCot.Text = dgvVe.Rows[cr].Cells[2].Value.ToString();
            txtDong.Text = dgvVe.Rows[cr].Cells[3].Value.ToString();
            txtSoGhe.Text = dgvVe.Rows[cr].Cells[4].Value.ToString();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            frm_VeDat frmvedat = new frm_VeDat();
            frmvedat.Show();
        }
        // Bán vé

        private void cbb_BVTramDiBanVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_Tram.Instance.Tram_CbbTramDen(cbb_BVTramDenBanVe, cbb_BVTramDiBanVe);
        }

        private void cbb_BVTramDenBanVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS.BUS_Ve.Instance.Ve_FillCbbNgayKhoiHanh(cbb_BVTramDiBanVe.SelectedValue.ToString(), cbb_BVTramDenBanVe.SelectedValue.ToString(), cbb_BVNgayKhoiHanh);
        }
        int soLuongVeBan = 0;

        private void btnNextChonChuyen_Click(object sender, EventArgs e)
        {
            BUS.BUS_Ve.Instance.Ve_FillDdgvVeDat(cbb_BVTramDiBanVe, cbb_BVTramDenBanVe, cbbBVGioKhoiHanhBanVe, cbb_BVNgayKhoiHanh, dgvVeDat);
            grbChonGheBanVe.Visible = true;
            label37.Visible = true;
            soLuongVeBan = Convert.ToInt32(txtBVSoLuongBanVe.Text);
            lblSoLuongVeBan.Text = soLuongVeBan.ToString();
            btnNextChonChuyen.Enabled = false;
            BUS.BUS_Ve.Instance.Ve_FillTxtSoLuongVe(cbb_BVTramDiBanVe, cbb_BVTramDenBanVe, cbbBVGioKhoiHanhBanVe, cbb_BVNgayKhoiHanh ,lblSoLuongCon);
            for (int i = 0; i < dgvVeDat.Rows.Count; i++)
            {
                dgvVeDat.Rows[i].Cells[7].Style.BackColor = Color.ForestGreen;
            }
        }

        private void btnBackChonGhe_Click(object sender, EventArgs e)
        {

        }

        private void dgvVeDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvVeDat.CurrentCell.RowIndex;
            string soGhe = dgvVeDat.Rows[cr].Cells[3].Value.ToString();
            txtIDGheBanVe.Text = dgvVeDat.Rows[cr].Cells[0].Value.ToString();
            txtTangBanVe.Text = soGhe.Substring(0, 1);
            txtCotBanVe.Text = soGhe.Substring(1, 1);
            txtDongBanVe.Text = soGhe.Substring(2, 2);
            txtSoGheBanVe.Text = soGhe;
        }

        private void btnBackKhachHang_Click(object sender, EventArgs e)
        {
            label42.Visible = false;
            grbKhachHangBanVe.Visible = false;
            btnBackChonGhe.Enabled = true;
            btnNextChonGhe.Enabled = true;
            soLuongVeBan = Convert.ToInt32(txtSoLuong.Text);
            DAO_Ve.Instance.RollBAck();
            lblSoLuongVeBan.Text = soLuongVeBan.ToString();
            BUS.BUS_Ve.Instance.Ve_FillDdgvVeDat(cbb_BVTramDiBanVe, cbb_BVTramDenBanVe, cbbBVGioKhoiHanhBanVe, cbb_BVNgayKhoiHanh, dgvVeDat);

        }

        private void btnNextKhachHang_Click(object sender, EventArgs e)
        {
            int IdKh = DAO_KhachHang.Instance.IDKH(txtHoTenBanVe.Text, txtSDT.Text);
            if (IdKh == 0)
            {
                BUS_KhachHang.Instance.KhachHang_ThemKHDatVe(txtHoTenBanVe.Text, txtSDT.Text);
                IdKh = DAO_KhachHang.Instance.IDKH(txtHoTenBanVe.Text, txtSDT.Text);
                BUS_Ve.Instance.Ve_ThemVe(IdKh);
            }
            else
            {
                BUS_Ve.Instance.Ve_ThemVe(IdKh);
            }
            btnBackKhachHang.Enabled = false;
            btnNextKhachHang.Enabled = false;
            label45.Visible = true;
            grbThanhToan.Visible = true;
            lblSoLuongDaMua.Text = txtBVSoLuongBanVe.Text;
            int soLuong = Convert.ToInt32(txtBVSoLuongBanVe.Text);
            int giaTien = Convert.ToInt32(dgvVeDat.Rows[0].Cells[4].Value);
            lblTongTien.Text = Convert.ToString(giaTien * soLuong);
        }

        private void btnThanhToanBanVe_Click(object sender, EventArgs e)
        {
            int IdKh = DAO_KhachHang.Instance.IDKH(txtHoTenBanVe.Text, txtSDT.Text);
            DAO_Ve.Instance.ThanhToan(IdKh);
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
            AfterThanhToan();
        }

  

        private void cbb_BVNgayKhoiHanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dt = cbb_BVNgayKhoiHanh.SelectedValue.ToString();
            DataTable datable = DAO.DAO_Chuyen.Instance.FillGioKhoiHanh(dt);
            cbbBVGioKhoiHanhBanVe.DataSource = datable;
            cbbBVGioKhoiHanhBanVe.DisplayMember = "GioKhoiHanh";
            cbbBVGioKhoiHanhBanVe.ValueMember = "GioKhoiHanh";
        }

        private void btnNextChonGhe_Click(object sender, EventArgs e)
        {
            soLuongVeBan--;
            lblSoLuongVeBan.Text = soLuongVeBan.ToString();
            DAO_Ve.Instance.ThayTheTam(Convert.ToInt32(txtIDGheBanVe.Text));
            ClearTxtVe();
            BUS.BUS_Ve.Instance.Ve_FillDdgvVeDat(cbb_BVTramDiBanVe, cbb_BVTramDenBanVe, cbbBVGioKhoiHanhBanVe, cbb_BVNgayKhoiHanh, dgvVeDat);
            if (soLuongVeBan == 0)
            {
                grbKhachHangBanVe.Visible = true;
                label42.Visible = true;
                btnNextChonGhe.Enabled = false;
                btnBackChonGhe.Enabled = false;
            }
        }
    }
}
