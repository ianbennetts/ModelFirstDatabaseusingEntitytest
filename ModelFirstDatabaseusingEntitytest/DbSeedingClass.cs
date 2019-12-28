using ModelFirstDatabaseusingEntitytest.Models;
using ModelFirstDatabaseusingEntitytest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest
{
    public static class DbSeedingClass
    {
        public static void SeedDataContext(this ParkingSiteDbContext context)
        {
            string[] valueLines = System.IO.File.ReadAllLines(@"e:\Value1.CSV");

            var parkingSites = new List<ParkingSite>();
            foreach (var line in valueLines)
            {
                var column = line.Split(',');
                int i = -1;
                Int32.TryParse(column[5], out i);
                ParkingSite p = new ParkingSite
                {
                    Parm1 = column[1],
                    Parm2 = column[2],
                    Parm3 = column[3],
                    API = column[4],
                    NumberOfSpaces = i
                };
                parkingSites.Add(p);
            }
            context.AddRange(parkingSites);
            context.SaveChanges();
            var siteLines = System.IO.File.ReadAllLines(@"e:\Key1.CSV");
            var siteAreaKeys = new List<SiteArea>();
            foreach (var line in siteLines)
            {
                int areaId;
                var column = line.Split(',');
                var parkingArea = new ParkingArea
                {
                    AreaName = column[1]
                };
                context.Add(parkingArea);
                context.SaveChanges();
                var area = context.ParkingAreas.Where(pa => pa.AreaName == parkingArea.AreaName).FirstOrDefault();
                if (area != null) areaId = area.Id; else areaId = 0; ;
                var sites = column[3].Split(' ');
                foreach (var site in sites)
                {

                    int i = Int32.Parse(site);
                    string[] siteLine = valueLines[i - 1].Split(',');
                    string sitesId = siteLine[1];
                    var aSite = context.ParkingSite.Where(s => s.Parm1 == sitesId).FirstOrDefault();
                    if (aSite != null && areaId != 0)
                    {
                        var siteArea = new SiteArea();
                        siteArea.AreaId = areaId;
                        siteArea.SiteId = aSite.Id;
                        context.Add(siteArea);
                        context.SaveChanges();
                    }
                    int z = 0;
                }

            }
            //           context.AddRange(parkingAreas);
            //          context.SaveChanges();
            int y = 0;


        }

    }
}