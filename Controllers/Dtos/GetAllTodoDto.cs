using SleekFlow.TODOs.Enums;
using SleekFlow.TODOs.Library.Dto;

namespace SleekFlow.TODOs.Controllers.Dtos
{
    public class GetAllToDoDto: SortingPagingDto
    {
        /// <summary>
        /// The name of the task
        /// </summary>
        /// <example>Workout</example>
        public string? Name { get; set; }

        /// <summary>
        /// The description of the task
        /// </summary>
        /// <example>15 mins workout</example>
        public string? Description { get; set; }

        /// <summary>
        /// Filter out due date after this date
        /// </summary>
        /// <example>01/01/2047 00:00:00</example>
        public DateTime? DueDateAfter { get; set; }

        /// <summary>
        /// Filter out due date before this date
        /// </summary>
        /// <example>01/01/2047 00:00:00</example>
        public DateTime? DueDateBefore { get; set; }

        /// <summary>
        /// The process status of the task
        /// </summary>
        public Status? Status { get; set; }

        /// <summary>
        /// The priority level of the task
        /// </summary>
        public Priority? Priority { get; set; }
    }
}
