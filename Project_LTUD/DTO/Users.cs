using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Users
    {
        string Username, Password, Email;

        public string Email1
        {
            get { return Email; }
            set { Email = value; }
        }

        public string Password1
        {
            get { return Password; }
            set { Password = value; }
        }

        public string Username1
        {
            get { return Username; }
            set { Username = value; }
        }
        DateTime CreateDate;

        public DateTime CreateDate1
        {
            get { return CreateDate; }
            set { CreateDate = value; }
        }
    }
}
