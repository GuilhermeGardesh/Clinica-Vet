using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class MedicoVeterinarioRepository : GenericRepository<MedicoVeterinario>, IMedicoVeterinarioRepository
    {
        public MedicoVeterinarioRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
        }
    }
}
