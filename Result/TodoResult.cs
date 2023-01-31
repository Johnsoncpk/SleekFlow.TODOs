using SleekFlow.TODOs.Enums;

namespace SleekFlow.TODOs.Result
{
    public class ToDoResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? DueDate { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public ToDoResult(
            Guid id,
            string name,
            DateTime? dueDate,
            Status status,
            Priority priority)
        {
            Id = id;
            Name = name;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }
    }
}
