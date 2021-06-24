using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATSChallenge.Domain.Entities;

namespace ATSChallenge.Infra.Data.Mapping
{
    public class JobMap : IEntityTypeConfiguration<JobEntity>
    {
        public void Configure(EntityTypeBuilder<JobEntity> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(true).HasColumnType("text");
            builder.Property(x => x.CreateAt).IsRequired(true);
            builder.Property(x => x.UpdateAt).IsRequired(false);
        }
    }
}
