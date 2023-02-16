using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Data
{
    public class ClinicaVetDbContext : DbContext
    {
        public ClinicaVetDbContext(DbContextOptions<ClinicaVetDbContext> options) : base(options) { }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<MedicoVeterinario> MedicoVeterinario { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }


    }
}