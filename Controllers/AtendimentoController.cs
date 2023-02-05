using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly ClinicaVetDbContext _db;
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _db = new ClinicaVetDbContext();
            _atendimentoService = atendimentoService;
        }

        // GET: AtendimentoController
        public ActionResult Index()
        {
            var atendimentos = _db.Atendimento
                                .Include(atendimento => atendimento.Animal)
                                .Include(atendimento => atendimento.MedicoVeterinario)
                                .ToList();
            return View(atendimentos);
        }

        // GET: AtendimentoController/Details/5
        public ActionResult Details(int idAtendimento)
        {
            if (!_atendimentoService.IdAtendimentoValido(idAtendimento))
                return RedirectToAction(nameof(Index));
            var atendimento = _db.Atendimento.Find(idAtendimento);
            return View(atendimento);
        }

        // GET: AtendimentoController/IniciarAtendimento
        public ActionResult IniciarAtendimento()
        {
            ViewBag.medicosParaAtendimento = new SelectList(_db.MedicoVeterinario, "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_db.Animal, "Id", "Nome");
            return View();
        }

        // POST: AtendimentoController/IniciarAtendimento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarAtendimento(Atendimento atendimento)
        {
            ViewBag.medicosParaAtendimento = new SelectList(_db.MedicoVeterinario, "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_db.Animal, "Id", "Nome");
            if (!_atendimentoService.AtendimentoIniciadoValido(atendimento))
            {
                return View(atendimento);
            }
            try
            {
                atendimento.IniciarAtendimento();
                _db.Atendimento.Add(atendimento);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(atendimento);
            }
        }

        // GET: AtendimentoController/FinalizarAtendimento
        public ActionResult FinalizarAtendimento(int idAtendimento)
        {
            if (!_atendimentoService.IdAtendimentoValido(idAtendimento))
                return RedirectToAction(nameof(Index));
            var atendimento = _db.Atendimento
                .Where(atendimento => atendimento.Id == idAtendimento)
                .Include(atendimento => atendimento.Animal)
                .Include(atendimento => atendimento.MedicoVeterinario);

            var atendimentoVielModel = atendimento.Select(atendimento => new FinalizarAtendimentoViewModel
            {
                IdAtendimento = atendimento.Id,
                NomeAnimal = atendimento.Animal.Nome,
                NomeMedicoVeterinario = atendimento.MedicoVeterinario.Nome
            }).First();
            return View(atendimentoVielModel);
        }

        // POST: AtendimentoController/FinalizarAtendimento
        [HttpPost, ActionName("FinalizarAtendimento")]
        [ValidateAntiForgeryToken]
        public ActionResult FinalizarAtendimentoConfirmed(FinalizarAtendimentoViewModel atendimentoViewModel)
        {
            if (!_atendimentoService.IdAtendimentoValido(atendimentoViewModel.IdAtendimento) || !_atendimentoService.AtendimentoFinalizadoValido(atendimentoViewModel))
                return View(atendimentoViewModel.IdAtendimento);

            var atendimento = _db.Atendimento.Find(atendimentoViewModel.IdAtendimento);
            try
            {
                _atendimentoService.FinalizarAtendimento(atendimento, atendimentoViewModel.Diagnostico, atendimentoViewModel.ObservacoesFinais);
                _db.Entry(atendimento).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(atendimentoViewModel.IdAtendimento);
            }
        }

        // GET: AtendimentoController/Edit/5
        public ActionResult Edit(int idAtendimento)
        {
            ViewBag.medicosParaAtendimento = new SelectList(_db.MedicoVeterinario, "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_db.Animal, "Id", "Nome");
            if (!_atendimentoService.IdAtendimentoValido(idAtendimento))
                return RedirectToAction(nameof(Index));
            var atendimento = _db.Atendimento.Find(idAtendimento);
            return View(atendimento);
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atendimento atendimento)
        {
            ViewBag.medicosParaAtendimento = new SelectList(_db.MedicoVeterinario, "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_db.Animal, "Id", "Nome");
            try
            {
                _db.Entry(atendimento).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtendimentoController/Delete/5
        public ActionResult Delete(int idAtendimento)
        {
            var atendimento = _db.Atendimento.Find(idAtendimento);
            return View(atendimento);
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAtendimento)
        {
            try
            {
                var atendimento = _db.Atendimento.Find(idAtendimento);
                _db.Atendimento.Remove(atendimento);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
