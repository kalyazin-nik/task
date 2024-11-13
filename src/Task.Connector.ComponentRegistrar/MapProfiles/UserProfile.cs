using AutoMapper;
using Task.Connector.Contract.User;
using Task.Connector.Domain;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.ComponentRegistrar.MapProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserToCreate, UserDto>(MemberList.None)
            .ForMember(x => x.Password, map => map.MapFrom(x => x.HashPassword));

        CreateMap<UserDto, User>(MemberList.None);
        CreateMap<UserDto, UserAllPropertiesDto>(MemberList.None);

        CreateMap<User, UserPropertiesDto>(MemberList.None);
        CreateMap<User, UserAllPropertiesDto>(MemberList.None)
            .ForMember(x => x.IsLead, map => map.MapFrom(x => x.IsLead.ToString()))
            .ForMember(x => x.Password, map => map.MapFrom(x => x.Security!.Password));
    }
}
