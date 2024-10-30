using Microsoft.EntityFrameworkCore;
using MudBlazor;
using SeasonOfGhosts.Core.Campaigns;
using SeasonOfGhosts.Core.Stats;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Tests.Core.Stats;

public class StatTests : IClassFixture<SeasonContextFixture>
{
    private readonly SeasonContextFixture _fixture;

    public StatTests(SeasonContextFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Should_Create_Log()
    {
        await using var context = await _fixture.GetContextAsync();


        var campaign = new Campaign()
        {
            Name = "Test Campaign",
        };
        
        var stat = new Stat()
        {
            Campaign = campaign,
            Name = "Test Stat",
        };
        
        campaign.Stats.Add(stat);
        
        context.Campaigns.Add(campaign);
        await context.SaveChangesAsync();
        
        context.ChangeTracker.Clear();

        var newLog = await stat.ChangeStatAsync(2, "Test", context);
        
        context.ChangeTracker.Clear();


        var refetchedCampaign = await context
            .Campaigns
            .Where(x => x.Id == campaign.Id)
            .Include(x => x.Stats.Where(s => s.Id == stat.Id))
            .ThenInclude(x => x.Log)
            .FirstAsync();

        var exists = refetchedCampaign.Stats.First().Log.Any(x => x.Id == newLog.Id);
        Assert.True(exists);

    }
}