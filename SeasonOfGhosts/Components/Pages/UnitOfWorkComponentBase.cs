using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using SeasonOfGhosts.Db;

namespace SeasonOfGhosts.Components.Pages;

public abstract class UnitOfWorkComponentBase : ComponentBase, IDisposable, IAsyncDisposable
{
    [Inject]
    public required IDbContextFactory<SeasonContext> ContextFactory { get; init; }
    
    protected SeasonContext Context { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Context = await ContextFactory.CreateDbContextAsync();
        await base.OnInitializedAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await Context.DisposeAsync();
    }
}