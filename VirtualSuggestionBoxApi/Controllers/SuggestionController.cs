
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VirtualSuggestionBoxApi.Models;
using VirtualSuggestionBoxApi.Repositories;
using VirtualSuggestionBoxApi.Storages;

namespace VirtualSuggestionBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private IStorage<Suggestion> _db;


        Suggestion s8 = new Suggestion("improv8", "sol8");
        Suggestion s9 = new Suggestion("improv9", "sol9");
        Suggestion s10 = new Suggestion("improv10", "sol10");
        Suggestion s11 = new Suggestion("improv11", "sol11");
        Suggestion s12 = new Suggestion("improv12", "sol12");
        Suggestion s13 = new Suggestion("improv13", "sol13");

        public SuggestionController(IStorage <Suggestion> _db)
        {
            this._db = _db;

        }

        //  GET: api/Suggestion
        private IEnumerable<Suggestion> Get()
        {

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


        [HttpGet("{topBestRated?}")]
        public IEnumerable<Suggestion> GetTop3([FromQuery]int? topBestRated = null)
        {

            s8.boostRateForTesting(1);
            s9.boostRateForTesting(123);
            s10.boostRateForTesting(134);
            s11.boostRateForTesting(332);

            if (topBestRated == null)
                return Get();
            return Get().OrderBy(x => x.GetAvgRate()).Take(topBestRated.Value);

        }

        // aici nu stiu exact cum trebuie definiti parametrii
        [HttpGet("{Categories} + {AvgRate}")]
        public IEnumerable<Suggestion> Search( List<String> Categories, double AvgRate )
        {

            IEnumerable<Suggestion> list = Get().Where( x => x.GetAvgRate() >= AvgRate );
            List<Suggestion> searchList = new List<Suggestion>();

            foreach (Suggestion suggestion in list)
            {
                foreach (String category in Categories)
                {
                    if (suggestion.Categories.Contains(category))
                    {
                        searchList.Add(suggestion);
                        break;
                    }
                }
            }

            return searchList;

        }


        // POST: api/Suggestion
        [HttpPost]
        public ActionResult Post(Suggestion a)
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
