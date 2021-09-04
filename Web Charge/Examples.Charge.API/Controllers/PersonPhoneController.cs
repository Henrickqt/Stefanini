using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get() => 
            Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneListResponse>> GetByPersonId([FromRoute] int id) => 
            Response(await _facade.FindByPersonIdAsync(id));

        [HttpPut("person/{BusinessEntityID:int}/phonenumber/{PhoneNumber}/phonenumbertype/{PhoneNumberTypeID:int}")]
        public async Task<ActionResult<PersonPhoneListResponse>> Put(
            [FromRoute] int businessEntityID,
            [FromRoute] string phoneNumber,
            [FromRoute] int phoneNumberTypeID,
            [FromBody] PersonPhoneDto newPersonPhone
        ) => 
            Response(await _facade.UpdateAsync(
                new PersonPhoneDto 
                { 
                    BusinessEntityID = businessEntityID, 
                    PhoneNumber = phoneNumber, 
                    PhoneNumberTypeID = phoneNumberTypeID 
                }, 
                newPersonPhone
            ));

        [HttpPost]
        public async Task<ActionResult<PersonPhoneListResponse>> Post([FromBody] PersonPhoneDto personPhone) => 
            Response(await _facade.AddAsync(personPhone));

        [HttpDelete("person/{BusinessEntityID:int}/phonenumber/{PhoneNumber}/phonenumbertype/{PhoneNumberTypeID:int}")]
        public async Task<ActionResult<PersonPhoneListResponse>> Delete(
            [FromRoute] int businessEntityID,
            [FromRoute] string phoneNumber,
            [FromRoute] int phoneNumberTypeID
        ) => 
            Response(await _facade.RemoveAsync(
                new PersonPhoneDto 
                { 
                    BusinessEntityID = businessEntityID, 
                    PhoneNumber = phoneNumber, 
                    PhoneNumberTypeID = phoneNumberTypeID 
                }
            ));
    }
}
