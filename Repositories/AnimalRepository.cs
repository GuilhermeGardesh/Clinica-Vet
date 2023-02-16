using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
        }
    }
}
