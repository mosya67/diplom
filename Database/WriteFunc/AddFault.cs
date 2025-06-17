using Database.Db;
using Database.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.WriteFunc
{
    public class AddFault : IWriteFunc<Fault>
    {
        readonly Context context;

        public AddFault(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Write(Fault fault)
        {
            if (string.IsNullOrEmpty(fault.Description)) throw new ArgumentNullException(nameof(fault.Description));

            Device? device = context.Devices.FirstOrDefault(e => e.Name == fault.Device.Name && e.Model == fault.Device.Model);
            if (device == null) context.Devices.Add(fault.Device);
            else fault.Device = device;
            context.Faults.Add(fault);
        }
    }
}
