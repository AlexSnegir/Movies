using FluentValidation;

namespace Movies.Application.Watchlists.Commands.AddMovieToWatchlist;

internal class AddMovieToWatchlistCommandValidator : AbstractValidator<AddMovieToWatchlistCommand>
{
    public AddMovieToWatchlistCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.MovieExternalId).NotEmpty().GreaterThan(0);
    }
}