﻿using ClinicaVet.GestaoVeterinaria.Interfaces;
using ClinicaVet.GestaoVeterinaria.Models;
using ClinicaVet.GestaoVeterinaria.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace ClinicaVet.GestaoVeterinaria.Services
{
    public class AtendimentoService : IAtendimentoService
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

        public bool AtendimentoFinalizadoValido(FinalizarAtendimentoViewModel finalizarAtendimentoViewModel)
            => (String.IsNullOrEmpty(finalizarAtendimentoViewModel.Diagnostico) || String.IsNullOrEmpty(finalizarAtendimentoViewModel.ObservacoesFinais)) ? false : true;

        public void FinalizarAtendimento(Atendimento atendimento, FinalizarAtendimentoViewModel finalizarAtendimentoViewModel)
            => atendimento.FinalizarAtendimento(finalizarAtendimentoViewModel);

        public bool IdAtendimentoValido(int idAtendimento)
            => idAtendimento > 0;
    }
}
