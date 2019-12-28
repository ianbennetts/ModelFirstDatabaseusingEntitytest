using ModelFirstDatabaseusingEntitytest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Services
{
    public class SiteRepository : ISiteRepository
    {
        private ParkingSiteDbContext _parkingSiteDbContext;
        public SiteRepository(ParkingSiteDbContext parkingContext)
        {
            _parkingSiteDbContext = parkingContext;
        }
        public ICollection<ParkingArea> GetParkingAreasofSite(string siteId)
        {
            var ps = _parkingSiteDbContext.ParkingSite.Where(x => x.Parm1 == siteId).FirstOrDefault();
            if (ps == null) return null;
            int psId = ps.Id;
 //           var t = ps.SiteArea;
            var listOfAreaIds = _parkingSiteDbContext.SiteArea.Where(x => x.SiteId == psId).ToList();
            ICollection<ParkingArea> returnVal = new List<ParkingArea>();
            foreach (var areaId in listOfAreaIds)
            {
                var area = _parkingSiteDbContext.ParkingAreas.Where(x => x.Id == areaId.AreaId).FirstOrDefault();
                returnVal.Add(area);
            }
            return returnVal;



        }

        public ParkingSite GetParkingSite(string Id)
        {
            return _parkingSiteDbContext.ParkingSite.Where(a => a.Parm1 == Id).FirstOrDefault();
        }

        public ICollection<ParkingSite> GetSites()
        {
            return _parkingSiteDbContext.ParkingSite.OrderBy(p => p.Parm1).ToList();
        }
    }
}
