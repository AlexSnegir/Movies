using AutoMapper;
using Movies.Application.Abstractions.Messaging;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;
using Movies.Domain.Shared;

namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

internal sealed class GetWatchlistforUserQueryHandler
    : IQueryHandler<GetWatchlistforUserQuery, IEnumerable<GetWatchlistforUserResponse>>
{
    private readonly IWatchlistRepository<Watchlist> _repository;
    private readonly IMapper _mapper;

    public GetWatchlistforUserQueryHandler(
        IWatchlistRepository<Watchlist> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<GetWatchlistforUserResponse>>> Handle(
        GetWatchlistforUserQuery request,
        CancellationToken cancellationToken)
    {
        var userWatchlist = (await _repository.GetWatchlistForUserAsync(request.UserId, cancellationToken))
            .Skip((request.Page - 1) * request.Count)
            .Take(request.Count)
            .ToList();

        if (userWatchlist == null || userWatchlist.Count == 0)
        {
            return Result.Failure<IEnumerable<GetWatchlistforUserResponse>>(
                new Error("Watchlist.NotFound", "Watchlist not found"));
        }

        var result = _mapper.Map<List<GetWatchlistforUserResponse>>(userWatchlist);

        return result;
    }
}