using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public  class BUS_Ghe
    {
        private static BUS_Ghe instance;
        public static BUS_Ghe Instance
        {
            get
            {
                if (BUS_Ghe.instance == null)
                {
                    BUS_Ghe.instance = new BUS_Ghe();
                }
                return BUS_Ghe.instance;

            }
            set { BUS_Ghe.instance = value; }
        }
        public DTO.Ghe Ghe_InsertToDTO(int dong, int cot, int tang,int soghe,int idxe)
        {
            DTO.Ghe ghe = new DTO.Ghe();
            ghe.ID = AuToIDGhe();
            ghe.Dong = dong;
            ghe.Cot = cot;
            ghe.Tang = tang;
            ghe.SoGhe = soghe;
            ghe.IdXe = idxe;
            return ghe;
        }
        public int AuToIDGhe()
        {
            DAO.DAO_Ghe daGhe = new DAO.DAO_Ghe();
            int x = daGhe.FindIDGheMax();
            x++;
            return x;
        }
        public void Ghe_ThemGhe(int type,int IdXe)
        {
            DAO.DAO_Ghe daGhe = new DAO.DAO_Ghe();
            if (type == 0)
            {
                    for (int cot = 1; cot <= 5; cot++)
                    {
                    
                        if (cot != 5)
                        {
                            for (int dong = 1; dong <= 11; dong++)
                            {
                                int soghe = 1*1000+cot*100+dong;
                                DTO.Ghe ghe = Ghe_InsertToDTO(dong, cot, 1, soghe, IdXe);
                                daGhe.InsertGhe(ghe);
                                soghe++;
                            }
                        }
                        else
                        {
                            int soghe = 1 * 1000 + cot * 100 + 11;
                            DTO.Ghe ghe = Ghe_InsertToDTO(11, cot, 1, soghe, IdXe);
                            daGhe.InsertGhe(ghe);
                            soghe++;
                        }
                    }
            }
            if (type == 1)
            {
                for (int cot = 1; cot <= 3; cot++)
                {
                    for (int dong = 1; dong <= 10; dong++)
                    {
                        int soghe = 1000 +cot * 100 + dong;
                        DTO.Ghe ghe = Ghe_InsertToDTO(dong, cot, 1, soghe, IdXe);
                        daGhe.InsertGhe(ghe);
                        soghe++;
                    }
                }
            }
            if (type == 2)
            {
                for (int tang = 1; tang <= 2; tang++)
                {
                    for (int cot = 1; cot <= 4; cot++)
                    {
                        if (cot % 2 != 0)
                        {
                            for (int dong = 1; dong <= 7; dong++)
                            {
                                int soghe = tang * 1000 + cot * 100 + dong;
                                DTO.Ghe ghe = Ghe_InsertToDTO(dong, cot, tang, soghe, IdXe);
                                daGhe.InsertGhe(ghe);
                                soghe++;
                            }
                        }
                        else
                        {
                            int soghe = tang * 1000 + cot * 100 + 7;
                            DTO.Ghe ghe = Ghe_InsertToDTO(7, cot, tang, soghe, IdXe);
                            daGhe.InsertGhe(ghe);
                            soghe++;
                        }
                    }
                }
            }
            if (type == 3)
            {
                for (int cot = 1; cot <= 4; cot++)
                {
                    if (cot != 3)
                    {
                        for (int dong = 1; dong <= 9; dong++)
                        {
                            int soghe = 1000+ cot * 100 + dong;
                            DTO.Ghe ghe = Ghe_InsertToDTO(dong, cot, 1, soghe, IdXe);
                            daGhe.InsertGhe(ghe);
                            soghe++;
                        }
                    }
                    else
                    {
                        int soghe = 1000+cot * 100 + 9;
                        DTO.Ghe ghe = Ghe_InsertToDTO(9, cot, 1, soghe, IdXe);
                        daGhe.InsertGhe(ghe);
                        soghe++;
                    }
                }
            }
        }
        public void Ghe_XoaGhe(int IdXe)
        {
            DAO.DAO_Ghe daghe = new DAO.DAO_Ghe();
            daghe.DeleteGhe(IdXe);
        }
        public void Ghe_LoadDGV(DataGridView dgv,ComboBox cbb)
        {
            DAO.DAO_Ghe daghe = new DAO.DAO_Ghe();
            string TenXe = "";
            if(cbb.Items.Count > 0)
            {
                TenXe = cbb.SelectedValue.ToString();
            }
            int idXe = daghe.FindIdXeByName(TenXe);
            dgv.DataSource = daghe.FillDGVGhe(idXe);
        }
        public void Ghe_FillCBB(ComboBox cbb,int idLoai)
        {
            DAO.DAO_Ghe daghe = new DAO.DAO_Ghe();
            cbb.DataSource = daghe.FillCbbTenXe(idLoai);
            cbb.DisplayMember = "TenXe";
            cbb.ValueMember = "TenXe";
            if(cbb.Items.Count > 0)
            {
                cbb.SelectedIndex = 0;
            }
        }
    }
}
