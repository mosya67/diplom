using Database.model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Db.EntityTypeConfig
{
    internal class OrderConf : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id).IsUnique();
            entity.HasIndex(e => e.Created_At);

            entity.Property(e => e.Created_At).IsRequired();

            entity.HasOne(e => e.Customer)
                .WithMany(e => e.AllOrders);
            entity.HasOne(e => e.Fault)
                .WithOne(e => e.Order);
            entity.HasOne(e => e.Status);
            //entity.HasOne(e => e.Worker)
            //    .WithMany(e => e.Orders);
        }
    }
}
