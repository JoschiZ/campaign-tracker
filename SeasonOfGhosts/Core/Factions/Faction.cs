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
        var faction = await context.FindAsync<Faction>(Id);

        if (faction is null)
        {
            return null;
        }
        
        var log = new FactionLog()
        {
            Delta = delta,
            Reason = reason,
            Faction = faction
        };
        
        Reputation += delta;
        Log.Add(log);
        
        await context.SaveChangesAsync();
        return log;
    }
    
}