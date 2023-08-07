using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class PermissaoRepository : GenericRepository<IdentityUserClaim<string>>, IPermissaoRepository
    {
        public PermissaoRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
        }

        public List<IdentityUserClaim<string>> ObterDistintosPorTipoEVAlor()
        {
            var claims = ObterTodos().ToList();
            return claims.DistinctBy(x => new { x.ClaimType, x.ClaimValue }).ToList();
        }

        public List<IdentityUserClaim<string>> ObterTodosPorTipoEValor(string Tipo, string Valor)
        {
            return ObterTodos().Where(c => c.ClaimType == Tipo && c.ClaimValue == Valor).ToList();
        }

        public List<IdentityUserClaim<string>> ObterTodosPorUsuario(string userId)
        {
            return ObterTodos().Where(c => c.UserId == userId).ToList();
        }
    }
}
