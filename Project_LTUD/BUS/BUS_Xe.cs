using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class BUS_Xe
    {
        private static BUS_Xe instance;
        public static BUS_Xe Instance
        {
            get
            {
                if (BUS_Xe.instance == null)
                {
                    BUS_Xe.instance = new BUS_Xe();
                }
                return BUS_Xe.instance;

            }
            set { BUS_Xe.instance = value; }
        }
        public void Xe_FillDGV(DataGridView dgv,ComboBox cbb)
        {
            DAO_Xe daXe = new DAO_Xe();
            dgv.DataSource  = daXe.FillDGV(cbb.SelectedIndex);
        }
        public void Xe_AutoMaXe(TextBox txt)
        {
            DAO_Xe daXe = new DAO_Xe();
            int x = daXe.FindIDMax();
            x++;
            txt.Text = x.ToString();
        }
        public void Xe_ThemXe(DTO.Xe xe)
        {
            DAO_Xe daXe = new DAO_Xe();
            daXe.InsertXe(xe);
            BUS_Ghe.Instance.Ghe_ThemGhe(xe.IdLoai,xe.ID);
        }
        public void Xe_XoaXe(DataGridView dgv)
        {
            DAO_Xe daXe = new DAO_Xe();
            int cr = dgv.CurrentCell.RowIndex;
            int maxe = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value);
            BUS_Ghe.Instance.Ghe_XoaGhe(maxe);
            daXe.DeleteXe(maxe);
        }
        public void Xe_UpdateXe(DTO.Xe xe)
        {
            DAO_Xe daXe = new DAO_Xe();
            daXe.UpdateXe(xe);
        }
    }
}
