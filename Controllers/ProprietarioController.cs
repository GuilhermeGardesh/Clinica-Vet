using ClinicaVet.GestaoVeterinaria.Constantes;
using ClinicaVet.GestaoVeterinaria.Extensions;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    [ClaimsControllerAuthorize(AreasConstantes.PROPRIETARIO)]
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IProprietarioService _proprietarioService;

        public ProprietarioController(
            IProprietarioRepository proprietarioRepository,
            IProprietarioService proprietarioService)
        {
            _proprietarioRepository = proprietarioRepository;
            _proprietarioService = proprietarioService;
        }

        // GET: ProprietarioController
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.LER)]
        public ActionResult Index()
        {
            var proprietarios = _proprietarioRepository.ObterTodos();
            return View(proprietarios);
        }

        // GET: ProprietarioController/Details/5
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.LER)]
        public ActionResult Details(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // GET: ProprietarioController/Create
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.CRIAR)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProprietarioController/Create
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.CRIAR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proprietario proprietario)
        {
            try
            {
                _proprietarioRepository.Inserir(proprietario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(proprietario);
            }
        }

        // GET: ProprietarioController/Edit/5
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.EDITAR)]
        public ActionResult Edit(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // POST: ProprietarioController/Edit/5
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.EDITAR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proprietario proprietario)
        {
            try
            {
                _proprietarioRepository.Atualizar(proprietario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(proprietario);
            }
        }

        // GET: ProprietarioController/Delete/5
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.EXCLUIR)]
        public ActionResult Delete(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // POST: ProprietarioController/Delete/5
        [ClaimsAuthorize(AreasConstantes.PROPRIETARIO, PermissoesConstantes.EXCLUIR)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            try
            {
                _proprietarioRepository.Deletar(proprietario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(proprietario);
            }
        }
    }
}
