using Domain.Entities.Sync;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntityConfig
{
    public class SyncSequenceConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SyncSequence>(e =>
            {
                e.ToTable("SyncSequence");

                e.HasKey(w => w.Id);

                e.HasDiscriminator<string>("Discriminator")
                        .HasValue<SyncPost>("SyncPost")
                        .HasValue<SyncPut>("SyncPut");
            });
        }
    }
}