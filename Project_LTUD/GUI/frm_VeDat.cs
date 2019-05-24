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
using BUS;
namespace GUI
{
    public partial class frm_VeDat : Form
    {
        public frm_VeDat()
        {
            InitializeComponent();
        }
        int iDKH = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string hoTen = Function.Instance.ChuanHoa(txtHoTen.Text);
            iDKH = DAO_KhachHang.Instance.IDKH(hoTen, txtSoDienThoai.Text);
            if (iDKH == 0)
            {
                MessageBox.Show("Tên hoặc số điện thoại không tồn tại!!!");
            }
            else
            {
                BUS.BUS_Ve.Instance.Ve_FillDgvVeDat(dgvVeDat, iDKH);
                for (int i = 0; i < dgvVeDat.Rows.Count; i++)
                {
                    dgvVeDat.Rows[i].Cells[7].Style.BackColor = Color.ForestGreen;
                }
                int giaTien = Convert.ToInt32(dgvVeDat.Rows[0].Cells[4].Value);
                int soLuong = BUS_Ve.Instance.Ve_SoLuongVe(iDKH);
                lblTongTien.Text = Convert.ToString(soLuong * giaTien);
                lblSoLuong.Text = soLuong.ToString();
            }
        }
        int demClick = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if(demClick == 0)
            {
                int MaChuyen = DAO.DAO_Ve.Instance.FindIDChuyen(Convert.ToInt32(txtIDGhe.Text));
                BUS.BUS_Ve.Instance.Ve_RollBackVeDat(dgvVeDat);
                BUS_Ve.Instance.Ve_FillDgvVeDatGhe(dgvVeDat, MaChuyen);
                for (int i = 0; i < dgvVeDat.Rows.Count; i++)
                {
                    dgvVeDat.Rows[i].Cells[7].Style.BackColor = Color.ForestGreen;
                }
                button3.Text = "Lưu";
                demClick = 1;
            }
            else
            {
                int maVe = Convert.ToInt32(txtIDGhe.Text);
                DAO.DAO_Ve.Instance.ThemVeDatLai(iDKH,maVe);
                BUS.BUS_Ve.Instance.Ve_FillDgvVeDat(dgvVeDat, iDKH);
                button3.Text = "Thay đổi";
                demClick = 0;
            }
        }
        private void dgvVeDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cr = dgvVeDat.CurrentCell.RowIndex;
            string soGhe = dgvVeDat.Rows[cr].Cells[3].Value.ToString();
            txtIDGhe.Text = dgvVeDat.Rows[cr].Cells[0].Value.ToString();
            txtTang.Text = soGhe.Substring(0, 1);
            txtCot.Text = soGhe.Substring(1, 1);
            txtDong.Text = soGhe.Substring(2, 2);
            txtSoGhe.Text = soGhe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
            DAO_Ve.Instance.ThanhToan(iDKH);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frm_VeDat_Load(object sender, EventArgs e)
        {

        }
    }
}
