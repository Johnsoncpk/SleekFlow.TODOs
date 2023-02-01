using SleekFlow.TODOs.Enums;

namespace SleekFlow.TODOs.Entity
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public bool IsDeleted { get; set; }

        public Todo(
            string name,
            string description,
            DateTime? dueDate,
            Status status,
            Priority priority)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }
    }
}
