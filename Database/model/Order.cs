using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.model
{
    public class Order
    {
        public int Id;
        //public long PaymentAmount;
        public DateTime Created_At;

        public Customer Customer;
        public Fault Fault;
        public Status Status;
        //public Worker Worker;
    }
}
