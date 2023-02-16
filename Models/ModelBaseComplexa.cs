using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    public abstract class ModelBaseComplexa : ModelBase
    {
        [Required(ErrorMessage = "O Nome deve ser preenchido corretamente", AllowEmptyStrings = false)]
        [StringLength(35)]
        public string Nome { get; set; }
    }
}
