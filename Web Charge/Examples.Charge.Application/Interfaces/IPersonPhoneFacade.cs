using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneListResponse> FindAllAsync();
        Task<PersonPhoneListResponse> FindByPersonIdAsync(int id);
        Task<PersonPhoneResponse> UpdateAsync(PersonPhoneDto oldPersonPhone, PersonPhoneDto newPersonPhone);
        Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhone);
        Task<PersonPhoneResponse> RemoveAsync(PersonPhoneDto personPhone);
    }
}
