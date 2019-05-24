using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_TaiXe
    {
        private static DAO_TaiXe instance;
        public static DAO_TaiXe Instance
        {
            get
            {
                if (DAO_TaiXe.instance == null)
                {
                    DAO_TaiXe.instance = new DAO_TaiXe();
                }
                return DAO_TaiXe.instance;

            }
            set { DAO_TaiXe.instance = value; }
        }
        public DataTable FillDGVTaiXe()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_LoadTaiXe";
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
        public DataTable TimKiemTaiXe(string hoTen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_TimKiemTaiXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@TenTaiXe",Value = hoTen });
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
        public int FindIDMAx()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_LoadTaiXe";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach(DataRow row in dt.Rows)
                {
                    flag =  Convert.ToInt32(row["ID_TaiXe"]);
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
        public void ThemTaiXe(DTO.TaiXe tx)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_LoadTaiXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tx.ID },
                    new SqlParameter { ParameterName = "@TenTaiXe", Value = tx.TenTaiXe },
                    new SqlParameter { ParameterName = "@BangLai", Value = tx.BangLai }
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
        public void XoaTaiXe(int id)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaTaiXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = id }
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
        public void SuaTaiXe(DTO.TaiXe tx)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_SuaTaiXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tx.ID },
                    new SqlParameter { ParameterName = "@TenTaiXe", Value = tx.TenTaiXe },
                    new SqlParameter { ParameterName = "@BangLai", Value = tx.BangLai }
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
