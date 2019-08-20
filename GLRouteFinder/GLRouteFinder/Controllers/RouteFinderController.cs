using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GLRouteFinder;
using Microsoft.Extensions.Options;

namespace GLRouteFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteFinderController : ControllerBase
    {
        
        private readonly IRouterFinder routerFinder;
        private readonly IOptions<ConnectionStrings> _appSettings;
        public RouteFinderController(IRouterFinder _routerFinder,IOptions<ConnectionStrings> appsettings) {
            routerFinder = _routerFinder;
            _appSettings = appsettings;
        }

        [HttpGet("SearchRoute")]
        public  IActionResult SearchRoute(string origin, string destination)
        {
            var data = routerFinder.GetShortestPath(origin, destination);
            
            return Ok(data);
            
        }
       

        

       
    }
}
