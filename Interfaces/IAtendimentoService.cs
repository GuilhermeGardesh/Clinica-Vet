using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.ViewModels;

namespace ClinicaVet.GestaoVeterinaria.Interfaces
{
    public interface IAtendimentoService
    {
        bool AtendimentoIniciadoValido(Atendimento atendimento);
        bool AtendimentoFinalizadoValido(FinalizarAtendimentoViewModel finalizarAtendimentoViewModel);
        void FinalizarAtendimento(Atendimento atendimento, FinalizarAtendimentoViewModel finalizarAtendimentoViewModel);
        bool IdAtendimentoValido(int idAtendimento);

    }
}
