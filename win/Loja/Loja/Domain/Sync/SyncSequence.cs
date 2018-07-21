using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Sync
{
    public class SyncSequence
    {
        public bool Concluido { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public string DtoJson { get; set; }
        public Guid EntidadeId { get; set; }
        public string EntidadeNome { get; set; }

        [Key]
        public Guid Id { get; set; }
    }
}