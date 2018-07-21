using Application.Services.Visitante;
using Application.Services.Visitante.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaWeb.Controllers
{
    public class VisitanteController : Controller
    {
        private readonly IVisitanteAppService _visitanteServices;

        public VisitanteController(IVisitanteAppService visitanteServices)
        {
            _visitanteServices = visitanteServices;
        }

        [HttpGet]
        public IActionResult Alterar(Guid id)
        {
            var result = _visitanteServices.ObterDtoPeloId(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Alterar(VisitanteDto dto)
        {
            _visitanteServices.Alterar(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new VisitanteDto());
        }

        [HttpPost]
        public IActionResult Cadastrar(VisitanteDto dto)
        {
            _visitanteServices.SalvarSync(dto);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var result = _visitanteServices.ListarTodos();
            return View(result);
        }
    }
}