using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string email)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(email)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string email)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(email)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string email)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(email)).OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string email)
        {
            return _context.Todos.FirstOrDefault(x => x.Id == id && x.User == email);
        }

        public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(email, date, done)).OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}