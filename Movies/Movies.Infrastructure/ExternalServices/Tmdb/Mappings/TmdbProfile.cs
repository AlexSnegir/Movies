using AutoMapper;
using Microsoft.Extensions.Options;
using Movies.Application.Movies.Queries.SearchMovie;
using Movies.Domain.Entities;
using Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;
using Movies.Infrastructure.ExternalServices.Tmdb.Models.SearchMovie;
using Movies.Infrastructure.ExternalServices.TmdbService.Tmdb.Settings;

namespace Movies.Application.Mappings;

public class TmdbProfile : Profile
{
    public TmdbProfile(IOptions<TmdbSettings> tmdbOptions)
    {
        CreateMap<MovieDetailsModel, Movie>()
            .ForMember(
                target => target.Id,
                opt => opt.Ignore())
            .ForMember(
                target => target.ExternalId,
                src => src.MapFrom(src => src.Id))
            .ForMember(
                target => target.PosterPath,
                opt => opt.ConvertUsing(new ImagePathFormatter(tmdbOptions)));

        CreateMap<BelongsToCollectionModel, MovieCollection>()
            .ForMember(
                target => target.PosterPath,
                opt => opt.ConvertUsing(new ImagePathFormatter(tmdbOptions)));

        CreateMap<GenreModel, Genre>();
        CreateMap<ProductionCompanyModel, ProductionCompany>()
            .ForMember(
                target => target.LogoPath,
                opt => opt.ConvertUsing(new ImagePathFormatter(tmdbOptions)));

        CreateMap<ProductionCountryModel, ProductionCountry>();
        CreateMap<SpokenLanguagesModel, SpokenLanguage>();

        CreateMap<SearchMovieModel, SearchMovieResponse>()
            .ForMember(
                target => target.Movies,
                src => src.MapFrom(src => src.Results));

        CreateMap<MovieModel, MovieResponse>()
            .ForMember(
                target => target.PosterPath,
                opt => opt.ConvertUsing(new ImagePathFormatter(tmdbOptions)));
    }
}