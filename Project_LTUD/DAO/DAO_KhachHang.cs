using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_KhachHang
    {
        private static DAO_KhachHang instance;
        public static DAO_KhachHang Instance
        {
            get
            {
                if (DAO_KhachHang.instance == null)
                {
                    DAO_KhachHang.instance = new DAO_KhachHang();
                }
                return DAO_KhachHang.instance;
            }
            set { DAO_KhachHang.instance = value; }
        }
        public int IDKH(string hoTen,string SDT)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindKH";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@HoTen",Value = hoTen },
                    new SqlParameter { ParameterName = "@SDT", Value =SDT }
                    );
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_KhachHang"]);
                }
                return flag;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }

        public void ThemKhachHangDatVe(string hoten, string sdt)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemKhachHang";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                   new SqlParameter { ParameterName = "@HoTen", Value = hoten },
                    new SqlParameter { ParameterName = "@SDT", Value = sdt }
                    );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }

        public void ThemKhachHang(KhachHang kh)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "Add_KhachHang";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                   new SqlParameter { ParameterName = "@hoten", Value = kh.HoTen },
                    new SqlParameter { ParameterName = "@dienthoai", Value = kh.SoDienThoai },
                    new SqlParameter { ParameterName = "@email", Value = kh.Email },
                    new SqlParameter { ParameterName = "@loai", Value = kh.Loai }
                    );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }

        public void SuaKhachHang(KhachHang kh)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "Update_KhachHang";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@idKH", Value = kh.ID },
                   new SqlParameter { ParameterName = "@hoten", Value = kh.HoTen },
                    new SqlParameter { ParameterName = "@dienthoai", Value = kh.SoDienThoai },
                    new SqlParameter { ParameterName = "@email", Value = kh.Email },
                    new SqlParameter { ParameterName = "@loai", Value = kh.Loai }
                    );
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }

        public DataTable Fill_KhachHang()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillKhachHang";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                p.Disconnect();
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }
    }
}
