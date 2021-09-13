using AutoMapper;
using Coding.Challenge.Migration.Dtos.Country;
using Coding.Challenge.Migration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Challenge.Migration.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CountryService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCountryDto>>> AddCountry(AddCountryDto newCountry)
        {
            var serviceResponse = new ServiceResponse<List<GetCountryDto>>();
            Country country = _mapper.Map<Country>(newCountry);
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Countries.Select(country => _mapper.Map<GetCountryDto>(country)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCountryDto>>> DeleteCountry(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCountryDto>>();
            Country country = await _context.Countries.FirstOrDefaultAsync(country => country.Id == Id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                var dbCountries = await _context.Countries.ToListAsync();
                serviceResponse.Data = dbCountries.Select(c => _mapper.Map<GetCountryDto>(c)).ToList();    
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCountryDto>>> getAllCountries()
        {
            var serviceResponse = new ServiceResponse<List<GetCountryDto>>();
            var dbCountries = await _context.Countries.ToListAsync();
            serviceResponse.Data = dbCountries.Select(c => _mapper.Map<GetCountryDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCountryDto>> getCountry(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCountryDto>();
            Country country = await _context.Countries.FirstOrDefaultAsync(country => country.Id == Id);
            if (country != null)
            {
                serviceResponse.Data = _mapper.Map<GetCountryDto>(country);
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCountryDto>> UpdateCountry(UpdateCountryDto updateCountry)
        {
            var serviceResponse = new ServiceResponse<GetCountryDto>();
            try
            {
                Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == updateCountry.Id);
                if (country != null)
                {
                    country.Name = updateCountry.Name;
                    country.Population = updateCountry.Population;
                    country.Language = updateCountry.Language;
                    country.TimeZones = updateCountry.TimeZones;
                    country.CapitalCity = updateCountry.CapitalCity;
                    country.Currencies = updateCountry.Currencies;
                    country.Flag = updateCountry.Flag;
                    country.BorderingCoutries = updateCountry.BorderingCoutries.Select(c => _mapper.Map<Country>(c)).ToList();
                    await _context.SaveChangesAsync();
                }

                serviceResponse.Data = _mapper.Map<GetCountryDto>(country);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }
            if (serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }
            return serviceResponse;
        }
    }
}
