using ControleDeTarefas.Models;
using ControleDeTarefas.Services;

TarefaService service = new();

void Menu()
{
    Console.WriteLine("\n=== Controle de Tarefas ===");
    Console.WriteLine("1. Cadastrar tarefa");
    Console.WriteLine("2. Listar tarefas");
    Console.WriteLine("3. Marcar como concluída");
    Console.WriteLine("4. Filtrar tarefas");
    Console.WriteLine("0. Sair");
}

bool executando = true;

while (executando)
{
    try
    {
        Menu();
        Console.Write("Escolha uma opção: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.Write("Título: ");
                var titulo = Console.ReadLine() ?? "";
                Console.Write("Descrição: ");
                var descricao = Console.ReadLine() ?? "";
                Console.Write("Data de vencimento (dd/mm/yyyy): ");
                DateTime data = DateTime.Parse(Console.ReadLine() ?? "");
                service.CadastrarTarefa(titulo, descricao, data);
                Console.WriteLine("Tarefa cadastrada com sucesso!");
                break;

            case "2":
                var tarefas = service.ListarTarefas();
                foreach (var t in tarefas)
                {
                    Console.WriteLine($"\nID: {t.Id}");
                    Console.WriteLine($"Título: {t.Titulo}");
                    Console.WriteLine($"Descrição: {t.Descricao}");
                    Console.WriteLine($"Data Vencimento: {t.DataVencimento:dd/MM/yyyy}");
                    Console.WriteLine($"Status: {t.Status}");
                }
                break;

            case "3":
                Console.Write("ID da tarefa a concluir: ");
                int id = int.Parse(Console.ReadLine() ?? "0");
                if (service.MarcarComoConcluida(id))
                    Console.WriteLine("Tarefa marcada como concluída.");
                else
                    Console.WriteLine("Tarefa não encontrada.");
                break;

            case "4":
                Console.Write("Status (Pendente, EmAndamento, Concluida): ");
                var status = Enum.Parse<StatusTarefa>(Console.ReadLine() ?? "Pendente");
                var filtradasStatus = service.FiltrarPorStatus(status);
                foreach (var t in filtradasStatus)
                    Console.WriteLine($"ID: {t.Id} | {t.Titulo} - {t.Status}");
                break;

            case "5":
                Console.Write("Data (dd/mm/yyyy): ");
                DateTime filtroData = DateTime.Parse(Console.ReadLine() ?? "");
                var filtradasData = service.FiltrarPorData(filtroData);
                foreach (var t in filtradasData)
                    Console.WriteLine($"ID: {t.Id} | {t.Titulo} - {t.DataVencimento:dd/MM/yyyy}");
                break;

            case "0":
                executando = false;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }
}
