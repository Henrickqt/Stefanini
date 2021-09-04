using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PhoneNumberTypeRepository : IPhoneNumberTypeRepository
    {
        private readonly ExampleContext _context;

        public PhoneNumberTypeRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllAsync()
        {
            try
            {
                return await Task.Run(() => _context.PhoneNumberType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PhoneNumberType> FindAsync(int id)
        {
            try
            {
                return await Task.Run(() => _context.PhoneNumberType.FirstOrDefault(x => x.PhoneNumberTypeID == id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
