using System;

namespace SistemaReserva.Excecoes
{
    public class AutenticacaoException : Exception
    {
        public AutenticacaoException(string message) : base(message) { }
    }

    public class EmailJaExisteException : Exception
    {
        public EmailJaExisteException(string message) : base(message) { }
    }

    public class NaoAutenticadoException : Exception
    {
        public NaoAutenticadoException(string message) : base(message) { }
    }

    public class EspacoInexistenteException : Exception
    {
        public EspacoInexistenteException(string message) : base(message) { }
    }

    public class EspacoComReservasException : Exception
    {
        public EspacoComReservasException(string message) : base(message) { }
    }

    public class ConflitoHorarioException : Exception
    {
        public ConflitoHorarioException(string message) : base(message) { }
    }
}