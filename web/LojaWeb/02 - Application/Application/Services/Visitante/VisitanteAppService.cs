using Application.Services.Visitante.Dtos;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Visitante
{
    public class VisitanteAppService : IVisitanteAppService
    {
        private readonly IContextBase _context;

        public VisitanteAppService(IContextBase context)
        {
            _context = context;
        }

        public void Alterar(VisitanteDto dto)
        {
            var visitante = _context.Visitantes.Find(dto.Id);
            visitante.Nome = dto.Nome;
            visitante.Sync = true;

            _context.Visitantes.Update(visitante);
            _context.SaveChanges();
        }

        public bool CheckSync(Guid id)
        {
            var visitante = _context.Visitantes.Find(id);
            visitante.Sync = false;

            _context.Visitantes.Update(visitante);
            _context.SaveChanges();

            return true;
        }

        public ICollection<VisitanteDto> ListarTodos()
        {
            var visitantes = _context.Visitantes
                                     .Where(v => v.Sync)
                                     .ToList();

            return _context.Visitantes
                            .Select(v => new VisitanteDto
                            {
                                Id = v.Id,
                                Nome = v.Nome
                            })
                            .ToList();
        }

        public ICollection<VisitanteDto> ListarTodosPendentesDeSync()
        {
            return _context.Visitantes
                            .Where(v => v.Sync)
                            .Select(v => new VisitanteDto
                            {
                                Id = v.Id,
                                Nome = v.Nome
                            })
                            .ToList();
        }

        public ICollection<VisitanteDto> ListarVisitantesDoMes(int mes, int ano)
        {
            return _context.Visitantes
                            .Select(v => new VisitanteDto
                            {
                                Id = v.Id,
                                Nome = v.Nome
                            })
                            .ToList();
        }

        public VisitanteDto ObterDtoPeloId(Guid id)
        {
            return _context.Visitantes
                            .Where(v => v.Id == id)
                            .Select(v => new VisitanteDto
                            {
                                Id = v.Id,
                                Nome = v.Nome
                            })
                            .FirstOrDefault();
        }

        public bool SalvarSync(VisitanteDto dto)
        {
            var visitante = new Domain.Entities.Visitantes.Visitante()
            {
                Nome = dto.Nome,
                Sync = true
            };
            visitante.SetId(dto.Id);

            _context.Visitantes.Add(visitante);
            _context.SaveChanges();

            return true;
        }
    }
}