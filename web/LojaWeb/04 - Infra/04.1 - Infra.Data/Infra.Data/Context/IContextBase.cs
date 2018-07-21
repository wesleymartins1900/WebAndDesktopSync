using Domain.Entities.Visitantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infra.Data.Context
{
    public interface IContextBase
    {
        DbSet<Visitante> Visitantes { get; set; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}