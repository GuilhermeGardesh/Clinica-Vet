using Microsoft.AspNetCore.Identity;

namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IPermissaoRepository : IGenericRepository<IdentityUserClaim<string>>
    {
        List<IdentityUserClaim<string>> ObterDistintosPorTipoEVAlor();

        List<IdentityUserClaim<string>> ObterTodosPorTipoEValor(string Tipo, string Valor);

        List<IdentityUserClaim<string>> ObterTodosPorUsuario(string userId);
    }
}
