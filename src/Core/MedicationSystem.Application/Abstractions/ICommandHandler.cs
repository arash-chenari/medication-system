using MediatR;

namespace MedicationSystem.Application.Abstractions;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}