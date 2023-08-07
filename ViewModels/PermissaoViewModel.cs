using ClinicaVet.GestaoVeterinaria.Dtos;

namespace ClinicaVet.GestaoVeterinaria.ViewModels
{
    public class PermissaoViewModel
    {
        public UsuarioDetalhesViewModel User { get; set; }
        public List<ClaimDTO> Claims { get; set; }
    }
}
