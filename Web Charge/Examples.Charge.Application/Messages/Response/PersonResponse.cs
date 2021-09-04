using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonResponse : BaseResponse
    {
        public PersonDto PersonObject { get; set; }
    }
}
