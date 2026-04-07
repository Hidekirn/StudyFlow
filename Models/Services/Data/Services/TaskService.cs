using System.Text.Json;
using StudyFlow.Models;

namespace StudyFlow.Services
{
    public class TaskService
    {
        private const string FilePath = "Data/tasks.json";
        private List<TaskItem> tasks = new();

        public TaskService()
        {
            Load();
        }

        public void AddTask(string title, string priority)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título inválido");

            tasks.Add(new TaskItem
            {
                Title = title,
                Priority = priority,
                IsDone = false
            });

            Save();
        }

        public List<TaskItem> GetTasks() => tasks;

        public void RemoveTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
                throw new ArgumentException("Índice inválido");

            tasks.RemoveAt(index);
            Save();
        }

        public void MarkDone(int index)
        {
            if (index < 0 || index >= tasks.Count)
                throw new ArgumentException("Índice inválido");

            tasks[index].IsDone = true;
            Save();
        }

        private void Save()
        {
            Directory.CreateDirectory("Data");
            File.WriteAllText(FilePath, JsonSerializer.Serialize(tasks));
        }

        private void Load()
        {
            if (!File.Exists(FilePath)) return;

            var json = File.ReadAllText(FilePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new();
        }
    }
}