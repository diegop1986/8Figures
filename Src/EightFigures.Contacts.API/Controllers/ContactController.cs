using Microsoft.AspNetCore.Mvc;
using EightFigures.Contacts.Service.Dto;
using Microsoft.AspNetCore.Authorization;
using EightFigures.Contacts.Service.Interface;

namespace EightFigures.Contacts.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService) => this.contactService = contactService;

        [HttpPost]
        [Produces("application/json")]
        public async Task Add([FromBody]ContactAddDto dto) => await contactService.Add(dto);


        [HttpPut]
        [Produces("application/json")]
        public async Task Upd([FromBody] ContactUpdDto dto) => await contactService.Upd(dto);


        [HttpDelete]
        [Produces("application/json")]
        public async Task Del([FromBody] ContactDelDto dto) => await contactService.Del(dto);


        [HttpGet]
        [Produces("application/json")]
        public async Task<IEnumerable<ContactInfoDto>> Get([FromQuery] ContactGetDto dto) => await contactService.Get(dto);
    }
}
