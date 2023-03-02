using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoService _atendimentoService;
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMedicoVeterinarioRepository _medicoVeterinarioRepository;

        public AtendimentoController(
            IAtendimentoService atendimentoService,
            IAtendimentoRepository atendimentoRepository,
            IAnimalRepository animalRepository,
            IMedicoVeterinarioRepository medicoVeterinarioRepository)
        {
            _atendimentoService = atendimentoService;
            _atendimentoRepository = atendimentoRepository;
            _animalRepository = animalRepository;
            _medicoVeterinarioRepository = medicoVeterinarioRepository;
        }

        // GET: AtendimentoController
        public ActionResult Index()
        {
            var atendimentos = _atendimentoRepository.ObterAtendimentosDetalhes();
            return View(atendimentos);
        }

        // GET: AtendimentoController/Details/5
        public ActionResult Details(int idAtendimento)
        {
            if (!_atendimentoService.IdAtendimentoValido(idAtendimento))
                return RedirectToAction(nameof(Index));
            var atendimento = _atendimentoRepository.ObterPorId(idAtendimento);
            return View(atendimento);
        }

        // GET: AtendimentoController/IniciarAtendimento
        public ActionResult IniciarAtendimento()
        {
            ViewBag.medicosParaAtendimento = new SelectList(_medicoVeterinarioRepository.ObterTodos(), "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_animalRepository.ObterAnimaisAtivosProprietarios(), "Id", "Nome" + "-" + "Proprietario.Nome");
            return View();
        }

        // POST: AtendimentoController/IniciarAtendimento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IniciarAtendimento(Atendimento atendimento)
        {
            ViewBag.medicosParaAtendimento = new SelectList(_medicoVeterinarioRepository.ObterTodos(), "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_animalRepository.ObterTodos(), "Id", "Nome");
            if (!_atendimentoService.AtendimentoIniciadoValido(atendimento))
            {
                return View(atendimento);
            }
            try
            {
                atendimento.IniciarAtendimento();
                _atendimentoRepository.Inserir(atendimento);
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
            var atendimento = _atendimentoRepository.ObterAtendimentoDetalhesPorId(idAtendimento);

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

            var atendimento = _atendimentoRepository.ObterPorId(atendimentoViewModel.IdAtendimento);
            try
            {
                _atendimentoService.FinalizarAtendimento(atendimento, atendimentoViewModel.Diagnostico, atendimentoViewModel.ObservacoesFinais);
                _atendimentoRepository.Atualizar(atendimento);
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
            ViewBag.medicosParaAtendimento = new SelectList(_medicoVeterinarioRepository.ObterTodos(), "Id", "Nome");
            ViewBag.animaisParaAtendimento = new SelectList(_animalRepository.ObterTodos(), "Id", "Nome");
            if (!_atendimentoService.IdAtendimentoValido(idAtendimento))
                return RedirectToAction(nameof(Index));
            var atendimento = _atendimentoRepository.ObterPorId(idAtendimento);
            return View(atendimento);
        }

        // POST: AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Atendimento atendimento)
        {
            try
            {
                _atendimentoRepository.Atualizar(atendimento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.medicosParaAtendimento = new SelectList(_medicoVeterinarioRepository.ObterTodos(), "Id", "Nome");
                ViewBag.animaisParaAtendimento = new SelectList(_animalRepository.ObterTodos(), "Id", "Nome");
                return View();
            }
        }

        // GET: AtendimentoController/Delete/5
        public ActionResult Delete(int idAtendimento)
        {
            var atendimento = _atendimentoRepository.ObterPorId(idAtendimento);
            return View(atendimento);
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAtendimento)
        {
            try
            {
                var atendimento = _atendimentoRepository.ObterPorId(idAtendimento);
                _atendimentoRepository.Deletar(atendimento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
