using SleekFlow.TODOs.Enums;

namespace SleekFlow.TODOs.Result
{
    public class ToDoDetailResult
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public ToDoDetailResult(
            string name,
            string description,
            DateTime? dueDate,
            Status status,
            Priority priority)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
        }
    }
}
