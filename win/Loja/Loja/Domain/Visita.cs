using Loja.Domain.Base;
using Loja.Domain.Visitantes;

namespace Loja.Domain
{
    public class Visita : DomainBase
    {
        public virtual Visitante Visitante { get; set; }
        public int VisitanteId { get; set; }

        public override IDtoBase GetDto()
        {
            throw new System.NotImplementedException();
        }
    }
}