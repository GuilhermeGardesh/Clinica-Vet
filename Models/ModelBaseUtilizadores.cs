using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    public abstract class ModelBaseUtilizadores
    {
        [Key]
        [DisplayName("Identificador")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome deve ser preenchido corretamente", AllowEmptyStrings = false)]
        [StringLength(35)]
        public string Nome { get; set; }
    }
}
