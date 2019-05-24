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
    public partial class frm_QLTramXe : Form
    {
        private frm_QuanLyTuyen frmMain;
        public frm_QLTramXe(frm_QuanLyTuyen frm)
        {
            InitializeComponent();
            txtMaTram.ReadOnly = true;
            frmMain = frm;
        }
        private void LoadFrom()
        {
            BUS_Tram.Instance.Tram_LoadDGV(dgvTramXe);
            BUS_Tram.Instance.Tram_AutoMaTram(txtMaTram);
            TextRong();
        }
        private void TextRong()
        {
            txtTenTram.Clear();
            txtDiaDanh.Clear();
        }
        private void frm_ThemTram_Load(object sender, EventArgs e)
        {
            LoadFrom();
        }
        private DTO.Tram GetTram()
        {
            DTO.Tram tram = new DTO.Tram();
            tram.ID = Convert.ToInt32(txtMaTram.Text);
            tram.TenTram = txtTenTram.Text;
            tram.DiaDanh = txtDiaDanh.Text;
            return tram;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTO.Tram tram = GetTram();
            BUS_Tram.Instance.Tram_ThemTram(tram);
            frmMain.Tuyen_LoadFrom();
            LoadFrom();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BUS_Tram.Instance.Tram_XoaTram(dgvTramXe);
            frmMain.Tuyen_LoadFrom();
            LoadFrom();
        }
        int demclick = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (demclick == 0)
            {
                int cr = dgvTramXe.CurrentCell.RowIndex;
                txtMaTram.Text = dgvTramXe.Rows[cr].Cells[0].Value.ToString();
                txtTenTram.Text = dgvTramXe.Rows[cr].Cells[1].Value.ToString();
                txtDiaDanh.Text = dgvTramXe.Rows[cr].Cells[2].Value.ToString();
                demclick = 1;
                button3.Text = "Lưu";
            }
            else
            {
                DTO.Tram tram = GetTram();
                BUS_Tram.Instance.Tram_SuaTram(tram);
                button3.Text = "Sửa";
                demclick = 0;
                frmMain.Tuyen_LoadFrom();
                LoadFrom();
            }
        }
    }
}
