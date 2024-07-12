using AutoMapper;
using DemoApi.Core.Models;

namespace DemoApi.Core;

public class LibraryProfile : Profile
{
    public LibraryProfile()
    {
        CreateMap<Book, BookViewModel>().ReverseMap();
        CreateMap<Form, FormViewModel>().ReverseMap();
        CreateMap<Reader, ReaderViewModel>().ReverseMap();
    }
}
