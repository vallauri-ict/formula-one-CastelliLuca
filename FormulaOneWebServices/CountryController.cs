using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            DBtools d = new DBtools();
            return d.getCountriesObj();
        }

        // GET: api/Country/5
        [HttpGet("{IsoCode}", Name = "Get")]
        public Country Get(string IsoCode)
        {
            DBtools d = new DBtools();
            return d.getCountry(IsoCode);
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
