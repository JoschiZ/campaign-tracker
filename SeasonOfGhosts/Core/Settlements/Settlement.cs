using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Settlements;

public sealed class Settlement
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

    public async Task<SettlementLevelLog?> AdjustLevelAsync(Adjustment adjustment, SeasonContext seasonContext)
    {
        var settlement = await seasonContext.FindAsync<Settlement>(Id);
        if (settlement is null)
        {
            return null;
        }

        settlement.Level += adjustment.Delta;

        var log = new SettlementLevelLog()
        {
            Settlement = settlement,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason
        };
        
        settlement.Log.Add(log);
        await seasonContext.SaveChangesAsync();

        return log;
    }
    public async Task<SettlementPopulationLog?> AdjustPopulationAsync(Adjustment adjustment, SeasonContext seasonContext)
    {
        var settlement = await seasonContext.FindAsync<Settlement>(Id);
        if (settlement is null)
        {
            return null;
        }

        settlement.Population += adjustment.Delta;

        var log = new SettlementPopulationLog()
        {
            Settlement = settlement,
            Delta = adjustment.Delta,
            Reason = adjustment.Reason
        };
        
        settlement.Log.Add(log);
        await seasonContext.SaveChangesAsync();

        return log;
    }
}
