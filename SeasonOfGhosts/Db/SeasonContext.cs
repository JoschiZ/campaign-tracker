using Microsoft.EntityFrameworkCore;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Cities;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Core.Stats;

namespace SeasonOfGhosts.Db;

internal sealed class SeasonContext : DbContext
{
    public SeasonContext(DbContextOptions<SeasonContext> options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors([new CreationInterceptor()]);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeasonContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<CharacterId>().HaveConversion<CharacterId.EfCoreValueConverter>();
        configurationBuilder.Properties<CampaignId>().HaveConversion<CampaignId.EfCoreValueConverter>();
        configurationBuilder.Properties<SettlementId>().HaveConversion<SettlementId.EfCoreValueConverter>();
        configurationBuilder.Properties<FactionId>().HaveConversion<FactionId.EfCoreValueConverter>();
        configurationBuilder.Properties<StatId>().HaveConversion<StatId.EfCoreValueConverter>();
        configurationBuilder.Properties<StatLogId>().HaveConversion<StatLogId.EfCoreValueConverter>();
        base.ConfigureConventions(configurationBuilder);
    }

    private DbSet<Character> Characters { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    private DbSet<Settlement> Settlements { get; set; }
    private DbSet<Stat> Stats { get; set; }
    private DbSet<Faction> Factions { get; set; }
    private DbSet<StatLog> StatLogs { get; set; }
}