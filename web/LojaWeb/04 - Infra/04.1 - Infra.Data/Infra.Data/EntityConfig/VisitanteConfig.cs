using Domain.Entities.Visitantes;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class VisitanteConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitante>(e =>
            {
                e.ToTable("Visitante");

                e.HasKey(w => w.Id);

                e.Property(w => w.Nome).HasMaxLength(100).IsRequired();
                e.Property(w => w.Sync).IsRequired();
            });
        }
    }
}