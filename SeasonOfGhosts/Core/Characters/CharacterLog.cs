namespace SeasonOfGhosts.Core.Characters;

public abstract class CharacterLog : ILogEntry
{
    public CharacterLogId Id { get; private init; }
    public required string Reason { get; init; }
    public required Character Character { get; init; }
    public DateTime CreatedAt { get; private init; }
}