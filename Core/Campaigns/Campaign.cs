using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Cities;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Core.Stats;

namespace SeasonOfGhosts.Core.Campaigns;

internal sealed class Campaign
{
    public CampaignId Id { get; init; }
    public Season CurrentSeason { get; set; } = Season.Summer;
    
    public required string UrlSlug { get; init; }
    public required string Name { get; set; }

    public List<Character> Characters { get; init; } = [];
    public List<Settlement> Settlements { get; init; } = [];
    public List<Stat> Stats { get; init; } = [];
    public List<Faction> Factions { get; set; } = [];
}