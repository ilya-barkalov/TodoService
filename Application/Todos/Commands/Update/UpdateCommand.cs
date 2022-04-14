using MediatR;

namespace Application.Todos.Commands.Update
{
    public class UpdateCommand : IRequest
    {
        public UpdateCommand(long id, string name, bool isComplete)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
