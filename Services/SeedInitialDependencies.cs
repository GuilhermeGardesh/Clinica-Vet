using ClinicaVet.GestaoVeterinaria.Enums;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ClinicaVet.GestaoVeterinaria.Services
{
    public class SeedInitialDependencies : ISeedInitialDependencies
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPoliticaDeAcessoRepository _politicaDeAcessoRepository;

        public SeedInitialDependencies(
            UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IPoliticaDeAcessoRepository politicaDeAcessoRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _politicaDeAcessoRepository = politicaDeAcessoRepository;
        }

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await _roleManager.RoleExistsAsync("UsuarioPadrao"))
                await _roleManager.CreateAsync(new IdentityRole("UsuarioPadrao"));
        }

        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("UsuarioPadrao@localhost.com") == null)
            {
                var usuario = new IdentityUser();
                usuario.UserName = "Usuario Padrao Inicial";
                usuario.Email = "UsuarioPadrao@localhost.com";
                usuario.EmailConfirmed = true;

                var resultado = await _userManager.CreateAsync(usuario, "SenhaInicial123@");
                if (resultado.Succeeded)
                    await _userManager.AddToRoleAsync(usuario, "UsuarioPadrao");
            }

            if (await _userManager.FindByEmailAsync("Admin@localhost.com") == null)
            {
                var usuario = new IdentityUser();
                usuario.UserName = "Admin Inicial";
                usuario.Email = "Admin@localhost.com";
                usuario.EmailConfirmed = true;

                var resultado = await _userManager.CreateAsync(usuario, "SenhaInicial123@");
                if (resultado.Succeeded)
                    await _userManager.AddToRoleAsync(usuario, "Admin");
            }
        }

        public async Task SeedPoliticasDeAcessoAsync()
        {
            var politicasExistentes = _politicaDeAcessoRepository.ObterTodos();
            var politicas = new List<PoliticaDeAcesso>();
            var usuarioAdminPrincipal = await _userManager.Users.FirstAsync(user => user.Email == "Admin@localhost.com");
            var claimsDoAdminPrincipal = await _userManager.GetClaimsAsync(usuarioAdminPrincipal);
            foreach (EAreas area in Enum.GetValues(typeof(EAreas)))
                foreach (EPermissoes permissao in Enum.GetValues(typeof(EPermissoes)))
                {
                    var deveAdicionarPermissoesAoAdmin = !claimsDoAdminPrincipal.Any(claim => claim.Type == area.ToString() && claim.Value == permissao.ToString());
                    if (deveAdicionarPermissoesAoAdmin)
                        await _userManager.AddClaimAsync(usuarioAdminPrincipal, new Claim(area.ToString(), permissao.ToString(), ClaimValueTypes.String));

                    if (!politicasExistentes.Any(politica => politica.Area == area && politica.Permissao == permissao))
                        politicas.Add(new PoliticaDeAcesso(area, permissao));
                }

            if (politicas.Any())
                _politicaDeAcessoRepository.InserirVarios(politicas);
        }
    }
}
