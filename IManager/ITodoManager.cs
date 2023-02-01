using SleekFlow.TODOs.Entity;
using SleekFlow.TODOs.Enums;
using SleekFlow.TODOs.Library.Result;
using SleekFlow.TODOs.Result;

namespace SleekFlow.TODOs.IManager
{
    public interface ITodoManager
    {
        PagedResult<TodoResult> GetAll(
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

        TodoDetailResult? GetById(Guid id);

        Guid Create(Todo todo);

        bool Update(
            Guid id,
            string name,
            string description,
            DateTime dueDate,
            Status status,
            Priority priority);

        bool Delete(Guid id);
        
    }
}
