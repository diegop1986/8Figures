using Microsoft.AspNetCore.Mvc;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Service.Interface;

namespace EightFigures.Contacts.API.Controllers
{
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IUserService userService;

        public RegistrationController(IUserService userService) => this.userService = userService;

        [HttpPost]
        [Produces("application/json")]
        public async Task<int> Register([FromBody] UserAddDto dto) => await userService.Add(dto);
    }
}
