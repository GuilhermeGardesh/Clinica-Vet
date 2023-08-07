using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ClinicaVet.GestaoVeterinaria.Enums;

namespace ClinicaVet.GestaoVeterinaria.Models
{
    public class PoliticaDeAcesso : ModelBase
    {
        public PoliticaDeAcesso(EAreas area, EPermissoes permissao)
        {
            Area = area;
            Permissao = permissao;
        }

        [Required(ErrorMessage = "Área é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Área")]
        public EAreas Area { get; private set; }

        [Required(ErrorMessage = "As permissões são obrigatórias", AllowEmptyStrings = false)]
        [DisplayName("Permissao")]
        public EPermissoes Permissao { get; private set; }
    }
}