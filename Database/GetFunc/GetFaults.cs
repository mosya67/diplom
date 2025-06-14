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
            bool name = false;
            bool lastname = false;
            bool surname = false;
            var a = context.Faults.AsNoTracking()
                .Include(e => e.Order).ThenInclude(e => e.Customer)
                .Include(e => e.Order).ThenInclude(e => e.Status)
                .Include(e => e.Device)
                .Where(e => (e.Order.Created_At >= filters.createDateFirst && e.Order.Created_At <= filters.createDateLast)
                    && e.Device.Name.Contains(filters.device.Name)
                    && e.Device.Model.Contains(filters.device.Model)
                );
            if (!string.IsNullOrEmpty(filters.firstName))
                name = true;
            if (!string.IsNullOrEmpty(filters.lastName))
                lastname = true;
            if (!string.IsNullOrEmpty(filters.surname))
                surname = true;

            a = a.Where(e => (name ? e.Order.Customer.FirstName.ToLower() == filters.firstName.ToLower() : true) && (lastname ? e.Order.Customer.LastName.ToLower() == filters.lastName.ToLower() : true) && (surname ? e.Order.Customer.Surname.ToLower() == filters.surname.ToLower() : true));

            return a.ToList();
        }
    }
}
