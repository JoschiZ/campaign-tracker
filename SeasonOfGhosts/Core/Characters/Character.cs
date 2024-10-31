using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Db;
using StronglyTypedIds;

namespace SeasonOfGhosts.Core.Characters;

public sealed class Character
{
    public CharacterId Id { get; private init; }
    public required string Name { get; set; }
    public string Ancestry { get; set; } = "";
    
    /// <summary>
    /// A shorter description, mostly a title or profession
    /// </summary>
    public string ShortDescription { get; set; } = "";
    public string Description { get; set; } = "";
    public Attitude Attitude { get; private set; } = Attitude.Indifferent;
    public required Campaign Campaign { get; init; }
    public List<Faction> Factions { get; init; } = [];
    public List<CharacterLog> Log { get; init; } = [];
    
    
    public async Task<CharacterLog> ChangeAttitudeAsync(Attitude newAttitude, string reason, SeasonContext context)
    {
        var character = await context.FindAsync<Character>(Id);

        var log = new CharacterLog()
        {
            Character = character,
            NewAttitude = newAttitude,
            Reason = reason,
        };
        
        character.Log.Add(log);
        character.Attitude = newAttitude;
        
        await context.SaveChangesAsync();
        return log;
    }
}

public sealed class CharacterLog : ICreationTracking
{
    public CharacterLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required Attitude NewAttitude { get; init; }
    public required Character Character { get; init; }
    public DateTime CreatedAt { get; private init; }

}

public sealed class CharacterLogConfiguration : IEntityTypeConfiguration<CharacterLog>
{
    public void Configure(EntityTypeBuilder<CharacterLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Reason).HasMaxLength(100);
    }
}

[StronglyTypedId]
public readonly partial struct CharacterLogId;