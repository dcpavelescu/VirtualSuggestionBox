
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
        private IStorage<Suggestion> _db;

        public SuggestionController(IStorage <Suggestion> _db)
        {
            this._db = _db;
        }

        //  GET: api/Suggestion
        // [HttpGet]
        public IEnumerable<Suggestion> Get()
        {
            return _db.GetAll();
        }


        // GET: api/Suggestion/5
        [HttpGet("{id}")]
        public Suggestion Get(String id)
        {
            var suggestion = _db.Get(id);
            return suggestion;
        }

        // POST: api/Suggestion
        [HttpPost]
        public ActionResult Post([FromBody] Suggestion a)
        {
            _db.Add(a);
            return Ok();
        }

        // PUT: api/Suggestion/5
        [HttpPut("{id}")]
        public ActionResult Put(String id, [FromBody] Suggestion a)
        {
            var recId = id;
            var suggestion = _db.Get(recId);
            if (suggestion == null)
            {
                return NotFound();
            }

            //BETA _db.Update(recId, a);
            _db.Update(a);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            var suggestion = _db.Get(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            _db.Remove(suggestion.Id);
            return Ok();
        }

    }
}
