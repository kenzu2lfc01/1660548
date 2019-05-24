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
    public partial class frmRP_TuyenTrongChuyen : Form
    {
        int maChuyen, thang;
        public frmRP_TuyenTrongChuyen(int mc, int m)
        {
            InitializeComponent();
            maChuyen = mc;
            thang = m;
        }

        private void frmRP_TuyenTrongChuyen_Load(object sender, EventArgs e)
        {
            DataTable dt = BUS.BUS_Tuyen.Instance.Tuyen_RPTuyenTrongChuyen(maChuyen, thang);
            RPTuyenTrongChuyen rp = new RPTuyenTrongChuyen();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
