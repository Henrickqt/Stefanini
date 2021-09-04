using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneNumberTypeResponse : BaseResponse
    {
        public PhoneNumberTypeDto PhoneNumberTypeObject { get; set; }
    }
}
