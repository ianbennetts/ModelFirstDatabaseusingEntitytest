using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Models
{
    public class SiteArea
    {
        public int SiteId { get; set; }
        public ParkingSite ParkingSite { get; set; }
        public int AreaId { get; set; }
        public ParkingArea ParkingArea { get; set; }
    }
}
