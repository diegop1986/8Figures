using AutoMapper;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Domain.Extension;
using EightFigures.Contacts.Service.Interface;
using EightFigures.Contacts.Service.Repository;
using EightFigures.Contacts.Domain.CustomException.Business;
using EightFigures.Contacts.Domain.CustomException.Unauthorized;

namespace EightFigures.Contacts.Service.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenManagerService tokenManagerService;
        private readonly IMapper mapper;
        private readonly IValidationService validationService;
        private readonly ISettings settings;

        public UserService(IUserRepository userRepository, IMapper mapper, ITokenManagerService tokenManagerService, IValidationService validationService, ISettings settings)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.validationService = validationService;
            this.settings = settings;
            this.tokenManagerService = tokenManagerService;
        }

        public async Task Add(UserAddDto dto)
        {
            validationService.EnsureValid(dto);
            var @new = mapper.Map<User>(dto);
            @new.Password  = @new.Password.Encrypt(settings.EncryptionKey);
            if (await userRepository.Exists(x => x.LogIn == @new.LogIn)) throw new ExistingLogInException(@new.LogIn);

            await userRepository.Ins(@new);
        }

        public async Task<UserInfoDto> GetLogIn(LogInDto dto)
        {
            validationService.EnsureValid(dto);
            var password = dto.Password.Encrypt(settings.EncryptionKey);
            var info = await userRepository.GetInfo(x => x.LogIn == dto.LogIn && x.Password == password, x => new UserInfoDto { UserId = x.Id, LogIn = x.LogIn, Name = x.Name, Email = x.Name });
            if (info is null) throw new UnauthorizedException();
            (info.Token, info.TokenExpiration) = tokenManagerService.GenerateToken(info.LogIn, info.UserId);
            return info;
        }
    }
}
