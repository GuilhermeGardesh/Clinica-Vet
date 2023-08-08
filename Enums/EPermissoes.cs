using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.Enums
{
    public enum EPermissoes
    {
        /// <summary>
        /// Criar
        /// </summary>
        [Display(Name = "Criar")]
        [Description("Criar")]
        C,

        /// <summary>
        /// Ler
        /// </summary>
        [Display(Name = "Ler")]
        [Description("Ler")]
        L,

        /// <summary>
        /// Atualizar
        /// </summary>
        [Display(Name = "Atualizar")]
        [Description("Atualizar")]
        A,

        /// <summary>
        /// Editar
        /// </summary>
        [Display(Name = "Editar")]
        [Description("Editar")]
        ED,

        /// <summary>
        /// Excluir
        /// </summary>
        [Display(Name = "Excluir")]
        [Description("Excluir")]
        EX,

        /// <summary>
        /// Sincronizar Administração
        /// </summary>
        [Display(Name = "Sincronizar")]
        [Description("Sincronizar")]
        SINC,

        /// <summary>
        /// Iniciar Atendimento
        /// </summary>
        [Display(Name = "Iniciar Atendimento")]
        [Description("Iniciar Atendimento")]
        IA,

        /// <summary>
        /// Finalizar Atendimento
        /// </summary>
        [Display(Name = "Finalizar Atendimento")]
        [Description("Finalizar Atendimento")]
        FA
    }
}
