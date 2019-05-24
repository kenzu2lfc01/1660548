using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class BUS_Chuyen
    {
        private static BUS_Chuyen instance;
        public static BUS_Chuyen Instance
        {
            get
            {
                if (BUS_Chuyen.instance == null)
                {
                    BUS_Chuyen.instance = new BUS_Chuyen();
                }
                return BUS_Chuyen.instance;
            }
            set { BUS_Chuyen.instance = value; }
        }
        public void Chuyen_AutoID(TextBox txt)
        {
            int x = DAO.DAO_Chuyen.Instance.FindIdChuyenMax();
            x++;
            txt.Text = x.ToString();
        }
        public void Chuyen_FillDGV(DataGridView dgv)
        {
            dgv.DataSource = DAO.DAO_Chuyen.Instance.FillDGV();
        }
        public void Chuyen_ThemChuyen(DTO.Chuyen chuyen)
        {
            DAO.DAO_Chuyen.Instance.ThemChuyen(chuyen);
            DataTable dt = DAO.DAO_Ghe.Instance.FillDGVGhe(chuyen.IdXe);
            DTO.Ve ve = new DTO.Ve();
            ve.IDChuyen = chuyen.ID;
            int kc = DAO.DAO_Tuyen.Instance.FindKhoangCach(chuyen.IDTuyen);
            ve.GiaTien = kc*1000;
            ve.NgayXuat = DateTime.Now;
            foreach (DataRow row in dt.Rows)
            {
                int idve = DAO.DAO_Ve.Instance.IdVeMax();
                idve++;
                ve.ID = idve;
                ve.IDGhe = Convert.ToInt32(row["ID_Ghe"]);
                DAO.DAO_Ve.Instance.ThemVe(ve);
            }
        }
        public void Chuyen_XoaChuyen(DataGridView dgv)
        {
            int cr = dgv.CurrentCell.RowIndex;
            int ms = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value);
            DAO.DAO_Chuyen.Instance.XoaChuyen(ms);
        }
        public DataTable Fill_ReportChuyenTrongVe(int thang)
        {
            return DAO.DAO_Chuyen.Instance.Fill_ReportChuyenTrongVe(thang);
        }
    }
}
