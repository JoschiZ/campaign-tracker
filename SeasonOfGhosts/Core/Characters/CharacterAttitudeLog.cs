namespace SeasonOfGhosts.Core.Characters;

public sealed class CharacterAttitudeLog : CharacterLog, ILogEntry<Attitude>
{
    public required Attitude NewValue { get; init; }
}