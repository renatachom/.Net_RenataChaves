using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        #region Gerenciamento de Tarefas

        Console.WriteLine("### Gerenciamento de Tarefas ###"); // Adição do título
        Console.WriteLine();

        while (true)
        {
            DisplayMenuOptions();
            int choice = GetChoice(1, 9);

            switch (choice)
            {
                case 1:
                    CreateTask();
                    Console.WriteLine("Tarefa criada com sucesso!");
                    break;
                case 2:
                    ListTasks();
                    break;
                case 3:
                    MarkTaskAsCompleted();
                    Console.WriteLine("Tarefa marcada como concluída!");
                    break;
                case 4:
                    ListPendingTasks();
                    break;
                case 5:
                    ListCompletedTasks();
                    break;
                case 6:
                    DeleteTask();
                    Console.WriteLine("Tarefa excluída com sucesso!");
                    break;
                case 7:
                    SearchTasks();
                    break;
                case 8:
                    ShowStatistics();
                    break;
                case 9:
                    Console.WriteLine("### Obrigado por usar o Gerenciador de Tarefas! ###");
                    Environment.Exit(0);
                    break;
            }
        }

        #endregion
    }

    #region Métodos

    static void DisplayMenuOptions()
    {
        Console.WriteLine("1. Criar Tarefa");
        Console.WriteLine("2. Listar Tarefas");
        Console.WriteLine("3. Marcar Tarefa como Concluída");
        Console.WriteLine("4. Listar Tarefas Pendentes");
        Console.WriteLine("5. Listar Tarefas Concluídas");
        Console.WriteLine("6. Excluir Tarefa");
        Console.WriteLine("7. Pesquisar Tarefas");
        Console.WriteLine("8. Estatísticas");
        Console.WriteLine("9. Sair");
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine($"Digite uma opção válida entre {min} e {max}.");
        }
        return choice;
    }

    #endregion

    #region Task Management Methods

    static void CreateTask()
    {
        Console.WriteLine("Digite o título da tarefa:");
        string title = Console.ReadLine();

        Console.WriteLine("Digite a descrição da tarefa:");
        string description = Console.ReadLine();

        Console.WriteLine("Digite a data de vencimento (formato: dd/MM/yyyy):");
        DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Task newTask = new Task(title, description, dueDate);
        tasks.Add(newTask);

        Console.WriteLine("Tarefa criada com sucesso!");
    }

    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Não há tarefas para listar.");
            return; // Retorna ao menu
        }

        Console.WriteLine("Lista de Tarefas:");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    static void MarkTaskAsCompleted()
    {
        ListTasks();
        Console.WriteLine("Digite o número da tarefa a ser marcada como concluída:");
        int taskNumber = GetChoice(1, tasks.Count) - 1;

        tasks[taskNumber].IsCompleted = true;

        Console.WriteLine("Tarefa marcada como concluída!");
    }

    static void ListPendingTasks()
    {
        Console.WriteLine("Tarefas Pendentes:");
        foreach (var task in tasks)
        {
            if (!task.IsCompleted)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void ListCompletedTasks()
    {
        Console.WriteLine("Tarefas Concluídas:");
        foreach (var task in tasks)
        {
            if (task.IsCompleted)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void DeleteTask()
    {
        ListTasks();
        Console.WriteLine("Digite o número da tarefa a ser excluída:");
        int taskNumber = GetChoice(1, tasks.Count) - 1;

        tasks.RemoveAt(taskNumber);

        Console.WriteLine("Tarefa excluída com sucesso!");
    }

    static void SearchTasks()
    {
        Console.WriteLine("Digite a palavra-chave para pesquisa:");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine("Resultado da Pesquisa:");
        foreach (var task in tasks)
        {
            if (task.Title.ToLower().Contains(keyword) || task.Description.ToLower().Contains(keyword))
            {
                Console.WriteLine(task);
            }
        }
    }

    static void ShowStatistics()
    {
        int totalTasks = tasks.Count;
        int completedTasks = tasks.Count(task => task.IsCompleted);
        int pendingTasks = totalTasks - completedTasks;

        DateTime oldestTask = tasks.Min(task => task.DueDate);
        DateTime newestTask = tasks.Max(task => task.DueDate);

        Console.WriteLine($"Número total de tarefas: {totalTasks}");
        Console.WriteLine($"Número de tarefas concluídas: {completedTasks}");
        Console.WriteLine($"Número de tarefas pendentes: {pendingTasks}");
        Console.WriteLine($"Tarefa mais antiga: {oldestTask.ToShortDateString()}");
        Console.WriteLine($"Tarefa mais recente: {newestTask.ToShortDateString()}");
    }

    #endregion
}

class Task
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public bool IsCompleted { get; set; }

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "Concluída" : "Pendente";
        return $"{Title} - {Description} - Data de Vencimento: {DueDate.ToShortDateString()} - Status: {status}";
    }
}
