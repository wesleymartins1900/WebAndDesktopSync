using Loja.Domain.Base;
using System;

namespace Loja.Domain.Visitantes
{
    public class Visitante : DomainBase
    {
        public DateTime DataDeCadastro { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }

        public override IDtoBase GetDto()
        {
            return new VisitanteDto()
            {
                Id = this.Id,
                Nome = this.Nome
            };
        }
    }
}