using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UHappeningServices.Models;

namespace UHappeningServices.Controllers
{
    public class SampleController : ApiController
    {
        // GET: api/Sample
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sample/5
        public string Get(int id)
        {
            return "value " +id;
        }

        // POST: api/Sample
        public bool Post([FromBody]Events value)
        {
            EventHandling eh = new EventHandling();
            bool result = eh.createEvent(value);
            return result;

        }

        // PUT: api/Sample/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sample/5
        public void Delete(int id)
        {
        }
    }
}
