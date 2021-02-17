using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices
{
    [Route("api/driver")]
    public class DriverController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public List<Driver> Get()
        {
            DBtools d = new DBtools();
            return d.getDriversObj();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Driver Get(string id)
        {
            DBtools d = new DBtools();
            return d.getDriver(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
