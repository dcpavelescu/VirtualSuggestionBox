using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        MongoContext _dbContext;
        public AccountController()
        {
            _dbContext = new MongoContext();
        }

       //  GET: api/Account
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            var response = new List<Account>();
            var user = Builders<Account>.Filter.Eq(x => x.username, "rares");
            var pw = Builders<Account>.Filter.Eq(x => x.password, "test");
            var query = Builders<Account>.Filter.Or(user, pw);
            var AccountDetails =await  _dbContext._database.GetCollection<Account>("Account").FindAsync(query);//;.Result.ToList(); //.GetCollection("Dd").ToList();
                                                                                                                                       //  if (AccountDetails.Id == null)
                                                                                                                                       //       AccountDetails.Id = ObjectId.GenerateNewId().ToString();

            // AccountDetails.ReplaceOneAsync(x => x.Id.Equals(suggestion.Id), suggestion, new UpdateOptions
            //  {
            //      IsUpsert = true
            //  });
            while (await AccountDetails.MoveNextAsync())
            {
                response.AddRange(AccountDetails.Current);
            }

            return response;
            //return AccountDetails;
        }


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
