using StudyFlow.Services;

var service = new TaskService();

while (true)
{
    Console.WriteLine("\n1 - Adicionar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("4 - Remover tarefa");
    Console.WriteLine("0 - Sair");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Prioridade (Alta/Media/Baixa): ");
            var priority = Console.ReadLine();

            try
            {
                service.AddTask(title, priority);
                Console.WriteLine("Tarefa adicionada!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;

        case "2":
            var tasks = service.GetTasks();
            for (int i = 0; i < tasks.Count; i++)
            {
                var t = tasks[i];
                Console.WriteLine($"{i} - {t.Title} [{t.Priority}] {(t.IsDone ? "✔" : "")}");
            }
            break;

        case "3":
            Console.Write("Índice: ");
            int doneIndex = int.Parse(Console.ReadLine());
            service.MarkDone(doneIndex);
            break;

        case "4":
            Console.Write("Índice: ");
            int removeIndex = int.Parse(Console.ReadLine());
            service.RemoveTask(removeIndex);
            break;

        case "0":
            return;
    }
}