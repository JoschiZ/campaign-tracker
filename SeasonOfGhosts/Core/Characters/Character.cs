using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Characters;

public sealed class Character : IUpdateTracking
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
    public DateTime UpdatedAt { get; private init; }
    
    
    public async Task<CharacterAttitudeLog> ChangeAttitudeAsync(Attitude newAttitude, string reason, SeasonContext context)
    {
        var log = new CharacterAttitudeLog()
        {
            Character = this,
            NewValue = newAttitude,
            Reason = reason,
        };
        
        Log.Add(log);
        Attitude = newAttitude;
        context.Update(this);
        await context.SaveChangesAsync();
        return log;
    }

    public async Task<CharacterInfluenceLog> ChangeInfluence(Adjustment adjustment, SeasonContext context)
    {
        var log = new CharacterInfluenceLog()
        {
            Character = this,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason,
        };
        
        Log.Add(log);
        Influence += adjustment.Delta;
        context.Update(this);
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