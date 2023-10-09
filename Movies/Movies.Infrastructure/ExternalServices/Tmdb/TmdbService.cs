using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using Movies.Application.Abstractions.ExternalServices;
using Movies.Application.Movies.Queries.SearchMovie;
using Movies.Application.Watchlists.Commands.AddMovieToWatchlist;
using Movies.Domain.Entities;
using Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;
using Movies.Infrastructure.ExternalServices.Tmdb.Models.SearchMovie;
using Movies.Infrastructure.ExternalServices.TmdbService.Tmdb.Settings;
using System.Net.Http.Json;

namespace Movies.Infrastructure.ExternalServices.TmdbService;

public class TmdbService : ITmdbService
{
    private readonly TmdbSettings _tmdbSettings;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public TmdbService(
        IOptions<TmdbSettings> tmdbOptions,
        HttpClient httpClient,
        IMapper mapper)
    {
        _tmdbSettings = tmdbOptions.Value;
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public async Task<SearchMovieResponse?> SearchMovie(
        SearchMovieQuery query,
        CancellationToken cancellationToken)
    {
        var uriQuery = BuildSearchMovieUriQuery(query);

        var response = await _httpClient
            .GetFromJsonAsync<SearchMovieModel>(
                $"{_tmdbSettings.SearchMoviePath}{uriQuery}",
                cancellationToken);

        return _mapper.Map<SearchMovieResponse>(response);
    }

    public async Task<Movie?> MovieDetails(
        MovieDetailsQuery query,
        CancellationToken cancellationToken)
    {
        var uriQuery = BuildMovieDetailsUriQuery(query);

        var response = await _httpClient
            .GetFromJsonAsync<MovieDetailsModel>(
                $"{_tmdbSettings.MovieDetailsPath}/{query.MovieId}{uriQuery}",
                cancellationToken);

        return _mapper.Map<Movie>(response);
    }

    private string BuildSearchMovieUriQuery(SearchMovieQuery query)
    {
        var queryBuilder = new QueryBuilder()
        {
            { "query", query.Query },
            { "include_adult", query.IncludeAdult.ToString() },
            { "language", query.Language },
            { "page", query.Page.ToString() },
            { "api_key", _tmdbSettings.ApiKey }
        };

        if (query.Region is not null)
            queryBuilder.Add("region", query.Region);

        if (query.Year is not null)
            queryBuilder.Add("year", query.Year);

        return queryBuilder.ToString();
    }
    private string BuildMovieDetailsUriQuery(MovieDetailsQuery query)
    {
        var queryBuilder = new QueryBuilder()
        {
            { "language", query.Language },
            { "api_key", _tmdbSettings.ApiKey }
        };

        if (query.AppendToResponse is not null)
            queryBuilder.Add("append_to_response", query.AppendToResponse);

        return queryBuilder.ToString();
    }
}