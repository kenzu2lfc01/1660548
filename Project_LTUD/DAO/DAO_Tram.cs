using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Tram
    {
        private static DAO_Tram instance;
        public static DAO_Tram Instance
        {
            get
            {
                if (DAO_Tram.instance == null)
                {
                    DAO_Tram.instance = new DAO_Tram();
                }
                return DAO_Tram.instance;

            }
            set { DAO_Tram.instance = value; }
        }
        public DataTable Fill_CbbTramCuaTuyen()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCbbTramCuaTuyen";
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
        public DataTable Fill_CBBTramDen(int ID_TramDi)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCbbTramDen";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID_TramDi });
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
        public DataTable Fill_CBBTramDenVe(int ID_TramDi)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCbbTramDenVe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID_TramDi });
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
        public DataTable Fill_CbbTram()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillCBB_Tram";
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
        public DataTable Fill_Tram()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillTram";
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
        public int Find_MaTram()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillTram";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Tram"]);
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
        public void Add_Tram(DTO.Tram tram)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemTram";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tram.ID },
                    new SqlParameter { ParameterName = "@TenTram", Value = tram.TenTram },
                    new SqlParameter { ParameterName = "@DiaDanh", Value = tram.DiaDanh }
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
        public void Delete_Tram(int ID_Tram)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_XoaTram";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID_Tram }
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
        public void Update_Tram(DTO.Tram tram)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_SuaTram";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tram.ID },
                    new SqlParameter { ParameterName = "@TenTram", Value = tram.TenTram },
                    new SqlParameter { ParameterName = "@DiaDanh", Value = tram.DiaDanh }
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
        public int Find_IDTramByName(string tenTram)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_Find_IDTramByName";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@TenTram", Value = tenTram });
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Tram"]);
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
