using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazor;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Db;
using StronglyTypedIds;

namespace SeasonOfGhosts.Core.Stats;

public sealed class Stat : IUpdateTracking
{
    public StatId Id { get; init; }
    public required string Name { get; init; }
    public int Value { get; private set; }
    public required Campaign Campaign { get; init; }
    public List<StatLog> Log { get; init; } = [];
    public DateTime UpdatedAt { get; private init; }

    public async Task<StatLog?> ChangeStatAsync(int delta, string reason, SeasonContext context)
    {
        var log = new StatLog()
        {
            Delta = delta,
            Reason = reason,
            Stat = this
        };
        
        Value += delta;
        Log.Add(log);
        context.Update(this);
        await context.SaveChangesAsync();

        return log;
    }

    public Task ChangeStatAsync(Adjustment adjustment, SeasonContext context)
        => ChangeStatAsync(adjustment.Delta, adjustment.Reason, context); 
}

public sealed class StatConfiguration: IEntityTypeConfiguration<Stat>
{
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.HasMany(x => x.Log).WithOne(x => x.Stat).IsRequired();
    }
}

[StronglyTypedId]
public readonly partial struct StatId;