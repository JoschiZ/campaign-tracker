using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Core.Stats;

public sealed class StatLog : ICreationTracking
{
    public StatLogId Id { get; init; }
    public required Stat Stat { get; init; }
    public required string Reason { get; init; }
    public required int Delta { get; init; }
    public DateTime CreatedAt { get; private set; }
}