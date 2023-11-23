using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    //AbstractUser kclass represents an abstract user with properties and methods.
    public abstract class AbstractUser
    {
        public static int RefrenceID = 1000;
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int PersonalNumber { get; set; }
        public bool IsAdmin { get; set; }

        //Constructor to initialize AbstractUser objekt with given information.
        public AbstractUser(string username, string password, string name, int personalnumber, bool isadmin)
        {
            UserName = username;
            PassWord = password;
            Name = name;
            ID = RefrenceID++;
            PersonalNumber = personalnumber;
            IsAdmin = isadmin;

        }
        //Abstract method to be implemented by derived classes for printing user information.
        public abstract void PrintInfo(); 
        
    }
}
