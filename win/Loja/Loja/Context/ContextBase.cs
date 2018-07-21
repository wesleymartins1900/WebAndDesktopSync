using Loja.Domain;
using Loja.Domain.Base;
using Loja.Domain.Sync;
using Loja.Domain.Visitantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Configuration;

namespace Loja.Context
{
    public class ContextBase : DbContext
    {
        public DbSet<SyncSequence> SyncSequences { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<Visita> Visitas { get; set; }

        public EntityEntry AddEntity(object entity)
        {
            var entidade = entity as DomainBase;

            var dto = JsonConvert.SerializeObject(entidade.GetDto()).ToString();

            SyncSequence syncSequence;

            if (entidade.IsPost)
            {
                syncSequence = new SyncPost();
            }
            else
            {
                syncSequence = new SyncPut();
            }

            syncSequence.Concluido = false;
            syncSequence.DataDeCadastro = DateTime.Now;
            syncSequence.DtoJson = dto;
            syncSequence.EntidadeNome = entidade.GetType().Name;
            syncSequence.EntidadeId = entidade.Id;
            syncSequence.Id = Guid.NewGuid();

            this.Add(syncSequence);

            return Add(entity);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            optionsBuilder.UseSqlServer(connstr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SyncSequence>().ToTable("SyncSequence").HasKey(w => w.Id);
            modelBuilder.Entity<Visita>().ToTable("Visita").HasKey(w => w.Id);
            modelBuilder.Entity<Visitante>().ToTable("Visitante").HasKey(w => w.Id);

            modelBuilder.Entity<SyncSequence>()
                        .HasDiscriminator<string>("Discriminator")
                        .HasValue<SyncPost>("SyncPost")
                        .HasValue<SyncPut>("SyncPut");
        }
    }
}