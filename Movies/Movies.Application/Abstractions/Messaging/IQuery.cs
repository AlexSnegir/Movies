using Movies.Domain.Shared;
using MediatR;

namespace Movies.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}