using Microsoft.AspNetCore.Mvc;
using SleekFlow.TODOs.Controllers.Dtos;
using SleekFlow.TODOs.Entity;
using SleekFlow.TODOs.IManager;
using SleekFlow.TODOs.Library.Result;
using SleekFlow.TODOs.Result;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SleekFlow.Controllers.ToDos
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoManager _todoManager;
        public TodoController(
            ITodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        [HttpGet]
        public StandardResult<PagedResult<TodoResult>> GetAll([FromQuery] GetAllTodoDto input)
        {
            PagedResult<TodoResult> result = _todoManager
                .GetAll(
                    input.Name,
                    input.Description,
                    input.DueDateAfter,
                    input.DueDateBefore,
                    input.Status,
                    input.Priority,
                    input.Page,
                    input.PageSize,
                    input.Sorting,
                    input.IsDesc);

            return new StandardResult<PagedResult<TodoResult>>(
                result,
                200,
                null);
        }

        [HttpGet("{id}")]
        public StandardResult<TodoDetailResult> Get(Guid id)
        {
            TodoDetailResult? result = _todoManager.GetById(id);

            if(result == null)
            {
                return new StandardResult<TodoDetailResult>(
                null,
                404,
                "Item not found with id: " + id);
            }

            return new StandardResult<TodoDetailResult>(
                result,
                200,
                null);
        }

        [HttpPost]
        public StandardResult<Guid> Create([FromBody] CreateTodoDto input)
        {
            Guid result = _todoManager
                .Create(new Todo(
                    input.Name,
                    input.Description,
                    input.DueDate,
                    input.Status,
                    input.Priority));

            return new StandardResult<Guid>(
                result,
                201,
                null);
        }

        [HttpPut("{id}")]
        public StandardResult<Object> Update(Guid id, [FromBody] UpdateTodoDto input)
        {
            var isSuccess = _todoManager.Update(
                id,
                input.Name,
                input.Description,
                input.DueDate,
                input.Status,
                input.Priority
                );

            if (!isSuccess)
            {
                return new StandardResult<Object>(
                null,
                404,
                "Item not found with id: " + id);
            }

            return new StandardResult<Object>(
                null,
                204,
                null);
        }

        [HttpDelete("{id}")]
        public StandardResult<Object> Delete(Guid id)
        {
            var isSuccess = _todoManager.Delete(id);

            if (!isSuccess)
            {
                return new StandardResult<Object>(
                null,
                400,
                "Delete operation failed with id: " + id);
            }

            return new StandardResult<Object>(
                null,
                204,
                null);
        }
    }
}
