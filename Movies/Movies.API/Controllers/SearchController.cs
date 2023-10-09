using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Abstractions;
using Movies.API.Contracts;
using Movies.Application.Movies.Queries.SearchMovie;

namespace Movies.API.Controllers;

[Route("api/search")]
public class SearchController : ApiController
{
    public SearchController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("movie")]
    public async Task<IActionResult> SearchMovie(
        [FromQuery] SearchMovieRequest request,
        CancellationToken cancellationToken = default)
    {
        var searchMovieQuery = new SearchMovieQuery(
            request.Query,
            request.IncludeAdult,
            "en-US",
            null,
            request.Page,
            request.Region,
            request.Year);

        var response = await Sender.Send(searchMovieQuery, cancellationToken);

        return response.IsSuccess
            ? Ok(response.Value)
            : NotFound(response.Error);
    }
}