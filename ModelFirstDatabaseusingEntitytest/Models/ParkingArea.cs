using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Models
{
    public class ParkingArea
    {
        public int Id { get; set; }
        public string AreaName { get; set; }

        public virtual ICollection<SiteArea> SiteAreas { get; set; }  // virtual for lazy loading
    }
}
