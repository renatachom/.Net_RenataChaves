using System;
using System.Collections.Generic;


public class GerenciadorTarefas
{
    private List<Tarefa> listaDeTarefas = new List<Tarefa>();

    public void AdicionarTarefa(Tarefa tarefa)
    {
        listaDeTarefas.Add(tarefa);
    }

    public void ListarTarefas()
    {
        foreach (var tarefa in listaDeTarefas)
        {
            Console.WriteLine($"Título: {tarefa.Titulo}, Descrição: {tarefa.Descricao}, Vencimento: {tarefa.DataVencimento}, Concluída: {tarefa.Concluida}");
        }
    }

    // Implemente métodos para marcar como concluída, excluir e outras operações conforme necessário.
}
