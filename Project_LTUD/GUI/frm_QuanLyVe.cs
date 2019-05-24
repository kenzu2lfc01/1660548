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
    public partial class frm_QuanLyVe : Form
    {
        List<int> lstMonth = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

        int maChuyen;
        public frm_QuanLyVe(int mc)
        {
            InitializeComponent();
            maChuyen = mc;
            cbbMonth.DataSource = lstMonth;
            comboBox1.DataSource = lstMonth;

        }

        private void frm_QuanLyVe_Load(object sender, EventArgs e)
        {
            LoadFrom();

        }

        private void LoadFrom()
        {
            BUS_Ve.Instance.Ve_FillDgvVe(dgvVe, maChuyen);
            txtGiaTien.Text = dgvVe.Rows[0].Cells[3].Value.ToString();
            for (int i = 0; i < dgvVe.Rows.Count - 1; i++)
            {
                if (dgvVe.Rows[i].Cells[2].Value.ToString() == "Chưa đặt")
                {
                    dgvVe.Rows[i].Cells[2].Style.BackColor = Color.ForestGreen;
                }
                else if (dgvVe.Rows[i].Cells[2].Value.ToString() == "Đã đặt")
                {
                    dgvVe.Rows[i].Cells[2].Style.BackColor = Color.Red;

                }
                else if (dgvVe.Rows[i].Cells[2].Value.ToString() == "Đã thanh toán")
                {
                    dgvVe.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                }
                else
                {
                    dgvVe.Rows[i].Cells[2].Style.BackColor = Color.White;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BUS_Ve.Instance.Ve_UpdateGiaTien(txtGiaTien, maChuyen);
            LoadFrom();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int Thang = Convert.ToInt32(cbbMonth.SelectedValue);
            frmRP_TuyenTrongVe frmTuyenTrongVe = new frmRP_TuyenTrongVe(Thang);
            frmTuyenTrongVe.Show();
        }


        //int Thang = Convert.ToInt32(comboBox1.SelectedValue);
        //frm_ChuyenTrongVe frmct = new frm_ChuyenTrongVe(Thang);
        //frmct.Show();
    }
}
