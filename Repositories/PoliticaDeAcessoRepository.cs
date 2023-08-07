using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Dtos;
using ClinicaVet.GestaoVeterinaria.Extensions;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class PoliticaDeAcessoRepository : GenericRepository<PoliticaDeAcesso>, IPoliticaDeAcessoRepository
    {
        private DbSet<PoliticaDeAcesso> _db;

        public PoliticaDeAcessoRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
            _db = clinicaVetDbContext.Set<PoliticaDeAcesso>();
        }

        public IQueryable<PoliticaDeAcessoDTO> ObterPoliticasParaSelectList()
        {
            return ObterTodos().Select(x => new PoliticaDeAcessoDTO { Id = x.Id, AreaPermissao = x.Area.GetDescription() + " - " + x.Permissao.GetDescription()});
        }

    }
}
