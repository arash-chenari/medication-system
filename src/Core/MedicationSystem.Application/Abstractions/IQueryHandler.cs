using MediatR;

namespace MedicationSystem.Application.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : 
    IRequestHandler<TQuery,TResponse> where TQuery : IQuery<TResponse>
{
}