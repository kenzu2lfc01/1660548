using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ve
    {
        int iD, iDGhe, iDChuyen, tinhTrang, giaTien, iDKhach;

        public int IDKhach
        {
            get { return iDKhach; }
            set { iDKhach = value; }
        }

        public int GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

        public int IDChuyen
        {
            get { return iDChuyen; }
            set { iDChuyen = value; }
        }

        public int IDGhe
        {
            get { return iDGhe; }
            set { iDGhe = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        DateTime ngayXuat;

        public DateTime NgayXuat
        {
            get { return ngayXuat; }
            set { ngayXuat = value; }
        }
        string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }
}
