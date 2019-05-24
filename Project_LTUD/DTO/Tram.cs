using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tram
    {
        int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        string tenTram, diaDanh;

        public string DiaDanh
        {
            get { return diaDanh; }
            set { diaDanh = value; }
        }

        public string TenTram
        {
            get { return tenTram; }
            set { tenTram = value; }
        }
    }
}
