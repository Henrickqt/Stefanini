using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() 
        {
            try
            {
                return await Task.Run(() => _context.PersonPhone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PersonPhone>> FindByPersonIdAsync(int id) 
        {
            try
            {
                return await Task.Run(() => _context.PersonPhone.Where(x => x.BusinessEntityID == id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonPhone> FindAsync(PersonPhone personPhone) 
        {
            try
            {
                return await Task.Run(() => _context.PersonPhone.FirstOrDefault(x =>
                    x.BusinessEntityID == personPhone.BusinessEntityID &&
                    x.PhoneNumber == personPhone.PhoneNumber &&
                    x.PhoneNumberTypeID == personPhone.PhoneNumberTypeID
                ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonPhone> UpdateAsync(PersonPhone personPhone) 
        {
            try
            {
                return await Task.Run(async () => 
                {
                    var result = _context.PersonPhone.Update(personPhone);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonPhone> AddAsync(PersonPhone personPhone)
        {
            try
            {
                return await Task.Run(async () => 
                {
                    var result = await _context.PersonPhone.AddAsync(personPhone);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonPhone> RemoveAsync(PersonPhone personPhone) 
        { 
            try
            {
                return await Task.Run(async () => 
                {
                    var result = _context.PersonPhone.Remove(personPhone);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
