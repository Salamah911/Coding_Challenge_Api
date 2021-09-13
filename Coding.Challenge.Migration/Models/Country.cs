using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coding.Challenge.Migration.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public int Population { get; set; }
        public List<Zone> TimeZones { get; set; } = new List<Zone>();
        public List<Currencies> Currencies { get; set; } 
        public string Language { get; set; }
        public string CapitalCity { get; set; }
        public List<Country> BorderingCoutries { get; set; } = null;
    }

    public class Zone
    { 
        public int Id { get; set; }
        public DateTimeOffset TimeZone { get; set; }
    }
  
}

  
