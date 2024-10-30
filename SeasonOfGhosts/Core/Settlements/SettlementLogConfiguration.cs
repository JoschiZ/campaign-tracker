using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeasonOfGhosts.Core.Settlements;

public sealed class SettlementLogConfiguration : IEntityTypeConfiguration<SettlementLog>
{
    public void Configure(EntityTypeBuilder<SettlementLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Reason).HasMaxLength(50);
        builder
            .HasDiscriminator<string>("LogType")
            .HasValue<SettlementLevelLog>("level")
            .HasValue<SettlementPopulationLog>("population");
        
    }
}