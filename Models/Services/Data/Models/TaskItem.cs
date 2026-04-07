namespace StudyFlow.Models
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Priority { get; set; } // Alta, Media, Baixa
        public bool IsDone { get; set; }
    }
}