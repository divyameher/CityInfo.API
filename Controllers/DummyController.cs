using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.API.Controllers
{
    public class DummyController : Controller
    {
        private CityInfoContext _ctx;
        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}