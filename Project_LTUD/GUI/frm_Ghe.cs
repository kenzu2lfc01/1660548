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
    public partial class frm_Ghe : Form
    {
        int IDLoai;
        public frm_Ghe(int id)
        {
            InitializeComponent();
            IDLoai = id;
        }
        public void LoadFrom()
        {
            BUS.BUS_Ghe.Instance.Ghe_FillCBB(cbbTenXe, IDLoai);
            BUS.BUS_Ghe.Instance.Ghe_LoadDGV(dgvGhe,cbbTenXe);
            label3.Text = "Ghế của " + cbbTenXe.SelectedValue.ToString();
        }
        private void frm_Ghe_Load(object sender, EventArgs e)
        {
            LoadFrom();
        }

        private void cbbTenXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS.BUS_Ghe.Instance.Ghe_LoadDGV(dgvGhe, cbbTenXe);
            label3.Text = "Ghế của " + cbbTenXe.SelectedValue.ToString();
        }
    }
}
