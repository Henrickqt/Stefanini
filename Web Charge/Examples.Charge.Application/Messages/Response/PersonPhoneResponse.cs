using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonPhoneResponse : BaseResponse
    {
        public PersonPhoneDto PersonPhoneObject { get; set; }
    }
}
