using Coding.Challenge.Migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Challenge.Migration.Dtos.Country
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public List<Zone> TimeZones { get; set; } = new List<Zone>();
        public List<Currencies> Currencies { get; set; }
        public string Language { get; set; }
        public string CapitalCity { get; set; }
        public List<GetCountryDto> BorderingCoutries { get; set; } = null;
    }
}
