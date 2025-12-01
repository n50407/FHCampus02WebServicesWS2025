using FHCampus02WebServices2025.Configuration;
using FHCampus02WebServices2025.Models;
using FHCampus02WebServices2025.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FHCampus02WebServices2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        private PizzaService myPizzaService = new PizzaService();



        private readonly IPizzaService _pizzaService;
        private readonly OrderSettings _orderSettings;

        public PizzaController(
              IPizzaService pizzaService,
              IOptions<OrderSettings> orderSettings)
        {
            _pizzaService = pizzaService;
            _orderSettings = orderSettings.Value;
        }

        // GET: api/pizza
        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetAll()
        {
           
            var pizzas = _pizzaService.GetAll();
            return Ok(pizzas);
        }

        // GET: api/pizza/5
        [HttpGet("{id:int}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = _pizzaService.Get(id);
            if (pizza is null)
                return NotFound();

            return Ok(pizza);
        }

        // POST: api/pizza
        [HttpPost]
        /// Hello World
        public ActionResult Create([FromBody] Pizza pizza)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            _pizzaService.Add(pizza);

            // Antwort-Objekt mit Message + Daten
            var responseBody = new
            {
                Message = _orderSettings.ThankYouMessage,
                Pizza = pizza
            };

            return CreatedAtAction(
                nameof(Get),
                new { id = pizza.Id },
                responseBody
            );
        }

        // PUT: api/pizza/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Pizza pizza)
        {
            
            if (id != pizza.Id)
                return BadRequest("Id in URL und Body unterscheiden sich.");

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var existing = _pizzaService.Get(id);
            if (existing is null)
                return NotFound();

            _pizzaService.Update(pizza);
            return NoContent();
        }

        // DELETE: api/pizza/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = _pizzaService.Get(id);
            if (existing is null)
                return NotFound();

            _pizzaService.Delete(id);
            return NoContent();
        }

        [HttpGet("AnzahlPizzen/{bezeichnung}")]
        public IActionResult GetCountOf(string bezeichnung)
        {
          var result = _pizzaService.GetAll().Where(p=>p.Name == bezeichnung);
          return Ok($"Anzahl von {bezeichnung} Pizzen ist {result.Count().ToString()}");
        }
    }
}
