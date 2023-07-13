using Microsoft.AspNetCore.Identity;

namespace ClinicaVet.GestaoVeterinaria.Models.Roles
{
    public class RoleEditDTO
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Members { get; set; }
        public IEnumerable<IdentityUser> NonMembers { get; set; }
    }
}
