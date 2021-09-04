using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private IPersonPhoneService _personPhoneService;
        private IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            try
            {
                var result = await _personPhoneService.FindAllAsync();

                var response = new PersonPhoneListResponse();
                response.PersonPhoneObjects = new List<PersonPhoneDto>();
                response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
                
                return response;
            }
            catch (Exception ex)
            {
                return new PersonPhoneListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneListResponse> FindByPersonIdAsync(int id)
        {
            try
            {
                var result = await _personPhoneService.FindByPersonIdAsync(id);

                var response = new PersonPhoneListResponse();
                response.PersonPhoneObjects = new List<PersonPhoneDto>();
                response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));

                return response;
            }
            catch (Exception ex)
            {
                return new PersonPhoneListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneResponse> UpdateAsync(PersonPhoneDto oldPersonPhone, PersonPhoneDto newPersonPhone)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(oldPersonPhone));

                if (personPhoneFound == null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "PersonPhone does not exist." } };

                newPersonPhone.BusinessEntityID = personPhoneFound.BusinessEntityID;
                var personPhoneRemoved = await _personPhoneService.RemoveAsync(personPhoneFound);
                var personPhoneAdded = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(newPersonPhone));

                //Doubts why this approach does not work when update a key field
                //personPhoneFound.PhoneNumber = newPersonPhone.PhoneNumber;
                //personPhoneFound.PhoneNumberTypeID = newPersonPhone.PhoneNumberTypeID;
                //var personPhoneUpdated = await _personPhoneService.UpdateAsync(personPhoneFound);

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneAdded) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhone)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(personPhone));

                if (personPhoneFound != null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "PersonPhone already exists." } };

                var personPhoneAdded = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(personPhone));

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneAdded) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneResponse> RemoveAsync(PersonPhoneDto personPhone)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(personPhone));

                if (personPhoneFound == null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "PersonPhone does not exist." } };

                var personPhoneRemoved = await _personPhoneService.RemoveAsync(personPhoneFound);

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneRemoved) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }
    }
}
