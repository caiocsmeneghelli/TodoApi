using Todo.Domain.Repositories;
using Todo.Domain.Entities;
using System;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo) { }

        public TodoItem GetById(Guid id, string email)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo) { }
    }
}