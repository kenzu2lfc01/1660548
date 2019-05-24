using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DAO;
namespace BUS
{
    public class BUS_Tuyen
    {
        private static BUS_Tuyen instance;

        public static BUS_Tuyen Instance
        {
            get
            {
                if (BUS_Tuyen.instance == null)
                {
                    BUS_Tuyen.instance = new BUS_Tuyen();
                }
                return BUS_Tuyen.instance;

            }
            set { BUS_Tuyen.instance = value; }
        }
     
        public void Tuyen_FillDGV(ComboBox cbb,DataGridView dgv)
        {
            DAO_Tuyen daTuyen = new DAO_Tuyen();
            DAO_Tram daTram = new DAO_Tram();
            string tenTram = "";
            if (cbb.Items.Count > 0)
            {
                tenTram = cbb.SelectedValue.ToString();
            }
            int ID_Tram1 = Convert.ToInt32(daTram.Find_IDTramByName(tenTram));
            dgv.DataSource = daTuyen.Fill_TuyenXe(ID_Tram1);
        }
        public void Tuyen_AuToId(TextBox txt)
        {
            DAO_Tuyen daTuyen = new DAO_Tuyen();
            int iD_Tuyen = daTuyen.Find_MaTuyen();
            iD_Tuyen++;
            txt.Text = iD_Tuyen.ToString();
        }
        public void Tuyen_ThemTuyen(DTO.Tuyen tuyen)
        {
                DAO_Tuyen daTuyen = new DAO_Tuyen();
                daTuyen.Add_Tuyen(tuyen);
        }
        public void Tuyen_XoaTuyen(DataGridView dgv)
        {
            DAO_Tuyen daTuyen = new DAO_Tuyen();
            int cr = dgv.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value);
            daTuyen.Delete_Tuyen(id);
        }
        public void Tuyen_SuaTuyen(ComboBox cbb,DTO.Tuyen tuyen)
        {
            DAO_Tuyen daTuyen = new DAO_Tuyen();
            if (cbb.Items.Count > 0)
            {
                daTuyen.Update_Tuyen(tuyen);
            }
            else
            {
                daTuyen.Update_TuyenKhongTram2(tuyen);
            }
        }
        public DataTable Tuyen_RPTuyenTrongChuyen(int maChuyen, int thang)
        {
            return DAO_Tuyen.Instance.Fill_Report(maChuyen, thang);
        }
        public DataTable Fill_ReportTuyenTrongVe( int thang)
        {
            return DAO_Tuyen.Instance.Fill_ReportTuyenTrongVe(thang);
        }
    }
}
