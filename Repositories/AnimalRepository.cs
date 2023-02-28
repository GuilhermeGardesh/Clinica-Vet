using ClinicaVet.GestaoVeterinaria.Data;
using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Repositories
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private DbSet<Animal> _db;
        public AnimalRepository(ClinicaVetDbContext clinicaVetDbContext) : base(clinicaVetDbContext)
        {
            _db = clinicaVetDbContext.Set<Animal>();
        }

        public IQueryable<Animal> ObterAnimaisProprietarios()
            => _db.Include(animal => animal.Proprietario);

    }
}
