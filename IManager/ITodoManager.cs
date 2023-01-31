using SleekFlow.TODOs.Entity;
using SleekFlow.TODOs.Enums;
using SleekFlow.TODOs.Library.Result;
using SleekFlow.TODOs.Result;

namespace SleekFlow.TODOs.IManager
{
    public interface IToDoManager
    {
        PagedResult<ToDoResult> GetAll(
            string? name,
            string? description,
            DateTime? dueDateAfter,
            DateTime? dueDateBefore,
            Status? status,
            Priority? priority,
            int page,
            int pageSize,
            string? sorting,
            bool isDesc);

        ToDoDetailResult GetById(Guid id);

        Guid Create(ToDo todo);

        void Update(
            Guid id,
            string name,
            string description,
            DateTime dueDate,
            Status status,
            Priority priority);

        void Delete(Guid id);
        
    }
}
