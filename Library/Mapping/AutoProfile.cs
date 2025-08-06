using AutoMapper;
using Library.DTO;
using Library.Entities;

namespace Library.Mapping
{
    public class AutoProfile:Profile
    {
        public AutoProfile()
        {
            CreateMap<bookdto, Book>().ReverseMap();
        }
    }
}
