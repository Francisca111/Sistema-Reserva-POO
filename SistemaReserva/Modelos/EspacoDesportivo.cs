using System.Collections.Generic;
using SistemaReserva.Enums;

namespace SistemaReserva.Modelos
{
    public class EspacoDesportivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoEspaco Tipo { get; set; }
        public string Localizacao { get; set; }
        public int CapacidadeMaxima { get; set; }
        public bool Disponivel { get; set; }
        public List<Equipamento> Equipamentos { get; set; }

        public EspacoDesportivo(int id, string nome, TipoEspaco tipo, string localizacao, int capacidadeMaxima)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Localizacao = localizacao;
            CapacidadeMaxima = capacidadeMaxima;
            Disponivel = true;
            Equipamentos = new List<Equipamento>();
        }

        public void AdicionarEquipamento(Equipamento eq)
        {
            Equipamentos.Add(eq);
        }
    }
}