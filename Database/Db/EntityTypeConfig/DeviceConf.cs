using Database.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Db.EntityTypeConfig
{
    internal class DeviceConf : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> entity)
        {
            entity.HasKey(e => e.DeviceId);
            entity.HasIndex(e => e.DeviceId).IsUnique();
            entity.HasIndex(e => e.Name);
            entity.HasIndex(e => e.Model);

            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Model).IsRequired();
        }
    }
}