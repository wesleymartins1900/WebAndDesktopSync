using Application.Services.Visitante;
using Application.Services.Visitante.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LojaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Visitante")]
    public class VisitanteApiController : Controller
    {
        private readonly IVisitanteAppService _visitanteServices;

        public VisitanteApiController(IVisitanteAppService visitanteServices)
        {
            _visitanteServices = visitanteServices;
        }

        [HttpPut("[action]")]
        public bool CheckSync([FromBody] Guid id)
        {
            _visitanteServices.CheckSync(id);

            return true;
        }

        [HttpGet("[action]")]
        public ICollection<VisitanteDto> GetSync()
        {
            return _visitanteServices.ListarTodosPendentesDeSync();
        }

        [HttpPost("[action]")]
        public bool Sync([FromBody] VisitanteDto dto)
        {
            _visitanteServices.SalvarSync(dto);

            return true;
        }
    }
}