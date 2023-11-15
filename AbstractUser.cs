using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public abstract class AbstractUser
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int PersonalNumber { get; set; }
        public bool IsAdmin { get; set; }

        public AbstractUser(string name, int id, int personalnumber, bool isadmin)
        {
            Name = name;
            ID = id;
            PersonalNumber = personalnumber;
            IsAdmin = isadmin;

        }
        public abstract void PrintInfo(); 
        
    }
}
