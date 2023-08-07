using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.ViewModels
{
    public class UsuarioPoliticaViewModel
    {
        public string IdUser { get; set;}

        [DisplayName("Área")]
        public int IdPoliticaDeAcesso { get; set; }
    }
}
