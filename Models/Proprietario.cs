using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    [Table("Proprietario")]
    public class Proprietario : ModelBaseComplexa
    {
        [Required(ErrorMessage = "A espécie do pet é obrigatória", AllowEmptyStrings = false)]
        [DisplayName("Contato Principal")]
        public string ContatoPrincipal { get; set; }

        [DisplayName("Contato Secundário")]
        public string ContatoSecundario { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório", AllowEmptyStrings = false)]
        [StringLength(14, ErrorMessage = "Cpf não pode conter menos de 11 digitos e não mais que 14", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório", AllowEmptyStrings = false)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CEP é um campo obrigatório", AllowEmptyStrings = false)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Estado é um campo obrigatório", AllowEmptyStrings = false)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Lagradouro é um campo obrigatório", AllowEmptyStrings = false)]
        public string Lagradouro { get; set; }

        [Required(ErrorMessage = "Número é um campo obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Número")]
        public string Numero { get; set; }
        
        public string Complemento { get; set; }

        public List<Animal> Animais { get; set; }
    }
}
