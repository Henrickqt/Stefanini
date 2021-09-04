using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> FindAllAsync() 
        {
            try
            {
                return (await _personRepository.FindAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> FindAsync(int id)
        {
            try
            {
                return await _personRepository.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
