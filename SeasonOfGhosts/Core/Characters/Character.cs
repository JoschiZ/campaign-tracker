using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Db;
using StronglyTypedIds;

namespace SeasonOfGhosts.Core.Characters;

public sealed class Character
{
    public Character(){}

    public Character(int influence, Attitude startingAttitude)
    {
        Influence = influence;
        Attitude = startingAttitude;
    } 

    public CharacterId Id { get; private init; }
    public required string Name { get; set; }
    
    /// <summary>
    /// A shorter description, mostly a title or profession
    /// </summary>
    public string ShortDescription { get; set; } = "";
    public int Influence { get; private set; }
    public Attitude Attitude { get; private set; } = Attitude.Indifferent;
    public required Campaign Campaign { get; init; }
    public List<Faction> Factions { get; init; } = [];
    public List<CharacterLog> Log { get; init; } = [];
    
    
    public async Task<CharacterAttitudeLog> ChangeAttitudeAsync(Attitude newAttitude, string reason, SeasonContext context)
    {
        var character = await context.FindAsync<Character>(Id);

        var log = new CharacterAttitudeLog()
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

    public async Task<CharacterInfluenceLog> ChangeInfluence(Adjustment adjustment, SeasonContext context)
    {
        var character = await context.FindAsync<Character>(Id);

        var log = new CharacterInfluenceLog()
        {
            Character = character,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason,
        };
        
        character.Log.Add(log);
        character.Influence += adjustment.Delta;
        
        await context.SaveChangesAsync();
        return log;
    }
}

public sealed class CharacterLogConfiguration : IEntityTypeConfiguration<CharacterLog>
{
    public void Configure(EntityTypeBuilder<CharacterLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Reason).HasMaxLength(100);
        
        builder.HasDiscriminator<string>("LogType")
            .HasValue<CharacterAttitudeLog>("attitude")
            .HasValue<CharacterInfluenceLog>("influence");
    }
}

[StronglyTypedId]
public readonly partial struct CharacterLogId;

public abstract class CharacterLog : ICreationTracking
{
    public CharacterLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required Character Character { get; init; }
    public DateTime CreatedAt { get; private init; }
}

public sealed class CharacterAttitudeLog : CharacterLog
{
    public required Attitude NewAttitude { get; init; }
}

public sealed class CharacterInfluenceLog : CharacterLog
{
    public required int Delta { get; init; }
}