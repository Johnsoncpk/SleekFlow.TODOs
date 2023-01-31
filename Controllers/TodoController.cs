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
    public class ToDoController : ControllerBase
    {
        private readonly IToDoManager _todoManager;
        public ToDoController(
            IToDoManager todoManager)
        {
            _todoManager = todoManager;
        }

        [HttpGet]
        public StandardResult<PagedResult<ToDoResult>> GetAll([FromQuery] GetAllToDoDto input)
        {
            PagedResult<ToDoResult> result = _todoManager
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

            return new StandardResult<PagedResult<ToDoResult>>(
                result,
                200,
                null);
        }

        [HttpGet("{id}")]
        public StandardResult<ToDoDetailResult> Get(Guid id)
        {
            ToDoDetailResult result = _todoManager.GetById(id);

            return new StandardResult<ToDoDetailResult>(
                result,
                200,
                null);
        }

        [HttpPost]
        public StandardResult<Guid> Create([FromBody] CreateTodoDto input)
        {
            Guid result = _todoManager
                .Create(new ToDo(
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
        public StandardResult<Object> Update(Guid id, [FromBody] UpdateToDoDto input)
        {
            _todoManager.Update(
                id,
                input.Name,
                input.Description,
                input.DueDate,
                input.Status,
                input.Priority
                );

            return new StandardResult<Object>(
                null,
                204,
                null);
        }

        [HttpDelete("{id}")]
        public StandardResult<Object> Delete(Guid id)
        {
            _todoManager.Delete(id);

            return new StandardResult<Object>(
                null,
                204,
                null);
        }
    }
}
