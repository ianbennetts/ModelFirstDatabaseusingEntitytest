using ModelFirstDatabaseusingEntitytest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Services
{
    public class AreaRepository : IAreaRespository
    {
        private ParkingSiteDbContext _parkingSiteDbContext;
        public AreaRepository(ParkingSiteDbContext parkingContext)
        {
            _parkingSiteDbContext = parkingContext;
        }
        public ICollection<ParkingSite> GetAreaSites(string area)
        {
            var a = _parkingSiteDbContext.ParkingAreas.Where(x => x.AreaName == area).FirstOrDefault();
          //  var t = a.SiteAreas.ToList();
            throw new NotImplementedException();
        }
    }
}
