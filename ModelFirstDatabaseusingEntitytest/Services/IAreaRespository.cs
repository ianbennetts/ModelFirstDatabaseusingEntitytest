using ModelFirstDatabaseusingEntitytest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Services
{
    public interface IAreaRespository
    {
        ICollection<ParkingSite> GetAreaSites(string area);
 
    }
}
