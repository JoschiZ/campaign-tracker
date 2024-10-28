using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeasonOfGhosts.Core.Factions;

public sealed class FactionLogConfiguration : IEntityTypeConfiguration<FactionLog>
{
    public void Configure(EntityTypeBuilder<FactionLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Reason).HasMaxLength(100);
    }
}