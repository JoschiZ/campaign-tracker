using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeasonOfGhosts.Core.Campaigns;

internal sealed class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Property(c => c.Name).IsRequired().HasMaxLength(40);
        builder.Property(x => x.UrlSlug).IsRequired().HasMaxLength(5);
        
        builder.HasMany(c => c.Characters).WithOne(x => x.Campaign);
        builder.HasMany(x => x.Settlements).WithOne(x => x.Campaign);
        builder.HasMany(x => x.Stats).WithOne(x => x.Campaign);
        builder.HasMany(x => x.Factions).WithOne(x => x.Campaign);
    }
}