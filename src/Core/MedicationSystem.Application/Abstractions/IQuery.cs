using MediatR;

namespace MedicationSystem.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}