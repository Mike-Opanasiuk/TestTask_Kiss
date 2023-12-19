using Api.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Configuration.Abstract;

internal class BaseEntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(u => u.CreatedOn).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
        builder.Property(u => u.ModifiedOn).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();
    }
}
