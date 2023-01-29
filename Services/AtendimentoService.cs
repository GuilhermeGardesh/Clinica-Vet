using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace ClinicaVet.GestaoVeterinaria.Services
{
    public class AtendimentoService
    {
        public AtendimentoService() { }

        public bool AtendimentoIniciadoValido(Atendimento atendimento)
        {
            if (atendimento.IdAnimal == null || atendimento.IdMedicoVeterinario == null)
                return false;
            if (atendimento.IdAnimal == 0 || atendimento.IdMedicoVeterinario == 0)
                return false;

            return true;
        }

        internal bool AtendimentoFinalizadoValido(FinalizarAtendimentoViewModel finalizarAtendimentoViewModel)
            => (String.IsNullOrEmpty(finalizarAtendimentoViewModel.Diagnostico) || String.IsNullOrEmpty(finalizarAtendimentoViewModel.ObservacoesFinais)) ? false : true;

        public void FinalizarAtendimento(Atendimento atendimento, FinalizarAtendimentoViewModel finalizarAtendimentoViewModel)
            => atendimento.FinalizarAtendimento(finalizarAtendimentoViewModel);

        internal bool IdAtendimentoValido(int idAtendimento)
            => idAtendimento > 0;
    }
}
