using FluentValidation;

namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

internal class GetWatchlistforUserQueryValidator : AbstractValidator<GetWatchlistforUserQuery>
{
    public GetWatchlistforUserQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Page).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Count).NotEmpty().GreaterThanOrEqualTo(0);
    }
}