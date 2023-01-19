using Microsoft.AspNetCore.Mvc;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Service.Interface;

namespace EightFigures.Contacts.API.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService userService;

        public AuthenticationController(IUserService userService) => this.userService = userService;

        [HttpPost]
        [Produces("application/json")]
        public async Task<UserInfoDto> Authentication([FromBody] LogInDto dto) => await userService.GetLogIn(dto);
    }
}
