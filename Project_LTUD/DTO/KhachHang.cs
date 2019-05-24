using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        int iD, loai;

        public int Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string soDienThoai, hoTen, email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

      
    }
}
