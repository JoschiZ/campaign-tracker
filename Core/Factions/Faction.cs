using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;

namespace SeasonOfGhosts.Core.Factions;

internal sealed class Faction
{
    public required FactionId Id { get; init; }
    public required string Name { get; init; }
    public int Reputation { get; set; }
    public required Campaign Campaign { get; init; }
    public IEnumerable<Character> Characters { get; init; } = [];
}