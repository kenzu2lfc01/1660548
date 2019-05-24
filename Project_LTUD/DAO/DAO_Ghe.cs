using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Ghe
    {
        private static DAO_Ghe instance;
        public static DAO_Ghe Instance
        {
            get
            {
                if (DAO_Ghe.instance == null)
                {
                    DAO_Ghe.instance = new DAO_Ghe();
                }
                return DAO_Ghe.instance;

            }
            set { DAO_Ghe.instance = value; }
        }
        public DataTable FillDGVGhe(int IdXe)
        {
             Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillDgvGhe";
                DataTable dt = p.Select(CommandType.StoredProcedure,strSql,
                    new SqlParameter{ParameterName = "@ID",Value =IdXe });
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

        public int FindIdXeByName(string tenXe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                int flag = 0;
                string strSql = "sp_FindIdXeyName";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@TenXe", Value = tenXe });
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
        public int FindIDGheMax()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                int flag = 0;
                string strSql = "sp_FillAllGhe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Ghe"]);
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
        public DataTable FillCbbTenXe(int IdLoai)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCbbTenXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDLoai",Value = IdLoai });
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
        public void InsertGhe(DTO.Ghe ghe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "InsertGhe";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@IDGhe", Value = ghe.ID },
                    new SqlParameter { ParameterName = "@Dong", Value = ghe.Dong },
                    new SqlParameter { ParameterName = "@Cot", Value = ghe.Cot },
                    new SqlParameter { ParameterName = "@Tang", Value = ghe.Tang },
                    new SqlParameter { ParameterName = "@SoGhe", Value = ghe.SoGhe },
                    new SqlParameter { ParameterName = "@IdXe", Value = ghe.IdXe }
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
        public void DeleteGhe(int idxe)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaGhe";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = idxe}
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
