using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeasonOfGhosts.Core.Stats;

internal sealed class StatLogConfiguration : IEntityTypeConfiguration<StatLog>
{
    public void Configure(EntityTypeBuilder<StatLog> builder)
    {
        builder.HasKey((x => x.Id));
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Reason).HasMaxLength(100);
    }
}