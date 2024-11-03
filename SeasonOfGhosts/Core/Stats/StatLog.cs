namespace SeasonOfGhosts.Core.Stats;

public sealed class StatLog : IDeltaLogEntry
{
    public StatLogId Id { get; init; }
    public required Stat Stat { get; init; }
    public required string Reason { get; init; }
    public required int Delta { get; init; }
    public DateTime CreatedAt { get; private set; }
}