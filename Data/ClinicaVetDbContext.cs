using ClinicaVet.GestaoVeterinaria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.GestaoVeterinaria.Data
{
    public class ClinicaVetDbContext : IdentityDbContext
    {
        public ClinicaVetDbContext(DbContextOptions<ClinicaVetDbContext> options) : base(options) { }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<MedicoVeterinario> MedicoVeterinario { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
    }
}