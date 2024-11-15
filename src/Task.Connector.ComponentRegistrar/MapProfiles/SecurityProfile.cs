using AutoMapper;
using Task.Connector.Contract.User;
using Task.Connector.Domain;

namespace Task.Connector.ComponentRegistrar.MapProfiles;

/// <summary>
/// Профиль безопасности.
/// </summary>
public class SecurityProfile : Profile
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="SecurityProfile"/>.
    /// </summary>
    public SecurityProfile()
    {
        CreateMap<UserDto, Security>(MemberList.None)
            .ForMember(x => x.UserId, map => map.MapFrom(x => x.Login));
    }
}
