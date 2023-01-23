using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly ClinicaVetDbContext _db;

        public AtendimentoController()
        {
            _db = new ClinicaVetDbContext();
        }
        // GET: AtendimentoController
        public ActionResult Index()
        {
            var atendimentos = _db.Atendimento.ToList();
            return View(atendimentos);
        }

        // GET: AtendimentoController/Details/5
        public ActionResult Details(int idAtendimento)
        {
            var atendimento = _db.Atendimento.Find(idAtendimento);
            return View(atendimento);
        }

        // GET: AtendimentoController/Create
        public ActionResult IniciarAtendimento()
        {
            ViewBag.medicosParaAtendimento = new SelectList(_db.MedicoVeterinario, "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_db.Animal, "Id", "Nome");
            return View();
        }

        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarAtendimento(Atendimento atendimento)
        {
            try
            {
                _db.Atendimento.Add(atendimento);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AtendimentoController/Edit/5
        public ActionResult Edit(int idAtendimento)
        {
            var atendimento = _db.Atendimento.Find(idAtendimento);
            return View(atendimento);
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atendimento atendimento)
        {
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
        [HttpPost]
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
