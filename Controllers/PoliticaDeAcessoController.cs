using ClinicaVet.GestaoVeterinaria.Enums;
using ClinicaVet.GestaoVeterinaria.Extensions;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    [ClaimsControllerAuthorize("PoliticaDeAcesso")]
    public class PoliticaDeAcessoController : Controller
    {
        private readonly IPoliticaDeAcessoRepository _politicaDeAcessoRepository;
        private readonly IPoliticaDeAcessoService _politicaDeAcessoService;

        public PoliticaDeAcessoController(
            IPoliticaDeAcessoRepository politicaDeAcessoRepository,
            IPoliticaDeAcessoService politicaDeAcessoService)
        {
            _politicaDeAcessoRepository = politicaDeAcessoRepository;
            _politicaDeAcessoService = politicaDeAcessoService;
        }

        //TODO: REPENSAR COMO ESTÁ PARA GERENCIAR GRUPOS DE PERMISSÕES E NÃO PERMISSÕES INDIVIDUAIS
        //INICIO
        // GET: PoliticaDeAcessoController
        //public ActionResult Index()
        //{
        //    var politicas = _politicaDeAcessoRepository.ObterTodos();
        //    return View(politicas);
        //}

        //// GET: PoliticaDeAcessoController/Details/5
        //public ActionResult Details(int idpolitica)
        //{
        //    var politica = _politicaDeAcessoRepository.ObterPorId(idpolitica);
        //    return View(politica);
        //}

        //// GET: PoliticaDeAcessoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PoliticaDeAcessoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(int area, int Permissao)
        //{
        //    var politica = new PoliticaDeAcesso((EAreas)area, (EPermissoes)Permissao);
        //    try
        //    {
        //        _politicaDeAcessoRepository.Inserir(politica);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(politica);
        //    }
        //}

        //// GET: PoliticaDeAcessoController/Edit/5
        //public ActionResult Edit(int idPolitica)
        //{
        //    var politica = _politicaDeAcessoRepository.ObterPorId(idPolitica);
        //    return View(politica);
        //}

        //// POST: PoliticaDeAcessoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(PoliticaDeAcesso politica)
        //{
        //    try
        //    {
        //        _politicaDeAcessoRepository.Atualizar(politica);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(politica);
        //    }
        //}

        //// GET: PoliticaDeAcessoController/Delete/5
        //public ActionResult Delete(int idPolitica)
        //{
        //    var politica = _politicaDeAcessoRepository.ObterPorId(idPolitica);
        //    return View(politica);
        //}

        //// POST: PoliticaDeAcessoController/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int idPolitica)
        //{
        //    var politica = _politicaDeAcessoRepository.ObterPorId(idPolitica);
        //    try
        //    {
        //        _politicaDeAcessoRepository.Deletar(politica);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(politica);
        //    }
        //}
        //FIM

        [ClaimsAuthorize("PoliticaDeAcesso", "SINC")]
        [HttpPost]
        public ActionResult SincronizarPoliticasDeAcesso()
        {
            var politicasExistentes = _politicaDeAcessoRepository.ObterTodos();
            var politicas = new List<PoliticaDeAcesso>();
            foreach (EAreas area in Enum.GetValues(typeof(EAreas)))
                foreach (EPermissoes permissao in Enum.GetValues(typeof(EPermissoes)))
                {
                    if (!politicasExistentes.Any(politica => politica.Area == area && politica.Permissao == permissao))
                        politicas.Add(new PoliticaDeAcesso(area, permissao));
                }

            if (politicas.Any())
                _politicaDeAcessoRepository.InserirVarios(politicas);

            return RedirectToAction("index", "Permissao");
        }
    }
}
