using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    [Table("Atendimento")]
    public class Atendimento
    {
        [Key]
        [DisplayName("Identificador")]
        public int id { get; set; }

        [DisplayName("Diagnóstico")]
        [StringLength(300)]
        public string Diagnostico { get; set; }

        [DisplayName("Observações")]
        [StringLength(300)]
        public string Observacoes { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy HH:mm:ss")]
        [DisplayName("Início do Atendimento")]
        public DateTime AtendimentoIniciado { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy HH:mm:ss")]
        [DisplayName("Fim do Atendimento")]
        public DateTime AtendimentoFinalizado { get; set; }

        public bool Finalizado { get; set; }

        //ForeignKey de Animal
        [DisplayName("Pet")]
        [ForeignKey("Animal")]
        [Required(ErrorMessage = "Em um atendimento deve haver um animal cadastrado.", AllowEmptyStrings = false)]
        public int IdAnimal { get; set; }
        public Animal Animal { get; set; }

        //ForeignKey de Médico
        [DisplayName("Médico")]
        [ForeignKey("MedicoVeterinario")]
        [Required(ErrorMessage = "Em um atendimento deve haver um Médico Veterinário cadastrado.", AllowEmptyStrings = false)]
        public int IdMedicoVeterinario { get; set; }
        public MedicoVeterinario MedicoVeterinario { get; set; }
    }
}
