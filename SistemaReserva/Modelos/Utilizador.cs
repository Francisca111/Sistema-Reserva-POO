using SistemaReserva.Enums;

namespace SistemaReserva.Modelos
{
    // Classe Base Abstrata (Pai)
    public abstract class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PerfilUtilizador Perfil { get; protected set; }

        protected Utilizador(int id, string nome, string email, string password, PerfilUtilizador perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            Perfil = perfil;
        }

        public abstract void MostrarPerfil();
    }

    // Subclasse (Filha 1) - Herda de Utilizador
    public class Administrador : Utilizador
    {
        public Administrador(int id, string nome, string email, string password) 
            : base(id, nome, email, password, PerfilUtilizador.Administrador) { }

        public override void MostrarPerfil()
        {
            System.Console.WriteLine($"[ADMINISTRADOR] ID: {Id} | Nome: {Nome} | Email: {Email}");
        }
    }

    // Subclasse (Filha 2) - Herda de Utilizador
    public class UtilizadorNormal : Utilizador
    {
        public UtilizadorNormal(int id, string nome, string email, string password) 
            : base(id, nome, email, password, PerfilUtilizador.UtilizadorNormal) { }

        public override void MostrarPerfil()
        {
            System.Console.WriteLine($"[UTILIZADOR NORMAL] ID: {Id} | Nome: {Nome} | Email: {Email}");
        }
    }
}