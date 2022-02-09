using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;
        public TodoQueryTests()
        {
            _items = new List<TodoItem>();

            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "andrebaltieri"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuario"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "andrebaltieri"));
            _items.Add(new TodoItem("Tarefa 4", DateTime.Now, "usuario2"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_andrebaltieri()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("andrebaltieri"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_por_tarefas_finalizadas_por_usuario_andrebaltieri()
        {
            _items[0].MarkAsDone();
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("andrebaltieri"));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_por_tarefas_nao_finalizdas_por_usuario_andrebaltieri()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("andrebaltieri"));
            Assert.AreEqual(2, result.Count());
        }

    }
}