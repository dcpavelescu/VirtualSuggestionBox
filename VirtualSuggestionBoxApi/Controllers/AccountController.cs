using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using VirtualSuggestionBoxApi.Models;

namespace VirtualSuggestionBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        MongoDBStorage<Account> _db;
        public AccountController()
        {
            _db = new MongoDBStorage<Account>();
        }

       //  GET: api/Account
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            /*
            var response = new List<Account>();
            var user = Builders<Account>.Filter.Eq(x => x.username, "rares");
            var pw = Builders<Account>.Filter.Eq(x => x.password, "test");
            var query = Builders<Account>.Filter.Or(user, pw);
            var AccountDetails =await  _dbContext._database.GetCollection<Account>("Account").FindAsync(query);//;.Result.ToList(); //.GetCollection("Dd").ToList();
              ******* aici era inchis comentariu                                                                                                                     
            return _db.GetAll(); 
        }


        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public ObjectResult Get(ObjectId id)
        {
            var account = _db.Get(id);
            if (account == null)
            {
                return NotFound("not found!");
            }
            return new ObjectResult(account);
        }

        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody] Account a)
        {
            _db.Create(a);
            return new OkObjectResult(a);

        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public IActionResult Put(ObjectId id, [FromBody] Account a)
        {
            var recId = id;
            var account = _db.Get(recId);
            if (account == null)
            {
                return NotFound();
            }

            _db.Update(recId, a);
            return new OkResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(ObjectId id)
        {
            var account = _db.Get(id);
            if (account == null)
            {
                return NotFound();
            }

            _db.Remove(account.Id);
            return new OkResult();
        
        }
    }
}
*/