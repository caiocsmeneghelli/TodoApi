using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler
        : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // FAIL FAST VALIDATION
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops, parece que sua tarefa esta errada!",
                    command.Notifications
                );

            // GERAR UM TODOITEM    
            var todo = new TodoItem(command.Title, command.Date, command.User);

            // SALVAR NO BANCO
            _repository.Create(todo);

            // RETORNO
            return new GenericCommandResult(true, "Tarefa salva!", todo);
        }
    }
}