using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() 
        {
            try
            {
                return await Task.Run(() => _context.Person);
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
                return await Task.Run(() => _context.Person.FirstOrDefault(x => x.BusinessEntityID == id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
