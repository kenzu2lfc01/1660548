using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ghe
    {
        int iD, idXe, dong, cot, tang, soGhe;

        public int SoGhe
        {
            get { return soGhe; }
            set { soGhe = value; }
        }

        public int Tang
        {
            get { return tang; }
            set { tang = value; }
        }

        public int Cot
        {
            get { return cot; }
            set { cot = value; }
        }

        public int Dong
        {
            get { return dong; }
            set { dong = value; }
        }

        public int IdXe
        {
            get { return idXe; }
            set { idXe = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
