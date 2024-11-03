namespace SeasonOfGhosts.Core.Factions;

public sealed class FactionLog : IDeltaLogEntry
{
    public FactionLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required int Delta  { get; init; }
    public required Faction Faction { get; init; }
    public DateTime CreatedAt { get; private init; }
}