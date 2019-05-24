using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Xe
    {
        int iD, idLoai;

        public int IdLoai
        {
            get { return idLoai; }
            set { idLoai = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string soDangKy, tenXe;

        public string TenXe
        {
            get { return tenXe; }
            set { tenXe = value; }
        }

        public string SoDangKy
        {
            get { return soDangKy; }
            set { soDangKy = value; }
        }
    }
}
