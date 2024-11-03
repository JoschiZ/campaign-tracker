using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Settlements;

public abstract class SettlementLog : IDeltaLogEntry
{
    public SettlementLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required int Delta  { get; init; }
    public DateTime CreatedAt { get; private set; }
    public required Settlement Settlement { get; init; }
}

public sealed class SettlementLevelLog : SettlementLog;
public sealed class SettlementPopulationLog : SettlementLog;