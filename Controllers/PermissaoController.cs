using ClinicaVet.GestaoVeterinaria.Dtos;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ClinicaVet.GestaoVeterinaria.Controllers
{
    public class PermissaoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPermissaoRepository _userClaimRepository;
        private readonly IPoliticaDeAcessoRepository _politicaDeAcessoRepository;

        public PermissaoController(
            UserManager<IdentityUser> userManager
            ,RoleManager<IdentityRole> roleManager
            , IPermissaoRepository userClaimRepository
            , IPoliticaDeAcessoRepository politicaDeAcessoRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaimRepository = userClaimRepository;
            _politicaDeAcessoRepository = politicaDeAcessoRepository;
        }

        public IActionResult Index()
        {
            var usuarios = _userManager.Users.ToList();
            return View(usuarios);
        }

        public ViewResult Details(string idUsuario)
        {
            var politicasDoUsuario = _userClaimRepository.ObterTodosPorUsuario(idUsuario)
                .Select(x => new ClaimDTO()
                {
                    Type = x.ClaimType,
                    Value = x.ClaimValue
                }).ToList();
            var usuarioIdentidy = _userManager.FindByIdAsync(idUsuario).Result;
            var usuario = new UsuarioDetalhesViewModel()
            {
                IdUsuario = idUsuario,
                NomeUsuario = usuarioIdentidy.UserName,
                Email = usuarioIdentidy.Email
            };
            var userClaims = new PermissaoViewModel()
            {
                User = usuario,
                Claims = politicasDoUsuario
            };

            return View(userClaims);
        }

        public ViewResult Create(string idUsuario)
        {
            ViewBag.politicas = new SelectList(_politicaDeAcessoRepository.ObterPoliticasParaSelectList(), "Id", "AreaPermissao");
            var usuario = _userManager.FindByIdAsync(idUsuario).Result;
            var usuarioViewModel = new UsuarioDetalhesViewModel() { IdUsuario = usuario.Id, NomeUsuario = usuario.UserName, Email = usuario.Email };
            ViewBag.usuario = usuarioViewModel;
            var UserClaimViewModel = new UsuarioPoliticaViewModel() { IdUser = usuario.Id };
            return View(UserClaimViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioPoliticaViewModel UserClaimViewModel)
        {
            var politicaDeAcesso = _politicaDeAcessoRepository.ObterPorId(UserClaimViewModel.IdPoliticaDeAcesso);
            var user = await _userManager.FindByIdAsync(UserClaimViewModel.IdUser);

            Claim claim = new Claim(politicaDeAcesso.Area.ToString(), politicaDeAcesso.Permissao.ToString(), ClaimValueTypes.String);
            IdentityResult result = await _userManager.AddClaimAsync(user, claim);

            if (result.Succeeded)
                return RedirectToAction("Details", new { @idUsuario = UserClaimViewModel.IdUser });

            var usuario = _userManager.FindByIdAsync(UserClaimViewModel.IdUser).Result;
            var usuarioViewModel = new UsuarioDetalhesViewModel() { IdUsuario = usuario.Id, NomeUsuario = usuario.UserName, Email = usuario.Email };
            ViewBag.usuario = usuarioViewModel;
            ViewBag.politicas = new SelectList(_politicaDeAcessoRepository.ObterPoliticasParaSelectList(), "Id", "AreaPermissao");
            return View(UserClaimViewModel);
        }

        [HttpPost]
        public ActionResult Delete(string idUsuario, string area, string permissoes)
        {
            var user = _userManager.FindByIdAsync(idUsuario).Result;
            var claim = new Claim(area, permissoes);

            var resultado = _userManager.RemoveClaimAsync(user, claim).Result;

            if (resultado.Succeeded)
                return RedirectToAction("Details", new { @idUsuario = idUsuario });

            return RedirectToAction("Details", new { @idUsuario = idUsuario });
        }

        [HttpPost]
        public ActionResult SincronizarPermissoesAdministrativas()
        {
            const string ADMINISTRADOR = "Admin";
            var UsuariosAdmnistradores = _userManager.GetUsersInRoleAsync(ADMINISTRADOR).Result.ToList();
            if (!UsuariosAdmnistradores.Any())
                return RedirectToAction("index", "Home");

            var PoliticasDeAcesso = _politicaDeAcessoRepository.ObterTodos().ToList();

            foreach (var usuario in UsuariosAdmnistradores)
            {
                var userClaims = _userClaimRepository.ObterTodosPorUsuario(usuario.Id).ToList();

                foreach (var politicaDeAcesso in PoliticasDeAcesso)
                {
                    if (userClaims.Any(x => x.ClaimType == politicaDeAcesso.Area.ToString() && x.ClaimValue == politicaDeAcesso.Permissao.ToString()))
                        continue;

                    Claim claim = new Claim(politicaDeAcesso.Area.ToString(), politicaDeAcesso.Permissao.ToString(), ClaimValueTypes.String);
                    _userManager.AddClaimAsync(usuario, claim);
                }
            }

            return RedirectToAction("index");
        }
    }
}
