using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ATSChallenge.Domain.Entities;

namespace ATSChallenge.Infra.Data.Mapping
{
    public class LogMap : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateAt).IsRequired(true);
            builder.Property(x => x.Tipo).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Operacao).IsRequired(false);
            builder.Property(x => x.Mensagem).IsRequired(true);
            builder.Property(x => x.Exception).IsRequired(false).HasColumnType("text");
        }
    }
}
