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
    internal class SolutionConf : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> entity)
        {
            entity.HasKey(e => e.SolutionId);
            entity.HasIndex(e => e.SolutionId).IsUnique();
            entity.HasIndex(e => e.DateResolved);

            entity.Property(e => e.Description);
            entity.Property(e => e.DateResolved).IsRequired();


            //entity.HasOne(e => e.Fault)
            //    .WithOne(e => e.Solution);
        }
    }
}
