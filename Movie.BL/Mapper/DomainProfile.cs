using AutoMapper;
using Movie.BL.Model;
using Movie.DAL.Entity;

namespace Movie.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Movies, MoviesVM>().ReverseMap();
            CreateMap<Geners, GenersVM>().ReverseMap();
        }
    }
}
