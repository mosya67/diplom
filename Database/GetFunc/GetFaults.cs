using Database.Db;
using Database.dto;
using Database.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.GetFunc
{
    public class GetFaults : IGetFunc<List<Fault>, SearchFilterDTO>
    {
        readonly Context context;

        public GetFaults(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Fault> Get(SearchFilterDTO filters)
        {
            var a = context.Faults.AsNoTracking()
                .Include(e => e.Order).ThenInclude(e => e.Customer)
                .Include(e => e.Device)
                .Where(e => (e.Order.Created_At >= filters.createDateFirst && e.Order.Created_At <= filters.createDateLast)
                    && e.Device.Name.Contains(filters.device.Name)
                    && e.Device.Model.Contains(filters.device.Model)
                );
            if (!string.IsNullOrEmpty(filters.firstName))
                a = a.Where(e => string.IsNullOrEmpty(filters.firstName) ? e.Order.Customer.FirstName == filters.firstName : true);
            if (!string.IsNullOrEmpty(filters.lastName))
                a = a.Where(e => string.IsNullOrEmpty(filters.firstName) ? e.Order.Customer.FirstName == filters.firstName : true);
            if (!string.IsNullOrEmpty(filters.surname))
                a = a.Where(e => string.IsNullOrEmpty(filters.firstName) ? e.Order.Customer.FirstName == filters.firstName : true);

            return a.ToList();
        }
    }
}
