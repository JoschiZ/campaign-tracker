using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Stats;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Factions;

public sealed class Faction : IUpdateTracking
{
    public FactionId Id { get; private init; }
    public required string Name { get; init; }
    public int Reputation { get; private set; }
    public required Campaign Campaign { get; init; }
    public List<Character> Characters { get; init; } = [];
    public List<FactionLog> Log { get; init; } = [];
    public DateTime UpdatedAt { get; private init; }
    
    public async Task<FactionLog?> ChangeReputationAsync(int delta, string reason, SeasonContext context)
    {
        
        var log = new FactionLog()
        {
            Delta = delta,
            Reason = reason,
            Faction = this
        };
        
        Reputation += delta;
        Log.Add(log);
        context.Update(this);
        await context.SaveChangesAsync();
        return log;
    }
    
}