/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VirtualSuggestionBoxApi.Models;
using VirtualSuggestionBoxApi.Storages;

namespace VirtualSuggestionBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {

        MongoDBStorage<Suggestion> _db;
        public SuggestionController()
        {
            _db = new MongoDBStorage<Suggestion>();
        }

        //  GET: api/Suggestion
        // [HttpGet]
        public IEnumerable<Suggestion> Get()
        {

            return _db.GetAll();
        }


        // GET: api/Suggestion/5
        [HttpGet("{id}")]
        public ObjectResult Get(ObjectId id)
        {
            var suggestion = _db.Get(id);
            if (suggestion == null)
            {
                return NotFound("not found!");
            }
            return new ObjectResult(suggestion);
        }

        // POST: api/Suggestion
        [HttpPost]
        public IActionResult Post([FromBody] Suggestion a)
        {
            _db.Create(a);
            return new OkObjectResult(a);

        }

        // PUT: api/Suggestion/5
        [HttpPut("{id}")]
        public IActionResult Put(ObjectId id, [FromBody] Suggestion a)
        {
            var recId = id;
            var suggestion = _db.Get(recId);
            if (suggestion == null)
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
            var suggestion = _db.Get(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            _db.Remove(suggestion.Id);
            return new OkResult();

        }

    }
}
*/