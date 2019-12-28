using Microsoft.AspNetCore.Mvc;
using ModelFirstDatabaseusingEntitytest.DTOs;
using ModelFirstDatabaseusingEntitytest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelFirstDatabaseusingEntitytest.Controllers
{
    [Route("api/Sites")]
    [ApiController]
    public class SitesController:Controller
    {
        private ISiteRepository _siteRespository;
        public SitesController(ISiteRepository siteRepository)
        {
            _siteRespository = siteRepository;
        }
        //api/sites
        [HttpGet]
        public IActionResult Sites()
        {
            var sites = _siteRespository.GetSites().ToList();
            var siteDtos = new List<SiteDTO>();
            foreach (var site in sites)
            {
                var siteDto = new SiteDTO
                {
                    SiteRef = site.Parm1,
                    MonitoringCompany = site.API,
                    NoOfSpaces = (int)site.NumberOfSpaces
                };
                siteDtos.Add(siteDto);
            }
            var areas = _siteRespository.GetParkingAreasofSite("l14");
            return Ok(siteDtos);
        }
    }
}
