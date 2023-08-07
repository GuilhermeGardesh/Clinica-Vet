using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClinicaVet.GestaoVeterinaria.Enums
{
    public enum EAreas
    {
        [Display(Name = "Animal")]
        [Description("Animal")]
        Animal,

        [Display(Name = "Atendimento")]
        [Description("Atendimento")]
        Atendimento,

        [Display(Name = "Médico")]
        [Description("Médico")]
        Medico,

        [Display(Name = "Política de Acesso")]
        [Description("Política de Acesso")]
        PoliticaDeAcesso,

        [Display(Name = "Proprietário")]
        [Description("Proprietário")]
        Proprietario,

        [Display(Name = "Permissão")]
        [Description("Permissão")]
        Permissao,

        [Display(Name = "Gerenciar Usuário")]
        [Description("Gerenciar Usuário")]
        GerenciarUsuarios
    }
}
