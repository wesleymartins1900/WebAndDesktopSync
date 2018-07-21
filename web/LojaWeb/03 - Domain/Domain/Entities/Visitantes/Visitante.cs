using Domain.Base;
using System;

namespace Domain.Entities.Visitantes
{
    public class Visitante : DomainBase, IVisitante
    {
        public string Logradouro { get; set; }
        public string Nome { get; set; }

        public override IDtoBase GetDto()
        {
            throw new NotImplementedException();
        }
    }
}