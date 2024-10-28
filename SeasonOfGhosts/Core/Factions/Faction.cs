using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Stats;
using SeasonOfGhosts.Db;
using StronglyTypedIds;

namespace SeasonOfGhosts.Core.Factions;

internal sealed class Faction
{
    public required FactionId Id { get; init; }
    public required string Name { get; init; }
    public int Reputation { get; set; }
    public required Campaign Campaign { get; init; }
    public List<Character> Characters { get; init; } = [];
    
    public List<FactionLog> Log { get; init; } = [];
}

internal sealed class FactionLog : ICreationTracking
{
    public FactionLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required int Delta  { get; init; }
    public required Faction Faction { get; init; }
    public DateTime CreatedAt { get; private init; }
}

internal sealed class FactionLogConfiguration : IEntityTypeConfiguration<FactionLog>
{
    public void Configure(EntityTypeBuilder<FactionLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Reason).HasMaxLength(100);
    }
}

[StronglyTypedId]
internal readonly partial struct FactionLogId;