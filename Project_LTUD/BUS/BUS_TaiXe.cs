using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;
namespace BUS
{
    public class BUS_TaiXe
    {
        private static BUS_TaiXe instance;
        public static BUS_TaiXe Instance
        {
            get
            {
                if (BUS_TaiXe.instance == null)
                {
                    BUS_TaiXe.instance = new BUS_TaiXe();
                }
                return BUS_TaiXe.instance;

            }
            set { BUS_TaiXe.instance = value; }
        }
        public void TaiXe_FillDGV(DataGridView dgv)
        {
            dgv.DataSource = DAO_TaiXe.Instance.FillDGVTaiXe();
        }
        public void TaiXe_ThemTaiXe(DTO.TaiXe tx)
        {
            DAO_TaiXe.Instance.ThemTaiXe(tx);
        }
        public void TaiXe_XoaTaiXe(DataGridView dgv)
        {
            int cr = dgv.CurrentCell.RowIndex;
            int ID = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value);
            DAO_TaiXe.Instance.XoaTaiXe(ID);
        }
        public void TaiXe_SuaTaiXe(DTO.TaiXe tx)
        {
            DAO_TaiXe.Instance.SuaTaiXe(tx);
        }
        public void TaiXe_AuToID(TextBox txt)
        {
            int x = DAO_TaiXe.Instance.FindIDMAx();
            x++;
            txt.Text = x.ToString();
        }
        public string ChuanHoa(string str)
        {
            str = str.Trim();
            while (str.IndexOf("\t") >= 0)
            {
                str = str.Replace("\t", " ");
            }
            while (str.IndexOf("  ") >= 0)
            {
                str = str.Replace("  ", " ");
            }
            string[] arrStr = str.Split(' ');
            string s = "";
            foreach (string item in arrStr)
            {
                s += item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower() + " ";

            }
            return s;
        }
        public void TaiXe_TimKiemTaiXe(DataGridView dgv,TextBox txt)
        {
            string hoTen = ChuanHoa(txt.Text);
            dgv.DataSource = DAO_TaiXe.Instance.TimKiemTaiXe(hoTen);
        }
    }
}
