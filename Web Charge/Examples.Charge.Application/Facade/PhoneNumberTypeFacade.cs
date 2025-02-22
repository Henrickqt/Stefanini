﻿using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeListResponse> FindAllAsync()
        {
            try
            {
                var result = await _phoneNumberTypeService.FindAllAsync();

                var response = new PhoneNumberTypeListResponse();
                response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
                response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));

                return response;
            }
            catch (Exception ex)
            {
                return new PhoneNumberTypeListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PhoneNumberTypeResponse> FindAsync(int id)
        {
            try
            {
                var result = await _phoneNumberTypeService.FindAsync(id);

                var response = new PhoneNumberTypeResponse();
                response.PhoneNumberTypeObject = _mapper.Map<PhoneNumberTypeDto>(result);

                return response;
            }
            catch (Exception ex)
            {
                return new PhoneNumberTypeResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }
    }
}
