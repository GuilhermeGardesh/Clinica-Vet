using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        IQueryable<Animal> ObterAnimaisProprietarios();
    }
}
