using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS
{
    public class BUS_KhachHang
    {
        private static BUS_KhachHang instance;
        public static BUS_KhachHang Instance
        {
            get
            {
                if (BUS_KhachHang.instance == null)
                {
                    BUS_KhachHang.instance = new BUS_KhachHang();
                }
                return BUS_KhachHang.instance;
            }
            set { BUS_KhachHang.instance = value; }
        }

        public void KhachHang_ThemKHDatVe(string hoten, string sdt)
        {
            DAO.DAO_KhachHang.Instance.ThemKhachHangDatVe(hoten, sdt);
        }

        public void KhachHang_ThemKH(KhachHang kh)
        {
            DAO.DAO_KhachHang.Instance.ThemKhachHang(kh);
        }

        public void KhachHang_SuaKH(KhachHang kh)
        {
            DAO.DAO_KhachHang.Instance.SuaKhachHang(kh);
        }

        public DataTable Fill_KhachHang()
        {
           return DAO.DAO_KhachHang.Instance.Fill_KhachHang();
        }
    }
}
