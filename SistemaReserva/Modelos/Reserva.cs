using System;
using SistemaReserva.Enums;

namespace SistemaReserva.Modelos
{
    public class Reserva
    {
        public int Id { get; set; }
        public Utilizador UtilizadorReserva { get; set; }
        public EspacoDesportivo Espaco { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public EstadoReserva Estado { get; private set; }

        public Reserva(int id, Utilizador utilizador, EspacoDesportivo espaco, DateTime data, TimeSpan horaInicio, TimeSpan horaFim)
        {
            Id = id;
            UtilizadorReserva = utilizador;
            Espaco = espaco;
            Data = data;
            HoraInicio = horaInicio;
            HoraFim = horaFim;
            Estado = EstadoReserva.Pendente;
        }

        public void ConfirmarReserva() => Estado = EstadoReserva.Confirmada;
        public void CancelarReserva() => Estado = EstadoReserva.Cancelada;
        public void ConcluirReserva() => Estado = EstadoReserva.Concluida;
        public void ExpirarReserva() => Estado = EstadoReserva.Expirada;
    }
}