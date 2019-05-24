using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiXe
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string tenTaiXe, bangLai;

        public string BangLai
        {
            get { return bangLai; }
            set { bangLai = value; }
        }

        public string TenTaiXe
        {
            get { return tenTaiXe; }
            set { tenTaiXe = value; }
        }
    }
}
