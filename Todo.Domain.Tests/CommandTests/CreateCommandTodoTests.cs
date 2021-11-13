using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using System;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateCommandTodoTests
    {
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa.", "Caio Cesar", DateTime.Now);
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);

        public CreateCommandTodoTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void Dado_Um_Command_Invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_Um_Command_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
