using ClinicaVet.GestaoVeterinaria.ViewModels;
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
        public int Id { get; set; }

        [DisplayName("Diagnóstico")]
        [StringLength(300)]
        public string Diagnostico { get; set; }

        [DisplayName("Observações de entrada")]
        [StringLength(300)]
        [Required(ErrorMessage = "Obrigatório informar motivo da vinda do Pet.", AllowEmptyStrings = false)]
        public string? ObservacoesIniciais { get; set; }

        [DisplayName("Observações pós atendimento")]
        [StringLength(400)]
        public string? ObservacoesFinais { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        [DisplayName("Início do Atendimento")]
        public DateTime AtendimentoIniciado { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm:ss")]
        [DisplayName("Fim do Atendimento")]
        public DateTime? AtendimentoFinalizado { get; set; }

        public bool Finalizado { get; set; }

        //ForeignKey de Animal
        [DisplayName("Pet")]
        [ForeignKey("Animal")]
        [Required(ErrorMessage = "Deve haver um animal cadastrado para o Atendimento.", AllowEmptyStrings = false)]
        public int IdAnimal { get; set; }
        public Animal Animal { get; set; }

        //ForeignKey de Médico
        [DisplayName("Médico")]
        [ForeignKey("MedicoVeterinario")]
        [Required(ErrorMessage = "Deve haver um Médico Veterinário cadastrado para o Atendimento.", AllowEmptyStrings = false)]
        public int IdMedicoVeterinario { get; set; }
        public MedicoVeterinario MedicoVeterinario { get; set; }

        public void IniciarAtendimento()
        {
            AtendimentoIniciado = DateTime.Now;
            Finalizado = false;
        }

        public void FinalizarAtendimento(FinalizarAtendimentoViewModel finalizarAtendimentoViewModel)
        {
            AtendimentoFinalizado = DateTime.Now;
            Finalizado = true;
            ObservacoesFinais = finalizarAtendimentoViewModel.ObservacoesFinais;
            Diagnostico = finalizarAtendimentoViewModel.Diagnostico;
        }
    }
}
