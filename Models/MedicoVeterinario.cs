using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    [Table("MedicoVeterinario")]
    public class MedicoVeterinario : ModelBaseComplexa
    {
        [DisplayName("Descrição")]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Número de CRMV é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Número de CRMV")]
        [StringLength(10)]
        public string NumeroDeIncricaoCRMV { get; set; }

        [Required(ErrorMessage = "Local do CRMV é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Local de CRMV")]
        [StringLength(10)]
        public string LocalDoCRMV{ get; set; }

        [Required(ErrorMessage = "CPF é obrigatório", AllowEmptyStrings = false)]
        [StringLength(11)]
        public string CPF{ get; set; }
    }
}
