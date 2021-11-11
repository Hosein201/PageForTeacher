using AutoMapper;
using Domain.Model;
using Utility.Dto;

namespace Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegsiterDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<SupportCreateDto, Support>();
            CreateMap<SupportDto, Support>();
            CreateMap<Support, SupportDto>();
            CreateMap<FieldDto, Field>();
            CreateMap<FieldCreateDto, Field>();
            CreateMap<Field, FieldDto>();
            CreateMap<EduDto, Edu>();
        }
    }
}
