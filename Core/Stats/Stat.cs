using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeasonOfGhosts.Core.Campaigns;
using StronglyTypedIds;

namespace SeasonOfGhosts.Core.Stats;

internal sealed class Stat
{
    public required StatId Id { get; init; }
    public required string Name { get; init; }
    public int Value { get; init; }
    public required Campaign Campaign { get; init; }
}

internal sealed class StatConfiguration: IEntityTypeConfiguration<Stat>
{
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(50);
    }
}

[StronglyTypedId]
internal readonly partial struct StatId;