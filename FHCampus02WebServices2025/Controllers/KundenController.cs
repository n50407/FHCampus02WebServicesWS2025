using FHCampus02WebServices2025.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FHCampus02WebServices2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundenController : ControllerBase
    {
        static List<Kunde> meineKunden = new List<Kunde>();




        // GET: api/<KundenController>
        [HttpGet]
        public IEnumerable<Kunde> Get()
        {
            return meineKunden;
        }

        // GET api/<KundenController>/5
        [HttpGet("{id}")]
        public Kunde Get(int id)
        {
            return meineKunden.Where(k => k.KundenId == id).FirstOrDefault();
        }

        // POST api/<KundenController>
        [HttpPost]
        public void Post([FromBody] Kunde neuerKunde)
        {
            meineKunden.Add(neuerKunde);
        }

        // PUT api/<KundenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KundenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            meineKunden.Remove(meineKunden.Where(k => k.KundenId == id).FirstOrDefault());
        }

        [HttpGet]
        [Route("MaxPunkte")]
        public int GetMaxPunkte()
        {
            return meineKunden.Max(k => k.Punkte);
        }
    }
}
