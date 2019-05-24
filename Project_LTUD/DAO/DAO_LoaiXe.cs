using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_LoaiXe
    {
        private static DAO_LoaiXe instance;
        public static DAO_LoaiXe Instance
        {
            get
            {
                if (DAO_LoaiXe.instance == null)
                {
                    DAO_LoaiXe.instance = new DAO_LoaiXe();
                }
                return DAO_LoaiXe.instance;

            }
            set { DAO_LoaiXe.instance = value; }
        }
        public DataTable FillCbbLoaiXe()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCBBLoaiXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                return dt;
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
        public int FindIDByTenXe(string tenLoai)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindIDByTenXe";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@TenLoai", Value = tenLoai });
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_LoaiXe"]);
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
    }
}
