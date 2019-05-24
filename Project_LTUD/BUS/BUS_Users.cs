using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace BUS
{
    public class BUS_Users
    {
        private static BUS_Users instance;
        public static BUS_Users Instance
        {
            get
            {
                if (BUS_Users.instance == null)
                {
                    BUS_Users.instance = new BUS_Users();
                }
                return BUS_Users.instance;

            }
            set { BUS_Users.instance = value; }
        }
        public int CheckLogin(TextBox username, TextBox password)
        {
            return DAO_Users.Instance.CheckLogin(username.Text, password.Text);
        }
        public int CheckUser(TextBox username)
        {
            return DAO_Users.Instance.CheckUserID(username.Text);
        }
        public void Users_FillDGV(DataGridView dgv)
        {
            dgv.DataSource = DAO_Users.Instance.FillDGVUsers();
        }
        public void Users_AddUser(DTO.Users user)
        {
            DAO_Users.Instance.InsertUser(user);
        }
        public List<int> Users_FillListRole(string username)
        {
            return DAO_Users.Instance.CheckPhanduyen(username);
        }
        public void Users_AddRole(string userID, int ID)
        {
            DAO_Users.Instance.InsertRole(userID, ID);
        }
        public void Users_FillListView(ListView lst, string userid)
        {
            DataTable dt = DAO_Users.Instance.FillListViewQuyen(userid);
            ListViewItem lvi = null;
            foreach (DataRow row in dt.Rows)
            {
                lvi = new ListViewItem(row["RoleName"].ToString());
                lst.Items.Add(lvi);
            }
            lst.View = View.Details;
        }
    }
}