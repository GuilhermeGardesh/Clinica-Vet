using System.Data.Entity;
using ClinicaVet.GestaoVeterinaria.Models;

namespace ClinicaVet.GestaoVeterinaria.Data
{
    public class ClinicaVetDbContext : DbContext
    {
        public ClinicaVetDbContext() : base("Server=localhost,1433;Database=ClinicaVet;User ID=sa;Password=1q2w3e4r@#$;") { }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<MedicoVeterinario> MedicoVeterinario { get; set; }
    }
}