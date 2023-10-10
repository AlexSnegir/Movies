using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Abstractions;
using Movies.API.Contracts;
using Movies.Application.Watchlists.Commands.AddMovieToWatchlist;
using Movies.Application.Watchlists.Commands.MarkMovieAsWatched;
using Movies.Application.Watchlists.Queries.GetWatchlistforUser;

namespace Movies.API.Controllers;

[Route("api/watchlist")]
public class WatchlistController : ApiController
{
    public WatchlistController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetWatchlistForUser(
        int userId,
        [FromQuery] GetWatchlistForUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = new GetWatchlistforUserQuery(
            userId,
            request.Page,
            request.Count);

        var response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : NotFound(response.Error);
    }


    [HttpPost("{userId}/movie/{movieExternalId}")]
    public async Task<IActionResult> AddMovieToWatchlist(
        int userId,
        int movieExternalId,
        CancellationToken cancellationToken = default)
    {
        var command = new AddMovieToWatchlistCommand(userId, movieExternalId);
        var response = await Sender.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response)
            : NotFound(response.Error);
    }

    [HttpPost("{userId}/movie/{movieId}/mark-as-watched")]
    public async Task<IActionResult> MarkMovieAsWatched(
        int userId,
        int movieId,
        [FromBody] MarkMovieAsWatchedRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new MarkMovieAsWatchedCommand(userId, movieId, request.IsWatched);
        var response = await Sender.Send(command, cancellationToken);

        return response.IsSuccess
            ? Ok(response)
            : NotFound(response.Error);
    }
}