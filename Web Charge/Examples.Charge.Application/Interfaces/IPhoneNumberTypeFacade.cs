﻿using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneNumberTypeFacade
    {
        Task<PhoneNumberTypeListResponse> FindAllAsync();
        Task<PhoneNumberTypeResponse> FindAsync(int id);
    }
}
