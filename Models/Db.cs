using System.Data.Entity;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    public class Db : DbContext
    {
        public Db() : base("Server=localhost,1433;Database=ClinicaVet;User ID=sa;Password=1q2w3e4r@#$;") { }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<MedicoVeterinario> MedicoVeterinario { get; set; }
    }
}
