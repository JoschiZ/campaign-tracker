using Microsoft.EntityFrameworkCore;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Characters;
using SeasonOfGhosts.Core.Factions;
using SeasonOfGhosts.Core.Settlements;
using SeasonOfGhosts.Core.Stats;
using SettlementId = SeasonOfGhosts.Core.Settlements.SettlementId;

namespace SeasonOfGhosts.Db;

public sealed class SeasonContext : DbContext
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
        configurationBuilder.Properties<FactionLogId>().HaveConversion<FactionLogId.EfCoreValueConverter>();
        configurationBuilder.Properties<CharacterLogId>().HaveConversion<CharacterLogId.EfCoreValueConverter>();
        configurationBuilder.Properties<SettlementLogId>().HaveConversion<SettlementLogId.EfCoreValueConverter>();
        
        base.ConfigureConventions(configurationBuilder);
    }

    private DbSet<Character> Characters { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    private DbSet<Settlement> Settlements { get; set; }
    private DbSet<Stat> Stats { get; set; }
    private DbSet<Faction> Factions { get; set; }
    private DbSet<StatLog> StatLogs { get; set; }
    private DbSet<FactionLog> FactionLogs { get; set; }
    private DbSet<SettlementLog> SettlementLogs { get; set; }
    private DbSet<SettlementPopulationLog> SettlementPopulationLogs { get; set; }
    private DbSet<SettlementLevelLog> SettlementLevelLogs { get; set; }
}