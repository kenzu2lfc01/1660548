using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Chuyen
    {
        int iD, iDTuyen, idXe, iDTaiXe;

        public int IDTaiXe
        {
            get { return iDTaiXe; }
            set { iDTaiXe = value; }
        }

        public int IdXe
        {
            get { return idXe; }
            set { idXe = value; }
        }

        public int IDTuyen
        {
            get { return iDTuyen; }
            set { iDTuyen = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string ghiChi, tinhTrang;

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        string gioKhoiHanh;

        public string GioKhoiHanh
        {
            get { return gioKhoiHanh; }
            set { gioKhoiHanh = value; }
        }
        public string GhiChi
        {
            get { return ghiChi; }
            set { ghiChi = value; }
        }
        DateTime ngayKhoiHanh;

        public DateTime NgayKhoiHanh
        {
            get { return ngayKhoiHanh; }
            set { ngayKhoiHanh = value; }
        }
    }
}
