using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IAtendimentoRepository : IGenericRepository<Atendimento>
    {
        IQueryable<Atendimento> ObterAtendimentosDetalhes();

        IQueryable<Atendimento> ObterAtendimentoDetalhesPorId(int id);
    }
}
