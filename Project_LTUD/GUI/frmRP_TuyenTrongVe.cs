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
    public partial class frmRP_TuyenTrongVe : Form
    {
        int thang;
        public frmRP_TuyenTrongVe(int m)
        {
            InitializeComponent();
            thang = m;
        }

        private void frmRP_TuyenTrongVe_Load(object sender, EventArgs e)
        {
            DataTable dt = BUS.BUS_Tuyen.Instance.Fill_ReportTuyenTrongVe(thang);
            RPTuyenTrongVe rp = new RPTuyenTrongVe();
            rp.SetDataSource(dt);
            crystalReportViewer2.ReportSource = rp;
        }
    }
}
