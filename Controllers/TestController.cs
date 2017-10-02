using MeteorologyDownloader.DataRetrieval;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeteorologyDownloader.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IMeteoDataDownloader _meteoDataDownloader;

        public TestController(
            IMeteoDataDownloader meteoDataDownloader)
        {
            _meteoDataDownloader = meteoDataDownloader;
        }

        // GET api/values
        [HttpGet]
        public void Get()
        {
            _meteoDataDownloader.LoadRadarData(Path.Combine(Directory.GetCurrentDirectory(), "output"), 15, 5);
        }
    }
}
