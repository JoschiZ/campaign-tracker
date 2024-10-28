using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Stats;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Factions;

internal sealed class Faction
{
    public required FactionId Id { get; init; }
    public required string Name { get; init; }
    public int Reputation { get; private set; }
    public required Campaign Campaign { get; init; }
    public List<Character> Characters { get; init; } = [];
    public List<FactionLog> Log { get; init; } = [];

    public async Task<FactionLog> ChangeReputationAsync(int delta, string reason, SeasonContext context)
    {
        var log = new FactionLog()
        {
            Delta = delta,
            Reason = reason,
            Faction = this
        };

        context.Attach(this);
        
        Reputation += delta;
        Log.Add(log);
        
        await context.SaveChangesAsync();
        return log;
    }
    
}