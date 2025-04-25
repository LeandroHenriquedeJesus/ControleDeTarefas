using ControleDeTarefas.Models;

namespace ControleDeTarefas.Services;

public class TarefaService
{
    private List<Tarefa> tarefas = new();
    private int proximoId = 1;

    public void CadastrarTarefa(string titulo, string descricao, DateTime dataVencimento)
    {
        tarefas.Add(new Tarefa
        {
            Id = proximoId++,
            Titulo = titulo,
            Descricao = descricao,
            DataVencimento = dataVencimento,
            Status = StatusTarefa.Pendente
        });
    }

    public List<Tarefa> ListarTarefas()
    {
        return tarefas;
    }

    public bool MarcarComoConcluida(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return false;
        tarefa.Status = StatusTarefa.Concluida;
        return true;
    }

    public List<Tarefa> FiltrarPorStatus(StatusTarefa status)
    {
        return tarefas.Where(t => t.Status == status).ToList();
    }

    public List<Tarefa> FiltrarPorData(DateTime data)
    {
        return tarefas.Where(t => t.DataVencimento.Date == data.Date).ToList();
    }
}