using Database.Db;
using Database.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.WriteFunc
{
    public class AddOrder : IWriteFunc<Order>
    {
        readonly Context context;
        IWriteFunc<Fault> addFault;

        public AddOrder(Context context, IWriteFunc<Fault> addFault)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.addFault = addFault ?? throw new ArgumentNullException(nameof(addFault));
        }

        public void Write(Order order)
        {
            order.Status = context.Statuses.FirstOrDefault(e => e.Name == "В работе");

            var cust = context.Customers.FirstOrDefault(e => 
                e.FirstName == order.Customer.FirstName &&
                e.LastName == order.Customer.LastName &&
                e.Surname == order.Customer.Surname);

            if (cust == null) context.Customers.Add(order.Customer);

            
            addFault.Write(order.Fault);

            context.Orders.Add(order);

            context.SaveChanges();
        }
    }
}
