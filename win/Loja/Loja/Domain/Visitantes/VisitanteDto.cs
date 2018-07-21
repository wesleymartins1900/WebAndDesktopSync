using Loja.Domain.Base;
using System;

namespace Loja.Domain.Visitantes
{
    public class VisitanteDto : IDtoBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}