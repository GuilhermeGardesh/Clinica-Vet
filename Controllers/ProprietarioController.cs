using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    [Authorize]
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
        public ActionResult Index()
        {
            var proprietarios = _proprietarioRepository.ObterTodos();
            return View(proprietarios);
        }

        // GET: ProprietarioController/Details/5
        public ActionResult Details(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // GET: ProprietarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProprietarioController/Create
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
        public ActionResult Edit(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // POST: ProprietarioController/Edit/5
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
        public ActionResult Delete(int idProprietario)
        {
            var proprietario = _proprietarioRepository.ObterPorId(idProprietario);
            return View(proprietario);
        }

        // POST: ProprietarioController/Delete/5
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
