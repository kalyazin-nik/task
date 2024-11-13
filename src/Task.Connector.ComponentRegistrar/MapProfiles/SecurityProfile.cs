using AutoMapper;
using Task.Connector.Contract.User;
using Task.Connector.Domain;

namespace Task.Connector.ComponentRegistrar.MapProfiles;

public class SecurityProfile : Profile
{
    public SecurityProfile()
    {
        CreateMap<UserDto, Security>(MemberList.None)
            .ForMember(x => x.UserId, map => map.MapFrom(x => x.Login));
    }
}
