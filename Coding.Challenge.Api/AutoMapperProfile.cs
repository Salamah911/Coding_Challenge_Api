using AutoMapper;
using Coding.Challenge.Migration.Dtos.Country;
using Coding.Challenge.Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, GetCountryDto>();
            CreateMap<AddCountryDto, Country>();
        }
    }
}
