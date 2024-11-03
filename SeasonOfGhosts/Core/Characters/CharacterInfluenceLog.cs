namespace SeasonOfGhosts.Core.Characters;

public sealed class CharacterInfluenceLog : CharacterLog, IDeltaLogEntry
{
    public required int Delta { get; init; }
}