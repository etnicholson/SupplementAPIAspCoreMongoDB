using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementCRUDAPI.Models;
using SupplementCRUDAPI.Services;

namespace SupplementCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplementController : ControllerBase
    {
        private readonly SupplementService _supplementService;

        public SupplementController(SupplementService supplementService)
        {
            _supplementService = supplementService;
        }
        // GET: api/Supplement
        [HttpGet]
        public ActionResult<List<Supplement>> Get()
        {
            return _supplementService.Get();
        }

        // GET: api/Supplement/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Supplement> Get(string id)
        {
            var s = _supplementService.Get(id);
            if(s == null)
            {
                return NotFound();
            }

            return s;
        }



        // POST: api/Supplement
        [HttpPost]
        public ActionResult<Supplement> Create([FromBody] Supplement s)
        {
            _supplementService.Create(s);
            return CreatedAtRoute("Get", new { id = s.Id.ToString() }, s);

        }

        // PUT: api/Supplement/5
        [HttpPut("{id}")]
        public ActionResult<Supplement> Put(string id, [FromBody] Supplement su)
        {
            var s = _supplementService.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            su.Id = s.Id;

            _supplementService.Update(id, su);
            return CreatedAtRoute("Get", new { id = su.Id.ToString() }, su);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Supplement> Delete(string id)
        {
            var s = _supplementService.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            _supplementService.Remove(s.Id);
            return NoContent();

        }
    }
}
