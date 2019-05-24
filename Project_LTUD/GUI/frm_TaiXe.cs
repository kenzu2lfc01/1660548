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
    public partial class frm_TaiXe : Form
    {
        public frm_TaiXe()
        {
            InitializeComponent();
        }
        void LoadFrom()
        {
            BUS.BUS_TaiXe.Instance.TaiXe_FillDGV(dgvTaiXe);
            BUS.BUS_TaiXe.Instance.TaiXe_AuToID(txtMaTaiXe);
        }
        private void frm_TaiXe_Load(object sender, EventArgs e)
        {
            LoadFrom();
        }
        private DTO.TaiXe AddTaiXeToDTO()
        {
            DTO.TaiXe tx = new DTO.TaiXe();
            tx.ID = Convert.ToInt32(txtMaTaiXe.Text);
            tx.TenTaiXe = BUS.BUS_TaiXe.Instance.ChuanHoa(txtTenTaiXe.Text);
            tx.BangLai = txtBangLai.Text;
            return tx;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DTO.TaiXe tx = AddTaiXeToDTO();
            BUS.BUS_TaiXe.Instance.TaiXe_ThemTaiXe(tx);
            LoadFrom();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BUS.BUS_TaiXe.Instance.TaiXe_XoaTaiXe(dgvTaiXe);
            LoadFrom();
        }
        int demclick = 0;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(demclick == 0)
            {
                int cr = dgvTaiXe.CurrentCell.RowIndex;
                txtMaTaiXe.Text = dgvTaiXe.Rows[cr].Cells[0].Value.ToString();
                txtTenTaiXe.Text = dgvTaiXe.Rows[cr].Cells[1].Value.ToString();
                txtBangLai.Text = dgvTaiXe.Rows[cr].Cells[2].Value.ToString();
                btnUpdate.Text = "Lưu";
                demclick = 1;
            }
            else
            {
                DTO.TaiXe tx = AddTaiXeToDTO();
                BUS.BUS_TaiXe.Instance.TaiXe_SuaTaiXe(tx);
                btnUpdate.Text = "Sửa";
                demclick = 0;
                LoadFrom();
            }
        }


    }
}
