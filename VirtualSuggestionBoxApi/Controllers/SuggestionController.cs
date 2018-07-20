﻿
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
            Suggestion s8 = new Suggestion("improv8", "sol8", "emp8");
            Suggestion s9 = new Suggestion("improv9", "sol9", "emp9");
            Suggestion s10 = new Suggestion("improv10", "sol10", "emp10");
            Suggestion s11 = new Suggestion("improv11", "sol11", "emp11");
            Suggestion s12 = new Suggestion("improv12", "sol12", "emp12");
            Suggestion s13 = new Suggestion("improv13", "sol13", "emp13");

            return new List<Suggestion> { s8, s9, s10, s11, s12, s13 };
            //return _db.GetAll();
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
