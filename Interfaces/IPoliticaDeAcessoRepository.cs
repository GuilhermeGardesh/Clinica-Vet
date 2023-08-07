using ClinicaVet.GestaoVeterinaria.Dtos;
using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IPoliticaDeAcessoRepository : IGenericRepository<PoliticaDeAcesso>
    {
        IQueryable<PoliticaDeAcessoDTO> ObterPoliticasParaSelectList();
    }
}
