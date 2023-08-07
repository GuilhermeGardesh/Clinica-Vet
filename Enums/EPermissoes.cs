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
        /// Excluir
        /// </summary>
        [Display(Name = "Excluir")]
        [Description("Excluir")]
        E,

        /// <summary>
        /// Sincronizar Administração
        /// </summary>
        [Display(Name = "Sincronizar")]
        [Description("Sincronizar")]
        SINC
    }
}
