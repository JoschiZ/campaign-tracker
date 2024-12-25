using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Settlements;

public sealed class Settlement : IUpdateTracking
{
    private Settlement(){}

    public Settlement(int level, int population)
    {
        Level = level;
        Population = population;
    }
    
    public SettlementId Id { get; private init;  }
    public required string Name { get; init;  }
    public required Campaign Campaign { get; init;  }
    public int Level { get; private set; }
    public int Population { get; private set; }
    public List<SettlementLog> Log { get; init; } = [];
    public DateTime UpdatedAt { get; private init; }

    public async Task<SettlementLevelLog?> AdjustLevelAsync(Adjustment adjustment, SeasonContext seasonContext)
    {

        Level += adjustment.Delta;

        var log = new SettlementLevelLog()
        {
            Settlement = this,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason
        };
        
        Log.Add(log);
        seasonContext.Update(this);
        await seasonContext.SaveChangesAsync();

        return log;
    }
    public async Task<SettlementPopulationLog?> AdjustPopulationAsync(Adjustment adjustment, SeasonContext seasonContext)
    {

        Population += adjustment.Delta;

        var log = new SettlementPopulationLog()
        {
            Settlement = this,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason
        };
        
        Log.Add(log);
        seasonContext.Update(this);
        await seasonContext.SaveChangesAsync();

        return log;
    }
}
