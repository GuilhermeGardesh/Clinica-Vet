using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.ViewModels
{
    public class FinalizarAtendimentoViewModel
    {
        public int IdAtendimento { get; set; }

        [DisplayName("Observações pós atendimento")]
        [StringLength(400)]
        [Required(ErrorMessage = "As observações para o pós atendimento são obrigatórias.", AllowEmptyStrings = false)]
        public string ObservacoesFinais { get; set; }

        [DisplayName("Diagnóstico")]
        [StringLength(300)]
        [Required(ErrorMessage = "Um resumo de diagnóstico é obrigatório.", AllowEmptyStrings = false)]
        public string Diagnostico { get; set; }

        [DisplayName("Nome do Veterinário")]
        public string NomeMedicoVeterinario { get; set; }

        [DisplayName("Nome do Animal")]
        public string NomeAnimal { get; set; }

    }
}
