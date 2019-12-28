using ModelFirstDatabaseusingEntitytest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Services
{
    public interface ISiteRepository
    {
        ICollection<ParkingSite> GetSites();
        ParkingSite GetParkingSite(string Id);
        ICollection<ParkingArea> GetParkingAreasofSite(string siteId);
    }
}
