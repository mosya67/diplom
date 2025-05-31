using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.model;

namespace Database.Db.EntityTypeConfig
{
    internal class FaultConf : IEntityTypeConfiguration<Fault>
    {
        public void Configure(EntityTypeBuilder<Fault> entity)
        {
            entity.HasKey(e => e.FaultId);
            entity.HasIndex(e => e.FaultId).IsUnique();

            entity.Property(e => e.Description).IsRequired();

            entity.HasOne(e => e.Order)
                .WithOne(e => e.Fault)
                .HasForeignKey<Order>(e => e.Id);
            entity.HasOne(e => e.Solution)
                .WithOne(e => e.Fault)
                .HasForeignKey<Solution>(e => e.SolutionId);
            entity.HasOne(e => e.Device);
        }
    }
}
