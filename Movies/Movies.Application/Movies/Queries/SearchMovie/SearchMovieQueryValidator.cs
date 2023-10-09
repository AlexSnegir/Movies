using FluentValidation;

namespace Movies.Application.Movies.Queries.SearchMovie;

internal class SearchMovieQueryValidator : AbstractValidator<SearchMovieQuery>
{
    public SearchMovieQueryValidator()
    {
        RuleFor(x => x.Query).NotEmpty();
        RuleFor(x => x.Language).NotEmpty().MaximumLength(5);
        RuleFor(x => x.PrimaryReleaseYear).Length(4);
        RuleFor(x => x.Page).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Region).MaximumLength(30);
        RuleFor(x => x.Year).Length(4);
    }
}