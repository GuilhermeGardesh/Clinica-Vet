using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    [Table("Animal")]
    public class Animal : ModelBaseComplexa
    {
        [Required(ErrorMessage = "A espécie do pet é obrigatória", AllowEmptyStrings = false)]
        [DisplayName("Espécie")]
        [StringLength(20)]
        public string Especie { get; set; }

        [DisplayName("Raça")]
        public string Raca { get; set; }

        public int Idade { get; set; }

        [DisplayName("Cadastro Ativo")]
        public bool Ativo { get; set; }

        public int ProprietarioId { get; set; }

        //Propriedade de navegação
        public Proprietario Proprietario { get; set; }
    }
}
