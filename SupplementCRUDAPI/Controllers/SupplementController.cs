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
        public async Task<ActionResult<List<Supplement>>> Get()
        {
            return await _supplementService.Get();
        }

        // GET: api/Supplement/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Supplement>> Get(string id)
        {
            var s = await _supplementService.Get(id);
            if(s == null)
            {
                return NotFound();
            }

            return s;
        }



        // POST: api/Supplement
        [HttpPost]
        public async Task<ActionResult<Supplement>> Create([FromBody] Supplement s)
        {
            await _supplementService.Create(s);
            return CreatedAtRoute("Get", new { id = s.Id.ToString() }, s);

        }

        // PUT: api/Supplement/5
        [HttpPut("{id}")]
        public  async Task<ActionResult<Supplement>> Put(string id, [FromBody] Supplement su)
        {
            var s = await _supplementService.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            su.Id = s.Id;

            await _supplementService.Update(id, su);
            return CreatedAtRoute("Get", new { id = su.Id.ToString() }, su);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplement>> Delete(string id)
        {
            var s = await _supplementService.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            _supplementService.Remove(s.Id);
            return NoContent();

        }
    }
}
