using Database.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Db.EntityTypeConfig
{
    internal class StatusConf : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasKey(e => e.StatusId);
            entity.HasIndex(e => e.StatusId).IsUnique();
            entity.HasIndex(e => e.Name);

            entity.Property(e => e.Name).IsRequired();

        }
    }
}