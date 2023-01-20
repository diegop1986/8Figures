using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Interface
{
    public interface IUserService
    {
        Task<int> Add(UserAddDto dto);

        Task<UserInfoDto> GetLogIn(LogInDto dto);
    }
}
