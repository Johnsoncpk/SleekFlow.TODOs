using SleekFlow.TODOs.Enums;

namespace SleekFlow.TODOs.Controllers.Dtos
{
    public class UpdateTodoDto
    {
        /// <summary>
        /// The name of the task
        /// </summary>
        /// <example>Workout</example>
        public string Name { get; set; }

        /// <summary>
        /// The description of the task
        /// </summary>
        /// <example>15 mins workout</example>
        public string Description { get; set; }

        /// <summary>
        /// The due date of the task
        /// </summary>
        /// <example>01/01/2047 00:00:00</example>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The process status of the task
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// The priority level of the task
        /// </summary>
        public Priority Priority { get; set; }

        public UpdateTodoDto(
            string name,
            string description,
            DateTime dueDate,
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
