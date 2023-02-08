using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    public abstract class ModelBaseProcessos
    {
        [Key]
        [DisplayName("Identificador")]
        public int Id { get; set; }
    }
}
