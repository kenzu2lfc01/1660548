using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class Provider
    {
        //public string ConnectionString = @"Data Source=DESKTOP-ODJNB4B\TANSQL;User ID=sa;Password=ttth;
        //  Initial Catalog =Quanlivexe_DoAn; Integrated Security = TRUE";

        static string cnString;
        static string nameCS = "doAnCuoiKy";
        static SqlConnection Connection;
        static Provider()
        {
            //Khởi tạo connection từ config
            cnString = ConfigurationManager.ConnectionStrings[nameCS].ConnectionString;
            Connection = new SqlConnection(cnString);
        }

        public void Connect()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection(cnString);
                }
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public int ExecuteNonQuery(CommandType cmdType, string strSql)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int ExcuteScalar(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetReader(CommandType cmdType, string strSql)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;

                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable Select(CommandType cmdType, string strSql)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSql;
                command.CommandType = cmdType;

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable Select(CommandType cmdType, string strSql, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);

                }
                command.CommandText = strSql;
                command.CommandType = cmdType;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
