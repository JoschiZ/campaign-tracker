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
        configurationBuilder.Properties<FactionLogId>().HaveConversion<FactionLogId.EfCoreValueConverter>();

        
        base.ConfigureConventions(configurationBuilder);
    }

    // ReSharper disable UnassignedGetOnlyAutoProperty
    private DbSet<Character> Characters { get; }
    public DbSet<Campaign> Campaigns { get; }
    private DbSet<Settlement> Settlements { get; }
    private DbSet<Stat> Stats { get; }
    private DbSet<Faction> Factions { get;  }
    private DbSet<StatLog> StatLogs { get;  }
    private DbSet<FactionLog> FactionLogs { get; }
    // ReSharper restore UnassignedGetOnlyAutoProperty
}