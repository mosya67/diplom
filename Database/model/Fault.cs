using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.model
{
    public class Fault
    {
        public int FaultId;
        public string Description;

        public Order Order;
        public Solution Solution;
        public Device Device;
    }
}
