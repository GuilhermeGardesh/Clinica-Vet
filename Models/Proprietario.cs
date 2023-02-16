namespace ClinicaVet.GestaoVeterinaria.Models
{
    public class Proprietario : ModelBaseComplexa
    {
        public string ContatoPrincipal { get; set; }

        public string ContatoSecundario { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string CEP { get; set; }

        public string Estado { get; set; }

        public string Lagradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public List<Animal> Animais { get; set; }
    }
}
