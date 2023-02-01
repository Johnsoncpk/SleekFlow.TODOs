using SleekFlow.TODOs.Entity;
using SleekFlow.TODOs.Enums;
using SleekFlow.TODOs.IManager;
using SleekFlow.TODOs.Library.Result;
using SleekFlow.TODOs.Library.Linq;
using SleekFlow.TODOs.Result;

namespace SleekFlow.TODOs.Manager
{
    public class TodoManager : ITodoManager
    {
        // store todos in a list
        private readonly List<Todo> _todoList;

        public TodoManager()
        {
            // initialize & seed data
            _todoList = new List<Todo>
            {
                new Todo(
                    "Sleekflow code test",
                    "Write a todo api",
                    new DateTime(2023, 2, 2),
                    Status.Doing,
                    Priority.High),
                new Todo(
                    "HKDAS Hackathon",
                    "Two days hackathon at Cyberport",
                    new DateTime(2023, 2, 4, 9, 30, 00),
                    Status.ToDo,
                    Priority.Medium),
                new Todo(
                    "CS4386 Homework",
                    "Tutorial 2: Tic tac toe",
                    new DateTime(2023, 2, 6),
                    Status.Done,
                    Priority.Low),
            };
        }

        public PagedResult<TodoResult> GetAll(
            string? name,
            string? description,
            DateTime? dueDateAfter,
            DateTime? dueDateBefore,
            Status? status,
            Priority? priority,
            int page,
            int pageSize,
            string? sorting,
            bool isDesc)
        {
            return _todoList.AsQueryable()
                .WhereIf(!string.IsNullOrEmpty(name), x => x.Name.Contains(name!))
                .WhereIf(!string.IsNullOrEmpty(description), x => x.Description.Contains(description!))
                .WhereIf(dueDateAfter.HasValue, x => x.DueDate >= dueDateAfter)
                .WhereIf(dueDateBefore.HasValue, x => x.DueDate <= dueDateBefore)
                .WhereIf(status != null, x => x.Status == status)
                .WhereIf(priority != null, x => x.Priority == priority)
                .GetSortedAndPagedResult(
                x => new TodoResult(
                    x.Id,
                    x.Name,
                    x.DueDate,
                    x.Status,
                    x.Priority),
                page,pageSize,sorting,isDesc);
        }

        public TodoDetailResult? GetById(Guid id)
        {
            return _todoList
                .Where(x => x.Id == id)
                .Select(x => new TodoDetailResult(
                    x.Name,
                    x.Description,
                    x.DueDate,
                    x.Status,
                    x.Priority))
                .FirstOrDefault();
        }

        public Guid Create(Todo todo)
        {
            _todoList.Add(todo);
            return todo.Id;
        }

        public bool Update(
            Guid id,
            string name,
            string description,
            DateTime dueDate,
            Status status,
            Priority priority)
        {
            var item = _todoList.Find(x => x.Id == id);

            if (item == null)
            {
                return false;
            }

            item.Name = name;
            item.Description = description;
            item.DueDate = dueDate;
            item.Status = status;
            item.Priority = priority;
            return true;
        }

        public bool Delete(Guid id)
        {
            var count = _todoList.RemoveAll(x => x.Id == id);
            return count == 1;
        }
    }
}
