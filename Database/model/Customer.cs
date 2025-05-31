using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.model
{
    public class Customer
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string Surname;
        public int RequestsCount;

        public List<Order> AllOrders;
    }
}
