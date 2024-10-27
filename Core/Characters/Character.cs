using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Factions;

namespace SeasonOfGhosts.Core.Characters;

internal sealed class Character
{
    public CharacterId Id { get; init; }
    public required string Name { get; set; }
    public string Race { get; set; } = "";
    public string ShortDescription { get; set; } = "";
    public string Description { get; set; } = "";
    public Attitude Attitude { get; set; } = Attitude.Indifferent;
    public required Campaign Campaign { get; init; }
    public List<Faction> Factions { get; init; } = [];
}