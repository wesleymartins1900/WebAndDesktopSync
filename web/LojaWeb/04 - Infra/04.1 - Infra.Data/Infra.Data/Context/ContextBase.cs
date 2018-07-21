using Domain.Base;
using Domain.Entities.Sync;
using Domain.Entities.Visitantes;
using Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Infra.Data.Context
{
    public class ContextBase : DbContext, IContextBase
    {
        public ContextBase(DbContextOptions<ContextBase> options)
           : base(options)
        {
        }

        public DbSet<SyncSequence> SyncSequences { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }

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
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new VisitanteConfig().DefinirConfiguracoesDaEntidade(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}