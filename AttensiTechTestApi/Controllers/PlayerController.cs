using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttensiTechTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        // GET: api/Player
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            //get player
            throw new NotImplementedException();
        }

        // POST: api/Player
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //post new player
            throw new NotImplementedException();
        }
    }
}
