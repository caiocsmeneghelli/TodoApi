using Todo.Domain.Repositories;
using Todo.Domain.Entities;
namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo) { }
        public void Update(TodoItem todo) { }
    }
}