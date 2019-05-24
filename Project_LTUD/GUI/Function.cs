using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Function
    {
        private static Function instance;
        public static Function Instance
        {
            get
            {
                if (Function.instance == null)
                {
                    Function.instance = new Function();
                }
                return Function.instance;

            }
            set { Function.instance = value; }
        }
        public string ChuanHoa(string str)
        {
            str = str.Trim();
            while (str.IndexOf("\t") >= 0)
            {
                str = str.Replace("\t", " ");
            }
            while (str.IndexOf("  ") >= 0)
            {
                str = str.Replace("  ", " ");
            }
            string[] arrStr = str.Split(' ');
            string s = "";
            foreach (string item in arrStr)
            {
                s += item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower() + " ";

            }
            return s;
        }
    }
}
