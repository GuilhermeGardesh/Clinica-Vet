using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        // GET: AnimalController
        public ActionResult Index()
        {
            var animais = _animalRepository.ObterTodos();
            return View(animais);
        }

        // GET: AnimalController/Details/5
        public ActionResult Details(int idAnimal)
        {
            var animal = _animalRepository.ObterPorId(idAnimal);
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
                _animalRepository.Inserir(animal);
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
            var animal = _animalRepository.ObterPorId(idAnimal);
            return View(animal);
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Animal animal)
        {
            try
            {
                _animalRepository.Atualizar(animal);
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
            var animal = _animalRepository.ObterPorId(idAnimal);
            return View(animal);
        }

        // POST: AnimalController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAnimal)
        {
            try
            {
                var animal = _animalRepository.ObterPorId(idAnimal);
                _animalRepository.Deletar(animal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
