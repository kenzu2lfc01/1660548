using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Users
    {
        private static DAO_Users instance;
        public static DAO_Users Instance
        {
            get
            {
                if (DAO_Users.instance == null)
                {
                    DAO_Users.instance = new DAO_Users();
                }
                return DAO_Users.instance;

            }
            set { DAO_Users.instance = value; }
        }
        public int CheckLogin(string Username, string Password)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_CheckLogin";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID",Value = Username },
                    new SqlParameter { ParameterName = "@Pass", Value = Password }
                    );
                foreach(DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["type"]);
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
        public int CheckUserID(string Username)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_CheckUsername";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = Username }
                    );
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["type"]);
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
        public List<int> CheckPhanduyen(string Username)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_PhanQuyen";
                List<int> DSRole = new List<int>();
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = Username }
                    );
                foreach (DataRow row in dt.Rows)
                {
                    DSRole.Add(Convert.ToInt32(row["RoleID"]));
                }
                return DSRole;
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
        public DataTable FillDGVUsers()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "FillDGvUsers";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql
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
        public DataTable FillListViewQuyen(string userid)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "FillCbbQuyen";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = userid }
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
        public void InsertUser(DTO.Users user)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "AddUsers";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = user.Username1 },
                    new SqlParameter { ParameterName = "@Pass", Value = user.Password1 },
                    new SqlParameter { ParameterName = "@Email", Value = user.Email1 }
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
        public void Delete(string UserID)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "DeleteUsers";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = UserID }
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
        public void UpdateUser(DTO.Users user)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "UpdateUsers";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = user.Username1 },
                    new SqlParameter { ParameterName = "@Pass", Value = user.Password1 },
                    new SqlParameter { ParameterName = "@Email", Value = user.Email1 }
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
        public void InsertRole(string userID, int iD)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "AddRole";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@UserID", Value = userID },
                    new SqlParameter { ParameterName = "@ID", Value = iD }
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
