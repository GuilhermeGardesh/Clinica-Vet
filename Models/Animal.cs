using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        [DisplayName("Identificador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pet é obrigatório", AllowEmptyStrings = false)]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A espécie do pet é obrigatória", AllowEmptyStrings = false)]
        [DisplayName("Espécie")]
        [StringLength(20)]
        public string Especie { get; set; }

        [DisplayName("Raça")]
        public string Raca { get; set; }

        public int Idade { get; set; }

        [DisplayName("Cadastro Ativo")]
        public bool Ativo { get; set; }
    }
}
