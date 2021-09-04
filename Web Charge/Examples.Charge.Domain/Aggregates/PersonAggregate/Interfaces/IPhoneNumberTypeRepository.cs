using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeRepository
    {
        Task<IEnumerable<PersonAggregate.PhoneNumberType>> FindAllAsync();
        Task<PhoneNumberType> FindAsync(int id);
    }
}
