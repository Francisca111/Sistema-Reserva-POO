namespace SistemaReserva.Modelos
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string EstadoConservacao { get; set; }

        public Equipamento(int id, string nome, int quantidadeDisponivel, string estadoConservacao)
        {
            Id = id;
            Nome = nome;
            QuantidadeDisponivel = quantidadeDisponivel;
            EstadoConservacao = estadoConservacao;
        }
    }
}