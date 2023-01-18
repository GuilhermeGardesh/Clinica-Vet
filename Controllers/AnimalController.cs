using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class AnimalController : Controller
    {
        public readonly ClinicaVetDbContext _db;

        public AnimalController()
        {
            _db = new ClinicaVetDbContext();
        }

        // GET: AnimalController
        public ActionResult Index()
        {
            var animais = _db.Animal.ToList();
            return View(animais);
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int idAnimal)
        {
            var animal = _db.Animal.Where(animal => animal.Id == idAnimal).FirstOrDefault();
            return View(animal);
        }

        // GET: AnimalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Animal animal)
        {
            try
            {
                _db.Animal.Add(animal);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimalController/Edit/5
        public ActionResult Edit(int idAnimal)
        {
            var animal = _db.Animal.Where(animal => animal.Id == idAnimal).First();
            return View(animal);
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Animal animal)
        {
            try
            {
                _db.Entry(animal).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimalController/Delete/5
        public ActionResult Delete(int idAnimal)
        {
            var animal = _db.Animal.Where(animal => animal.Id == idAnimal).FirstOrDefault();
            return View(animal);
        }

        // POST: AnimalController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAnimal)
        {
            try
            {
                var animal = _db.Animal.Find(idAnimal);
                _db.Animal.Remove(animal);
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
