using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Tuyen
    {
        private static DAO_Tuyen instance;
        public static DAO_Tuyen Instance
        {
            get
            {
                if (DAO_Tuyen.instance == null)
                {
                    DAO_Tuyen.instance = new DAO_Tuyen();
                }
                return DAO_Tuyen.instance;

            }
            set { DAO_Tuyen.instance = value; }
        }
        public DataTable Fill_TuyenXe(int ID_Tram1)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillTuyenXe";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = ID_Tram1 });
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
        public DataTable Fill_Report(int maChuyen, int Thang)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillReportTuyenTrongChuyen";
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@MaTuyen", Value = maChuyen },
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
        public DataTable Fill_ReportTuyenTrongVe(int Thang)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillReportTuyenTrongVe";
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
        public int Find_MaTuyen()
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FillIDTuyen";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql);
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Tuyen"]);
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
        public int FindKhoangCach(int id)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindKMByTuyen";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID",Value = id});
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["KhoangCach"]);
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
        public int Find_MaTuyenByTram(int ID1, int ID2)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_FindTuyenByTram";
                int flag = 0;
                DataTable dt = p.Select(CommandType.StoredProcedure, strSql,
                    new SqlParameter {ParameterName ="@ID1",Value = ID1 },
                    new SqlParameter {ParameterName ="@ID2",Value = ID2 }
                    );
                foreach (DataRow row in dt.Rows)
                {
                    flag = Convert.ToInt32(row["ID_Tuyen"]);
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

        public void Add_Tuyen(DTO.Tuyen tuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_ThemTuyen";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tuyen.ID },
                    new SqlParameter { ParameterName = "@KhoangCach", Value = tuyen.KhoangCach },
                    new SqlParameter { ParameterName = "@ThoiGianChay", Value = tuyen.ThoiGian },
                    new SqlParameter { ParameterName = "@IdTram1", Value = tuyen.IDTram1 },
                    new SqlParameter { ParameterName = "@IdTram2", Value = tuyen.IDTram2 }
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
       
        public void Delete_Tuyen(int ID)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_DeleteTuyen";
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
        public void Delete_TuyenByMaTram(int ID)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_DeleteTuyenByMaTram";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@MaTram", Value = ID }
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
        
        public void Update_Tuyen(DTO.Tuyen tuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_UpdateTuyen";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tuyen.ID },
                    new SqlParameter { ParameterName = "@KhoangCach", Value = tuyen.KhoangCach },
                    new SqlParameter { ParameterName = "@ThoiGianChay", Value = tuyen.ThoiGian },
                    new SqlParameter { ParameterName = "@IdTram1", Value = tuyen.IDTram1 },
                    new SqlParameter { ParameterName = "@IdTram2", Value = tuyen.IDTram2 }
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
        public void Update_TuyenKhongTram2(DTO.Tuyen tuyen)
        {
            Provider p = new Provider();
            try
            {
                p.Connect();
                string strSql = "sp_UpdateTuyenNotTram2";
                p.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    new SqlParameter { ParameterName = "@ID", Value = tuyen.ID },
                    new SqlParameter { ParameterName = "@KhoangCach", Value = tuyen.KhoangCach },
                    new SqlParameter { ParameterName = "@ThoiGianChay", Value = tuyen.ThoiGian },
                    new SqlParameter { ParameterName = "@IdTram1", Value = tuyen.IDTram1 }
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
