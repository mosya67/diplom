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
    //internal class WorkerConf : IEntityTypeConfiguration<Worker>
    //{
    //    public void Configure(EntityTypeBuilder<Worker> entity)
    //    {
    //        entity.HasKey(e => e.Id);
    //        entity.HasIndex(e => e.Id).IsUnique();
    //        entity.HasIndex(e => e.Name);

    //        entity.Property(e => e.Name).IsRequired();
    //        entity.Property(e => e.Role).IsRequired();

    //        entity.HasOne(e => e.Role);
    //    }
    //}
}
