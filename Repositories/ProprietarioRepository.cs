using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class ProprietarioRepository : GenericRepository<Proprietario>, IProprietarioRepository
    {
        //private readonly ClinicaVetDbContext _clinicaVetDbContext;
        public ProprietarioRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
            //_clinicaVetDbContext = clinicaVetDbContext;
        }
    }
}
