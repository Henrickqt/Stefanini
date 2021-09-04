using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonAggregate.Person>> FindAllAsync();
        Task<Person> FindAsync(int id);
    }
}
