using BUS;
using DTO;
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
    public partial class frm_QuanLyKhachHang : Form
    {
        public frm_QuanLyKhachHang()
        {
            InitializeComponent();
            dtgvQLKH.SelectionChanged += dtgvQLKH_SelectionChanged;
        }

        private void frm_QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            dtgvQLKH.DataSource = BUS_KhachHang.Instance.Fill_KhachHang();
        }

        void FillDetail(KhachHang kh)
        {
            txtID_KH.Text = kh.ID.ToString();
            txtHoTen.Text = kh.HoTen;
            txtSDT.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtLoai.Text = kh.Loai.ToString();
        }

        private void dtgvQLKH_SelectionChanged(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            if (dtgvQLKH.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dtgvQLKH.SelectedRows[0];
                kh.ID = Convert.ToInt32(row.Cells["ID_KhachHang"].Value);
                kh.HoTen = row.Cells["HoTen"].Value.ToString();
                kh.SoDienThoai = row.Cells["DienThoai"].Value.ToString();
                kh.Email = row.Cells["Email"].Value.ToString();
                kh.Loai = Convert.ToInt32(row.Cells["Loai"].Value);
                FillDetail(kh);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.HoTen = txtHoTen.Text;
            kh.SoDienThoai = txtSDT.Text;
            kh.Email = txtEmail.Text;
            kh.Loai = Convert.ToInt32(txtLoai.Text);
            BUS.BUS_KhachHang.Instance.KhachHang_ThemKH(kh);
            frm_QuanLyKhachHang_Load(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ID = Convert.ToInt32(txtID_KH.Text);
            kh.HoTen = txtHoTen.Text;
            kh.SoDienThoai = txtSDT.Text;
            kh.Email = txtEmail.Text;
            kh.Loai = Convert.ToInt32(txtLoai.Text);
            BUS.BUS_KhachHang.Instance.KhachHang_SuaKH(kh);
            frm_QuanLyKhachHang_Load(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
