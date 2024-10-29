using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Cities;

namespace SeasonOfGhosts.Core.Settlements;

public sealed class Settlement
{
    public SettlementId Id { get; private init;  }
    public required string Name { get; init;  }
    public required Campaign Campaign { get; init;  }
    public required int Level { get; set; }
    public required int Population { get; set; }
}