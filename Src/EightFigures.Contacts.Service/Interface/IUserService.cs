using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Interface
{
    public interface IUserService
    {
        Task Add(UserAddDto dto);

        Task<UserInfoDto> GetLogIn(LogInDto dto);
    }
}
