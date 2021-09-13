using Coding.Challenge.Migration.Dtos.Country;
using Coding.Challenge.Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Challenge.Migration.Services.CountryService
{
    public interface ICountryService
    {
        Task<ServiceResponse<List<GetCountryDto>>> getAllCountries();
        Task<ServiceResponse<GetCountryDto>> getCountry(int Id);
        Task<ServiceResponse<List<GetCountryDto>>> AddCountry(AddCountryDto newCountry);
        Task<ServiceResponse<GetCountryDto>> UpdateCountry(UpdateCountryDto updateCountry);
        Task<ServiceResponse<List<GetCountryDto>>> DeleteCountry(int id);
    }
}
