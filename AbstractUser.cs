using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public abstract class AbstractUser
    {
        public static int RefrenceID = 1000;
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int PersonalNumber { get; set; }
        public bool IsAdmin { get; set; }

        public AbstractUser(string username, string password, string name, int personalnumber, bool isadmin)
        {
            UserName = username;
            PassWord = password;
            Name = name;
            ID = RefrenceID++;
            PersonalNumber = personalnumber;
            IsAdmin = isadmin;

        }
        public abstract void PrintInfo(); 
        
    }
}
