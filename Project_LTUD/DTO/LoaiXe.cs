using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiXe
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string tenLoai;

        public string TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }
    }
}
