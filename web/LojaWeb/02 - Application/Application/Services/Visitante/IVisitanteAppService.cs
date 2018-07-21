using Application.Services.Visitante.Dtos;
using System;
using System.Collections.Generic;

namespace Application.Services.Visitante
{
    public interface IVisitanteAppService
    {
        void Alterar(VisitanteDto dto);

        bool CheckSync(Guid id);

        ICollection<VisitanteDto> ListarTodos();

        ICollection<VisitanteDto> ListarTodosPendentesDeSync();

        VisitanteDto ObterDtoPeloId(Guid id);

        bool SalvarSync(VisitanteDto dto);
    }
}