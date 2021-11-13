using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Handlers;
using Todo.Domain.Commands;
using Todo.Domain.Tests.Repositories;
using System;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa.", "Caio Cesar", DateTime.Now);
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests()
        {

        }

        [TestMethod]
        public void Dado_um_commando_invalido()
        {
            var commandResult = (GenericCommandResult)_todoHandler.Handle(_invalidCommand);
            Assert.AreEqual(commandResult.Success, false);
        }

        [TestMethod]
        public void Dado_um_commando_valido()
        {
            var commandResult = (GenericCommandResult)_todoHandler.Handle(_validCommand);
            Assert.AreEqual(commandResult.Success, true);
        }
    }
}
