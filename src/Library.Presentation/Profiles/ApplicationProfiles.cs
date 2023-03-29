using AutoMapper;
using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using Library.DataAccess.Models;

namespace Library.Presentation.Profiles
{
    public class ApplicationProfiles : Profile
    {
        public ApplicationProfiles()
        {
            CreateMap<GenreRequest, Genre>()
                .ReverseMap();

            CreateMap<Genre, GenreDto>()
                .ReverseMap();

            CreateMap<EditionHouseRequest, EditionHouse>()
                .ReverseMap();

            CreateMap<EditionHouse, EditionHouseDto>()
                .ReverseMap();

            CreateMap<BookRequest, Book>()
                .ReverseMap();

            CreateMap<Book, BookDto>();
        }
    }
}
