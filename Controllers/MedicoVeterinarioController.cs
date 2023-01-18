using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class MedicoVeterinarioController : Controller
    {
        public readonly Db _db;

        public MedicoVeterinarioController()
        {
            _db = new Db();
        }
        // GET: MedicoVeterinarioController
        public ActionResult Index()
        {
            var medicosVeterinarios = _db.MedicoVeterinario.ToList();
            return View(medicosVeterinarios);
        }

        // GET: MedicoVeterinarioController/Details/5
        public ActionResult Details(int idMedico)
        {
            var medico = _db.MedicoVeterinario.Find(idMedico);
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
                _db.MedicoVeterinario.Add(medico);
                _db.SaveChanges();
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
            var medico = _db.MedicoVeterinario.Find(idMedico);
            return View(medico);
        }

        // POST: MedicoVeterinarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicoVeterinario medico)
        {
            try
            {
                _db.Entry(medico).State = EntityState.Modified;
                _db.SaveChanges();
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
            var medico = _db.MedicoVeterinario.Find(idMedico);
            return View(medico);
        }

        // POST: MedicoVeterinarioController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idMedico)
        {
            try
            {
                var medico = _db.MedicoVeterinario.Find(idMedico);
                _db.MedicoVeterinario.Remove(medico);
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
