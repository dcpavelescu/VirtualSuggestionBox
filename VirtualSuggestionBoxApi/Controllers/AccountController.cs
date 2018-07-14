using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        MongoContext _dbContext;
        public AccountController()
        {
            _dbContext = new MongoContext();
        }

        // GET: api/Account
      //  [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        var AccountDetails = _dbContext._database.GetCollection<Account>("Account"); //.GetCollection("Dd").ToList();
    //       return;
   //     }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        public void Post([FromBody] string value)
        {


        }

        // PUT: api/Account/5
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
