using FluentValidation;

namespace Movies.Application.Watchlists.Commands.MarkMovieAsWatched;

internal class MarkMovieAsWatchedCommandValidator : AbstractValidator<MarkMovieAsWatchedCommand>
{
    public MarkMovieAsWatchedCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.MovieId).NotEmpty().GreaterThan(0);
    }
}