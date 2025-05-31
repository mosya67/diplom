using Database.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.WriteFunc
{
    public class AddCustomer
    {
        readonly Context context;

        public AddCustomer(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
