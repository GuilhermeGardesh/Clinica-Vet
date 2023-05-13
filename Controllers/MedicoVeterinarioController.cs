using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    [Authorize]
    public class MedicoVeterinarioController : Controller
    {
        private readonly IMedicoVeterinarioRepository _medicoVeterinarioRepository;

        public MedicoVeterinarioController(IMedicoVeterinarioRepository medicoVeterinarioRepository)
        {
            _medicoVeterinarioRepository = medicoVeterinarioRepository;
        }
        // GET: MedicoVeterinarioController
        public ActionResult Index()
        {
            var medicosVeterinarios = _medicoVeterinarioRepository.ObterTodos();
            return View(medicosVeterinarios);
        }

        // GET: MedicoVeterinarioController/Details/5
        public ActionResult Details(int idMedico)
        {
            var medico = _medicoVeterinarioRepository.ObterPorId(idMedico);
            return View(medico);
        }

        // GET: MedicoVeterinarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicoVeterinarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicoVeterinario medico)
        {
            try
            {
                _medicoVeterinarioRepository.Inserir(medico);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoVeterinarioController/Edit/5
        public ActionResult Edit(int idMedico)
        {
            var medico = _medicoVeterinarioRepository.ObterPorId(idMedico);
            return View(medico);
        }

        // POST: MedicoVeterinarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicoVeterinario medico)
        {
            try
            {
                _medicoVeterinarioRepository.Atualizar(medico);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoVeterinarioController/Delete/5
        public ActionResult Delete(int idMedico)
        {
            var medico = _medicoVeterinarioRepository.ObterPorId(idMedico);
            return View(medico);
        }

        // POST: MedicoVeterinarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idMedico)
        {
            try
            {
                var medico = _medicoVeterinarioRepository.ObterPorId(idMedico);
                _medicoVeterinarioRepository.Deletar(medico);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
