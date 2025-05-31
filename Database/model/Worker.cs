using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.model
{
    public class Worker
    {
        public int Id;
        public string Name;

        public List<Order> Orders;
    }
}
