using Microsoft.EntityFrameworkCore;
using SeasonOfGhosts.Db;
using Testcontainers.PostgreSql;

namespace SeasonOfGhosts.Tests;

public class SeasonContextFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresSqlContainer = new PostgreSqlBuilder()
        .WithDatabase("season")
        .WithPassword("password")
        .WithUsername("username")
        .Build();

    private SeasonContext GetContext()
    {
        var options = new DbContextOptionsBuilder<SeasonContext>()
            .UseNpgsql(_postgresSqlContainer.GetConnectionString())
            .AddInterceptors(new CreationInterceptor())
            .Options;
        return new SeasonContext(options);
    }

    internal async Task<SeasonContext> GetContextAsync()
    {
        var context = GetContext();
        await context.Database.BeginTransactionAsync();
        return context;
    }
    
    public async Task InitializeAsync()
    {
        await _postgresSqlContainer.StartAsync();
        await using var context = GetContext();
        await context.Database.MigrateAsync();
    }

    public Task DisposeAsync()
    {
        return _postgresSqlContainer.StopAsync();
    }
}