﻿using SleekFlow.TODOs.Entity;
using SleekFlow.TODOs.Enums;
using SleekFlow.TODOs.IManager;
using SleekFlow.TODOs.Library.Result;
using SleekFlow.TODOs.Result;

namespace SleekFlow.TODOs.Manager
{
    public class ToDoManager : IToDoManager
    {
        public PagedResult<ToDoResult> GetAll(string? name, string? description, DateTime? dueDateAfter, DateTime? dueDateBefore, Status? status, Priority? priority, int page, int pageSize, string? sorting, bool isDesc)
        {
            throw new NotImplementedException();
        }

        public ToDoDetailResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Guid Create(ToDo todo)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, string name, string description, DateTime dueDate, Status status, Priority priority)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
