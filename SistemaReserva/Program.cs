using System;
using SistemaReserva.Modelos;
using SistemaReserva.Enums;
using SistemaReserva.Servicos;
using SistemaReserva.Excecoes;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SISTEMA DE GESTÃO DE RESERVAS DE ESPAÇOS DESPORTIVOS ===");

        // Instanciação com Herança (UtilizadorNormal e Administrador herdam de Utilizador)
        Utilizador user = new UtilizadorNormal(1, "Inês Silva", "ines@estgv.ipv.pt", "pass123");
        Utilizador admin = new Administrador(2, "Carlos Admin", "admin@estgv.ipv.pt", "admin123");

        EspacoDesportivo campo = new EspacoDesportivo(101, "Campo de Futebol Sintético", TipoEspaco.CampoFutebol, "Bloco A", 22);
        campo.AdicionarEquipamento(new Equipamento(1, "Bolas de Futebol", 10, "Bom"));

        GestorReservas gestor = new GestorReservas();

        try
        {
            DateTime data = DateTime.Today;
            TimeSpan inicio = new TimeSpan(14, 0, 0);
            TimeSpan fim = new TimeSpan(15, 0, 0);

            // UC07 - Criar Reserva
            gestor.CriarReserva(1, user, campo, data, inicio, fim);
            Console.WriteLine("Pedido de reserva efetuado com sucesso (Estado: Pendente)!");

            // UC10 - Aprovação pelo Administrador
            gestor.AprovarReserva(1);
            Console.WriteLine("Reserva aprovada pelo Administrador (Estado: Confirmada)!");

            // Sub-rotina: Teste de Conflito de Horário
            gestor.CriarReserva(2, user, campo, data, inicio, fim);
        }
        catch (ConflitoHorarioException ex)
        {
            Console.WriteLine($"[EXCEÇÃO CAPTURADA]: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO GERAL]: {ex.Message}");
        }
    }
}