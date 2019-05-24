using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Xe
    {
        private static DAO_Xe instance;
        public static DAO_Xe Instance
        {
            get
            {
                if (DAO_Xe.instance == null)
                {
                    DAO_Xe.instance = new DAO_Xe();
                }
                return DAO_Xe.instance;

            }
            set { DAO_Xe.instance = value; }
        }
        public DataTable FillDGV(int IdLoai)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IdLoai", Value = IdLoai});
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
        public int FindIDMax()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillAllXe";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach(DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["XeID"]);
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
        public void InsertXe(DTO.Xe xe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemXe";
                 p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                     new SqlParameter { ParameterName = "@ID",Value = xe.ID},
                     new SqlParameter { ParameterName = "@TenXe",Value = xe.TenXe},
                     new SqlParameter { ParameterName = "@SoDangKy",Value = xe.SoDangKy},
                     new SqlParameter { ParameterName = "@IDLoai",Value = xe.IdLoai}
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
        public void DeleteXe(int ID)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaXe";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID }
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
        public void UpdateXe(DTO.Xe xe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_SuaXe";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = xe.ID },
                    new SqlParameter { ParameterName = "@TenXe", Value = xe.TenXe },
                    new SqlParameter { ParameterName = "@SoDangKy", Value = xe.SoDangKy }
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
