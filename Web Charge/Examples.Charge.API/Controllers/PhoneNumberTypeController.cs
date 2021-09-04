using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        private IPhoneNumberTypeFacade _facade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeListResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberTypeResponse>> Get(int id) => Response(await _facade.FindAsync(id));
    }
}
