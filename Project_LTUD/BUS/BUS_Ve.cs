using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BUS
{
    public class BUS_Ve
    {
        private static BUS_Ve instance;
        public static BUS_Ve Instance
        {
            get
            {
                if (BUS_Ve.instance == null)
                {
                    BUS_Ve.instance = new BUS_Ve();
                }
                return BUS_Ve.instance;
            }
            set { BUS_Ve.instance = value; }
        }
        public void Ve_FillDGV(ComboBox cbb1, ComboBox cbb2, ComboBox cbbNgayKhoiHanh,ComboBox cbbGioKhoiHanh, DataGridView dgv)
        {
            int ID1 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb1.SelectedValue.ToString());
            int ID2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb2.SelectedValue.ToString());
            int maTuyen = DAO.DAO_Tuyen.Instance.Find_MaTuyenByTram(ID1, ID2);
            DateTime ngayKhoiHanh = Convert.ToDateTime(cbbNgayKhoiHanh.SelectedValue);
            string gioKhoiHanh = cbbGioKhoiHanh.SelectedValue.ToString();
            int maChuyen = DAO.DAO_Chuyen.Instance.FindIdChuyen(maTuyen, ngayKhoiHanh, gioKhoiHanh);
            dgv.DataSource = DAO.DAO_Ve.Instance.FillDgvVe(maChuyen);
        }
        public void Ve_FillDdgvVeDat(ComboBox cbb1, ComboBox cbb2, ComboBox cbbGioKhoiHanh,ComboBox cbbNgayKhoiHanh, DataGridView dgv)
        {
            int ID1 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb1.SelectedValue.ToString());
            int ID2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb2.SelectedValue.ToString());
            int maTuyen = DAO.DAO_Tuyen.Instance.Find_MaTuyenByTram(ID1, ID2);
            DateTime ngayKhoiHanh = Convert.ToDateTime(cbbNgayKhoiHanh.SelectedValue);
            string gioKhoiHanh = cbbGioKhoiHanh.SelectedValue.ToString();
            int maChuyen = DAO.DAO_Chuyen.Instance.FindIdChuyen(maTuyen, ngayKhoiHanh, gioKhoiHanh);
            dgv.DataSource = DAO.DAO_Ve.Instance.FillDgvVeDatLai(maChuyen);

        }
        public void Ve_FillTxtSoLuongVe(ComboBox cbb1, ComboBox cbb2, ComboBox cbbGioKhoiHanh,ComboBox cbbNgayKhoiHanh,Label txt)
        {
             int ID1 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb1.SelectedValue.ToString());
            int ID2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb2.SelectedValue.ToString());
            int maTuyen = DAO.DAO_Tuyen.Instance.Find_MaTuyenByTram(ID1, ID2);
            string giokhoihanh = cbbGioKhoiHanh.SelectedValue.ToString();
            DateTime ngayKhoiHanh = Convert.ToDateTime(cbbNgayKhoiHanh.SelectedValue);
            int maChuyen = DAO.DAO_Chuyen.Instance.FindIdChuyen(maTuyen, ngayKhoiHanh, giokhoihanh);
            txt.Text = Convert.ToString(DAO.DAO_Ve.Instance.DemSoLuongVeBan(maChuyen));
        }
        public void Ve_FillCbb(ComboBox cbb)
        {
            cbb.DataSource = DAO.DAO_Ve.Instance.FillCBBTramDi();
            cbb.DisplayMember = "TenTram";
            cbb.ValueMember = "TenTram";
        }
        public void Ve_FillCbbNgayKhoiHanh(string cbbTramDiDatVe, string cbbTramDenDatVe, ComboBox cbbNgayKhoiHanh)
        {
            int ID1 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbbTramDiDatVe);
            int ID2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbbTramDenDatVe);
            int maTuyen = DAO.DAO_Tuyen.Instance.Find_MaTuyenByTram(ID1, ID2);
            cbbNgayKhoiHanh.DisplayMember = "NgayKhoiHanh";
            cbbNgayKhoiHanh.ValueMember = "NgayKhoiHanh";
            cbbNgayKhoiHanh.DataSource = DAO.DAO_Chuyen.Instance.FillNgayKhoiHanh(maTuyen);

        }
        public void Ve_FillCbbGioKhoiHanh(ComboBox cbb1, ComboBox cbb2, ComboBox cbbGioKhoiHanh, ComboBox cbbNgayKhoiHanh)
        {
            //int ID1 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb1.SelectedValue.ToString());
            //int ID2 = DAO.DAO_Tram.Instance.Find_IDTramByName(cbb2.SelectedValue.ToString());
            //int maTuyen = DAO.DAO_Tuyen.Instance.Find_MaTuyenByTram(ID1, ID2);
            //DateTime dt = Convert.ToDateTime(cbbNgayKhoiHanh.SelectedValue);
            //cbbGioKhoiHanh.DataSource = DAO.DAO_Chuyen.Instance.FillGioKhoiHanh(maTuyen, dt);
            //cbbGioKhoiHanh.DisplayMember = "GioKhoiHanh";
            //cbbGioKhoiHanh.ValueMember = "GioKhoiHanh";
        }
        public void Ve_ThemVe(int IDKHach)
        {
            DAO.DAO_Ve.Instance.ThemVeDat(IDKHach);
        }
        public void Ve_FillDgvVeDat(DataGridView dgv,int makh)
        {
            dgv.DataSource = DAO.DAO_Ve.Instance.FillDgvVeDatKH(makh);
        }
        public void Ve_FillDgvVeDatGhe(DataGridView dgv, int maChuyen)
        {
 
            dgv.DataSource = DAO.DAO_Ve.Instance.FillDgvVeDatLai(maChuyen);
        }
        public void Ve_RollBackVeDat(DataGridView dgv)
        {
            int cr = dgv.CurrentCell.RowIndex;
            int idVe = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value.ToString());
            DAO.DAO_Ve.Instance.RollBackVeDat(idVe);
        }
        public int Ve_SoLuongVe(int iDKH)
        {
            int soLuong = DAO.DAO_Ve.Instance.DemSoLuongVe(iDKH);
            return soLuong;
        }
        public void Ve_FillDgvVe(DataGridView dgv,int maChuyen)
        {
            dgv.DataSource = DAO.DAO_Ve.Instance.FillDgvAllVe(maChuyen);
        }
        public void Ve_UpdateGiaTien(TextBox giaTien,int MaChuyen)
        {
            DAO.DAO_Ve.Instance.UpdateGiaTien(Convert.ToInt32(giaTien.Text), MaChuyen);
        }
    }
}
