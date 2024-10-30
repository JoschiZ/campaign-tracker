using NanoidDotNet;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Core.Settlements;
using SeasonOfGhosts.Core.Stats;

namespace SeasonOfGhosts.Core.Campaigns;

public sealed class Campaign
{
    public CampaignId Id { get; init; }
    public Season CurrentSeason { get; set; } = Season.Summer;

    public string Code { get; private init; } = Nanoid.Generate(Nanoid.Alphabets.LowercaseLetters, 10);
    public required string Name { get; set; }

    public List<Character> Characters { get; init; } = [];
    public List<Settlement> Settlements { get; init; } = [];
    public List<Stat> Stats { get; init; } = [];
    public List<Faction> Factions { get; set; } = [];
    public Settlement? MainSettlement { get; set; }

}