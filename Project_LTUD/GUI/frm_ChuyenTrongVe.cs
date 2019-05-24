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
    public partial class frm_ChuyenTrongVe : Form
    {
        int thang;
        public frm_ChuyenTrongVe(int m)
        {
            InitializeComponent();
            thang = m;
        }

        private void frm_ChuyenTrongVe_Load(object sender, EventArgs e)
        {

            DataTable dt = BUS.BUS_Chuyen.Instance.Fill_ReportChuyenTrongVe(thang);
            RPTuyenTrongVe rp = new RPTuyenTrongVe();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
