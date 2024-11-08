using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Stats;

namespace SeasonOfGhosts.Core.Constants;

public static class AppRoutes
{
    public const string Home = "/";
    public const string Characters = "/characters";
    public const string Stats = "/stats";
    public const string Factions = "/factions";
    public const string Settlements = "/settlements";

    public const string CharacterPage = "/characters/{id}";
    public static string GetCharacterPage(CharacterId id) => $"/characters/{id}";
    
    public const string StatPage = "/stats/{id:int}";
    public static string GetStatPage(StatId id) => $"/stats/{id}";
}