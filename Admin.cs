using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class Admin
    { 

        //Create Lists of administrators and customers
        private List<string> administrators = new List<string>();
        private List<string> customers = new List<string>();

        //Method to add administrators
        public void AddAdministrator(string administratorName)
        {
            administrators.Add(administratorName);
        }
        //Method to add customers
        public void AddCustomer(string custumerName)
        {
            customers.Add(custumerName);
        }

        //Method to get administrators
        public List<string> GetAdministrators()
        {
            return administrators;
        }
        
        //Method to get customers
        public List<string> GetCustomers()
        {
            return customers;
        }

    }
}
