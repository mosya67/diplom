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
    internal class CustomerConf : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id).IsUnique();
            entity.HasIndex(e => e.FirstName);
            entity.HasIndex(e => e.LastName);
            entity.HasIndex(e => e.Surname);

            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName);
            entity.Property(e => e.Surname);

            entity.HasMany(e => e.AllOrders)
                .WithOne(e => e.Customer);
        }
    }
}
