using SeasonOfGhosts.Core.Campaigns;

namespace SeasonOfGhosts.Core.Cities;

internal sealed class Settlement
{
    public required SettlementId Id { get; init;  }
    public required string Name { get; init;  }
    public required Campaign Campaign { get; init;  }
    public required int Level { get; set; }
    public required int Population { get; set; }
}