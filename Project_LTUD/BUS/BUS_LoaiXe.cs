using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class BUS_LoaiXe
    {
        private static BUS_LoaiXe instance;
        public static BUS_LoaiXe Instance
        {
            get
            {
                if (BUS_LoaiXe.instance == null)
                {
                    BUS_LoaiXe.instance = new BUS_LoaiXe();
                }
                return BUS_LoaiXe.instance;

            }
            set { BUS_LoaiXe.instance = value; }
        }
        public void LoaiXe_FillCBB(ComboBox cbb)
        {
            DAO_LoaiXe daLoaiXe = new DAO_LoaiXe();
            cbb.DataSource = daLoaiXe.FillCbbLoaiXe();
            cbb.DisplayMember = "TenLoai";
            cbb.ValueMember = "TenLoai";
            if(cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = 0;
            }
        }
    }
}
