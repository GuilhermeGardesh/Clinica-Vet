using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class AtendimentoRepository : GenericRepository<Atendimento>, IAtendimentoRepository
    {
        private readonly ClinicaVetDbContext _clinicaVetDbContext;
        public AtendimentoRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
            _clinicaVetDbContext = clinicaVetDbContext;
        }

        public IQueryable<Atendimento> ObterAtendimentosDetalhes()
        {
            return _clinicaVetDbContext.Atendimento
                    .Include(atendimento => atendimento.Animal)
                    .Include(atendimento => atendimento.MedicoVeterinario);
        }

        public IQueryable<Atendimento> ObterAtendimentoDetalhesPorId(int idAtendimento)
        {
            return _clinicaVetDbContext.Atendimento
                .AsQueryable()
                .Include(atendimento => atendimento.Animal)
                .Include(atendimento => atendimento.MedicoVeterinario)
                .Where(atendimento => atendimento.Id == idAtendimento);
        }
    }
}
