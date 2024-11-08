using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SeasonOfGhosts.Db;

public class UpdateInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var entities = eventData
            .Context?
            .ChangeTracker
            .Entries<IUpdateTracking>()
            .Where(x => x.State is EntityState.Modified or EntityState.Added);

        if (entities is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        foreach (var entity in entities)
        {
            var dbValue = await entity.GetDatabaseValuesAsync(cancellationToken);
            if (dbValue is not null)
            {
                var value = dbValue.GetValue<DateTime>(nameof(IUpdateTracking.UpdatedAt));

                if (value > entity.Property(x => x.UpdatedAt).CurrentValue)
                {
                    foreach (var navigation in entity.Navigations)
                    {
                        navigation.EntityEntry.State = EntityState.Detached;
                    }
                    await entity.ReloadAsync(cancellationToken);
                    return InterceptionResult<int>.SuppressWithResult(0);
                }
                
            }
            
            entity.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
        }
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}