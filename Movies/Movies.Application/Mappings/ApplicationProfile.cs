using AutoMapper;
using Movies.Application.Watchlists.Queries.GetWatchlistforUser;
using Movies.Domain.Entities;

namespace Movies.Application.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Watchlist, GetWatchlistforUserResponse>();
        CreateMap<Movie, MovieResponse>();
        CreateMap<Genre, GenreResponse>();
        CreateMap<ProductionCompany, ProductionCompanyResponse>();
        CreateMap<ProductionCountry, ProductionCountryResponse>();
        CreateMap<SpokenLanguage, SpokenLanguageResponse>();
    }
}