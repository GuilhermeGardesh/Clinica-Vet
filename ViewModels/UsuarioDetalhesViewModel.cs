using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.ViewModels
{
    public class UsuarioDetalhesViewModel
    {
        public string IdUsuario { get; set; }

        [DisplayName("Nome do Usuário")]
        public string NomeUsuario { get; set; }
        
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}
