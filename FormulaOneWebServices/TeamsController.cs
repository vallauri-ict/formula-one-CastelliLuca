using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOneWebServices
{
    [Route("api/team")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public List<Teams> Get()
        {
            DBtools d = new DBtools();
            return d.getTeamsObj();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Teams Get(string teamCode)
        {
            DBtools d = new DBtools();
            return d.getTeam(teamCode);
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
