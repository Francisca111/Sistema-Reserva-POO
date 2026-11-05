using System;
using System.Collections.Generic;
using System.Linq;
using SistemaReserva.Modelos;
using SistemaReserva.Enums;
using SistemaReserva.Excecoes;

namespace SistemaReserva.Servicos
{
    public class GestorReservas
    {
        private List<Reserva> reservas = new List<Reserva>();

        public void CriarReserva(int id, Utilizador utilizador, EspacoDesportivo espaco, DateTime data, TimeSpan inicio, TimeSpan fim)
        {
            if (utilizador == null)
                throw new NaoAutenticadoException("Utilizador não autenticado!");

            if (!espaco.Disponivel)
                throw new EspacoInexistenteException("O espaço selecionado encontra-se indisponível.");

            bool temConflito = reservas.Any(r => r.Espaco.Id == espaco.Id 
                                              && r.Data.Date == data.Date 
                                              && r.Estado == EstadoReserva.Confirmada
                                              && (inicio < r.HoraFim && fim > r.HoraInicio));
            if (temConflito)
                throw new ConflitoHorarioException("Conflito de horário: O espaço já se encontra reservado para este intervalo.");

            Reserva novaReserva = new Reserva(id, utilizador, espaco, data, inicio, fim);
            reservas.Add(novaReserva);
        }

        public List<Reserva> ObterReservasPorUtilizador(int idUtilizador)
        {
            return reservas.Where(r => r.UtilizadorReserva.Id == idUtilizador).ToList();
        }

        public void AprovarReserva(int idReserva)
        {
            var res = reservas.FirstOrDefault(r => r.Id == idReserva);
            if (res != null && res.Estado == EstadoReserva.Pendente)
            {
                res.ConfirmarReserva();
            }
        }

        public void ExpirarReservasAntigas()
        {
            foreach (var r in reservas.Where(r => r.Estado == EstadoReserva.Pendente))
            {
                r.ExpirarReserva();
            }
        }

        public void ConcluirReservasFinalizadas()
        {
            foreach (var r in reservas.Where(r => r.Estado == EstadoReserva.Confirmada && r.Data.Date <= DateTime.Today))
            {
                r.ConcluirReserva();
            }
        }
    }
}