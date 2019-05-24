using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
namespace BUS
{
    public class BUS_Tram
    {
        public static BUS_Tram instance;

        public static BUS_Tram Instance
        {
            get
            {
                if (BUS_Tram.instance == null)
                {
                    BUS_Tram.instance = new BUS_Tram();
                }
                return BUS_Tram.instance;

            }
            set { BUS_Tram.instance = value; }
        }
        public void Tram_CbbTramCuaTuyen(ComboBox cbb)
        {
            DAO_Tram daTram = new DAO_Tram();
            cbb.DataSource = daTram.Fill_CbbTramCuaTuyen();
            cbb.DisplayMember = "TenTram";
            cbb.ValueMember = "TenTram";
            if (cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = 0;
            }
        }
        public void Tram_CbbTramDi(ComboBox cbb)
        {
            DAO_Tram daTram = new DAO_Tram();
            cbb.DataSource = daTram.Fill_CbbTram();
            cbb.DisplayMember = "TenTram";
            cbb.ValueMember = "TenTram";
            if (cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = 0;
            }
        }
        public void Tram_CbbTramDen(ComboBox cbb1, ComboBox cbb2)
        {
            DAO_Tram daTram = new DAO_Tram();
            int maTram = daTram.Find_IDTramByName(cbb2.SelectedValue.ToString());
            cbb1.DataSource = daTram.Fill_CBBTramDenVe(maTram);
            cbb1.DisplayMember = "TenTram";
            cbb1.ValueMember = "TenTram";
            if (cbb1.Items.Count > 0)
            {
                cbb1.SelectedIndex = 0;
            }
        }
        public void Tram_LoadDataByCBB(ComboBox cbb, DataGridView dgv)
        {
            DAO_Tram daTram = new DAO_Tram();
            DAO_Tuyen daTuyen = new DAO_Tuyen();
            string tenTram = "";
            if (cbb.Items.Count > 0)
            {
                tenTram = cbb.SelectedValue.ToString();
            }
            int ID_Tram1 = Convert.ToInt32(daTram.Find_IDTramByName(tenTram));
            dgv.DataSource = daTuyen.Fill_TuyenXe(ID_Tram1);
        }
        public void Tram_LoadDGV(DataGridView dgv)
        {
            DAO_Tram daTram = new DAO_Tram();
            dgv.DataSource = daTram.Fill_Tram();
        }
        public void Tram_AutoMaTram(TextBox txt)
        {
            DAO_Tram daTram = new DAO_Tram();
            int maTram = Convert.ToInt32(daTram.Find_MaTram());
            maTram++;
            txt.Text = maTram.ToString();
        }
        public void Tram_ThemTram(DTO.Tram tram)
        {
            DAO_Tram daTram = new DAO_Tram();
            daTram.Add_Tram(tram);
        }
        public void Tram_XoaTram(DataGridView dgv)
        {
            DAO_Tram daTram = new DAO_Tram();
            int cr = dgv.CurrentCell.RowIndex;
            int matram = Convert.ToInt32(dgv.Rows[cr].Cells[0].Value);
            daTram.Delete_Tram(matram);
        }
        public void Tram_SuaTram(DTO.Tram tram)
        {
            DAO_Tram daTram = new DAO_Tram();
            daTram.Update_Tram(tram);
           
        }
    }
}