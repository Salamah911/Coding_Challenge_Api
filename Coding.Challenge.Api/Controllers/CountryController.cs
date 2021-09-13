using Coding.Challenge.Migration.Dtos.Country;
using Coding.Challenge.Migration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding.Challenge.Migration.Services;
using Coding.Challenge.Migration.Services.CountryService;

namespace Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCountryDto>>>> GetAllCountries()
        {
            return Ok(await _countryService.getAllCountries());
        }

        [HttpPost("AddCountry")]
        public async Task<ActionResult<ServiceResponse<List<GetCountryDto>>>> AddCountry(AddCountryDto newCountry)
        {
            return Ok(await _countryService.AddCountry(newCountry));
        }

        [HttpPut("UpdateCountry")]
        public async Task<ActionResult<ServiceResponse<GetCountryDto>>> UpdateCountry(UpdateCountryDto updateCountry)
        {
            var serviceResponse = await _countryService.UpdateCountry(updateCountry);
            if (serviceResponse.Success == true)
                return Ok(serviceResponse);
            return NotFound(serviceResponse);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<ActionResult<ServiceResponse<List<GetCountryDto>>>> DeleteCountry(int id)
        {
            var serviceResponse = await _countryService.DeleteCountry(id);
            if (serviceResponse.Success == true)
                return Ok(serviceResponse);
            return NotFound(serviceResponse);
            
        }

        [HttpGet("GetCountry")]
        public async Task<ActionResult<ServiceResponse<GetCountryDto>>> GetCountry(int id)
        {
            var serviceResponse = await _countryService.getCountry(id);
            if (serviceResponse.Success == true)
                return Ok(serviceResponse);
            return NotFound(serviceResponse);
        }
    }
}
