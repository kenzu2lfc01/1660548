using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Chuyen
    {
        private static DAO_Chuyen instance;
        public static DAO_Chuyen Instance
        {
            get
            {
                if (DAO_Chuyen.instance == null)
                {
                    DAO_Chuyen.instance = new DAO_Chuyen();
                }
                return DAO_Chuyen.instance;

            }
            set { DAO_Chuyen.instance = value; }
        }
        public DataTable FillDGV()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillDgvChuyen";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
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
        public DataTable Fill_ReportChuyenTrongVe(int Thang)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillReportChuyenTrongVe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@Thang", Value = Thang }
                    );
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
        public DataTable FillGioKhoiHanh(string NgayKhoiHanh)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillGioKhoiHah";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@NgayKhoiHanh", Value = NgayKhoiHanh}
                    );
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
        public DataTable FillNgayKhoiHanh(int IDTuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillNgayKhoiHanh";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdTuyen", Value = IDTuyen });
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
        public int FindIdChuyenMax()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillDgvChuyen";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach(DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Chuyen"]);
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
        public int FindIdChuyen(int IdTuyen, DateTime NgayKhoiHanh, string GioKhoiHanh )
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindIdChuyen";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdTuyen",Value = IdTuyen },
                    new SqlParameter { ParameterName = "@NgayKhoiHanh", Value = NgayKhoiHanh },
                    new SqlParameter { ParameterName = "@gioKhoiHanh", Value = GioKhoiHanh }
                    );
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Chuyen"]);
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
        public void ThemChuyen(DTO.Chuyen chuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemChuyen";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = chuyen.ID },
                    new SqlParameter { ParameterName = "@IdTuyen", Value = chuyen.IDTuyen },
                    new SqlParameter { ParameterName = "@NgayKhoiHanh", Value = chuyen.NgayKhoiHanh },
                    new SqlParameter { ParameterName = "@GioKhoiHanh", Value = chuyen.GioKhoiHanh },
                    new SqlParameter { ParameterName = "@GhiChu", Value = chuyen.GhiChi },
                    new SqlParameter { ParameterName = "@IdXe", Value = chuyen.IdXe },
                    new SqlParameter { ParameterName = "@IDTaiXe", Value = chuyen.IDTaiXe }
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
        public void XoaChuyen(int ID)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaChuyen";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID });
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
        public void UpdateChuyen(DTO.Chuyen chuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_UpdateChuyen";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = chuyen.ID },
                    new SqlParameter { ParameterName = "@IdTuyen", Value = chuyen.IDTuyen },
                    new SqlParameter { ParameterName = "@NgayKhoiHanh", Value = chuyen.NgayKhoiHanh },
                    new SqlParameter { ParameterName = "@GioKhoiHanh", Value = chuyen.GioKhoiHanh },
                    new SqlParameter { ParameterName = "@GhiChu", Value = chuyen.GhiChi },
                    new SqlParameter { ParameterName = "@IdXe", Value = chuyen.IdXe },
                    new SqlParameter { ParameterName = "@IDTaiXe", Value = chuyen.IDTaiXe }
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
    }
}
