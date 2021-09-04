using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;

        public PersonPhoneService(
            IPersonRepository personRepository, 
            IPersonPhoneRepository personPhoneRepository, 
            IPhoneNumberTypeRepository phoneNumberTypeRepository
        )
        {
            _personRepository = personRepository;
            _personPhoneRepository = personPhoneRepository;
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() 
        {
            try
            {
                return (await _personPhoneRepository.FindAllAsync()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PersonPhone>> FindByPersonIdAsync(int id) 
        {
            try
            {
                return (await _personPhoneRepository.FindByPersonIdAsync(id)).ToList();
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
                return await _personPhoneRepository.FindAsync(personPhone);
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
                return await _personPhoneRepository.UpdateAsync(personPhone);
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
                personPhone.Person = await _personRepository.FindAsync(personPhone.BusinessEntityID);
                personPhone.PhoneNumberType = await _phoneNumberTypeRepository.FindAsync(personPhone.PhoneNumberTypeID);
                return await _personPhoneRepository.AddAsync(personPhone);
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
                return await _personPhoneRepository.RemoveAsync(personPhone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
