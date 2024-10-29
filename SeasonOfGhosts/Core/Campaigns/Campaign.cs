using NanoidDotNet;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Cities;
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

    public static Campaign CreateSeasonOfGhosts(string name)
    {
        var seasonOfGhosts = new Campaign()
        {
            Name = name,
        };

        var willowshore = new Settlement()
        {
            Name = "Willowshore",
            Campaign = seasonOfGhosts,
            Level = 3,
            Population = 200
        };
        seasonOfGhosts.Settlements.Add(willowshore);

        var northridge = new Faction()
        {
            Campaign = seasonOfGhosts,
            Name = "Northridge"
        };

        var southbank = new Faction()
        {
            Campaign = seasonOfGhosts,
            Name = "Southbank"
        };
        
        seasonOfGhosts.Factions.AddRange([northridge, southbank]);

        var granny = new Character()
        {
            Name = "Granny Hu",
            Campaign = seasonOfGhosts,
            Ancestry = "Human",
            ShortDescription = "Northridge Leader",
            Description = "Northridge Leader",
            Factions = [northridge]
        };
        
        var matsuki = new Character()
        {
            Name = "Old Matsuki",
            Campaign = seasonOfGhosts,
            Ancestry = "Human",
            ShortDescription = "Southbank Leader",
            Description = "Southbank Leader",
            Factions = [southbank]
        };
        seasonOfGhosts.Characters.AddRange([granny, matsuki]);

        var security = new Stat()
        {
            Name = "Security",
            Campaign = seasonOfGhosts
        };
        
        var food = new Stat()
        {
            Name = "Food",
            Campaign = seasonOfGhosts
        };
        
        var hope = new Stat()
        {
            Name = "Hope",
            Campaign = seasonOfGhosts
        };
        seasonOfGhosts.Stats.AddRange([security, food, hope]);
        
        return seasonOfGhosts;
    }
}