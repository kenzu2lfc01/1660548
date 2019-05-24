using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Tuyen
    {
        int iD, khoangCach, thoiGian, iDTram1, iDTram2;

        public int IDTram2
        {
            get { return iDTram2; }
            set { iDTram2 = value; }
        }

        public int IDTram1
        {
            get { return iDTram1; }
            set { iDTram1 = value; }
        }

        public int ThoiGian
        {
            get { return thoiGian; }
            set { thoiGian = value; }
        }

        public int KhoangCach
        {
            get { return khoangCach; }
            set { khoangCach = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
