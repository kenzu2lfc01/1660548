using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
   public class DAO_Ve
    {
       private static DAO_Ve instance;
       public static DAO_Ve Instance
        {
            get
            {
                if (DAO_Ve.instance == null)
                {
                    DAO_Ve.instance = new DAO_Ve();
                }
                return DAO_Ve.instance;
            }
            set { DAO_Ve.instance = value; }
        }
       public void ThemVe(DTO.Ve ve)
       {
           Provider p = new Provider();
           try
           {
               p.Connect();
               string strSql = "sp_ThemVe";
               p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                   new SqlParameter { ParameterName = "@ID", Value = ve.ID },
                   new SqlParameter { ParameterName = "@IDGhe", Value = ve.IDGhe },
                   new SqlParameter { ParameterName = "@IdChuyen", Value = ve.IDChuyen },
                   new SqlParameter { ParameterName = "@GiaTien", Value = ve.GiaTien },
                   new SqlParameter { ParameterName = "@NgayXuat", Value = ve.NgayXuat }
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
        public int IdVeMax()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindIdVeMax";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach(DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Ve"]);
                }
                return flag;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                p.Disconnect();
            }
        }
        public int FindIDChuyen(int IDVe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindIdChuyenByVe";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter {ParameterName ="@IDVe",Value = IDVe});
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["Chuyen_ID_Chuyen"]);
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
        public int DemSoLuongVe(int IdKH)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_DemSoLuongVe";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdKH", Value = IdKH });
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["SoLuongVe"]);
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
        public int DemSoLuongVeBan(int IdChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_DemSoLuongVeBan";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@MaChuyen", Value = IdChuyen });
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["SoLuongVe"]);
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
        public DataTable FillDgvAllVe(int MaChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillVe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDChuyen", Value = MaChuyen }
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
        public DataTable FillDgvVeDatLai(int MaChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillDGvVeDat";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@MaChuyen", Value = MaChuyen }
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
        public DataTable FillDgvVe(int MaChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillDGVVe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@MaChuyen", Value = MaChuyen }
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
        public DataTable FillDgvVeDatKH(int MaKH)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindVeByKhachHang";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdKH", Value = MaKH }
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
        public DataTable FillCBBTramDi()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillTramDiVe";
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
        public void ThayTheTam(int IDVe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemTempVe";
                 p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                     new SqlParameter { ParameterName = "@IdVe",Value = IDVe});
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
        public void UpdateGiaTien(int GiaTien,int MaChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_UpdateGiaTien";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDChuyen", Value = MaChuyen },
                    new SqlParameter { ParameterName = "@giaTien", Value = GiaTien }
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
        public void XoaVe(int IdChuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaVe";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDChuyen", Value = IdChuyen });
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
        public void ThemVeDat(int idKhach)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemVeMoi";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDKH", Value = idKhach });
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
        public void ThanhToan(int idKhach)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThanhToan";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdKH", Value = idKhach });
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
        public void ThemVeDatLai(int idKhach,int IdVe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemVeDatLai";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDKH", Value = idKhach },
                    new SqlParameter { ParameterName = "@IDVe", Value = IdVe }
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
        public void RollBackVeDat(int IDVe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "SP_ROOLBACKVeDat";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDVe", Value = IDVe });
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
        public void RollBAck()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "SP_ROOLBACK";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql);
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
