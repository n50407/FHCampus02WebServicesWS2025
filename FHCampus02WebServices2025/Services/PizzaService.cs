using FHCampus02WebServices2025.Models;
using System.Xml.Linq;

namespace FHCampus02WebServices2025.Services
{
        public class PizzaService : IPizzaService
        {
            private readonly List<Pizza> _pizzas;
            private int _nextId;

            public PizzaService()
            {
                _pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false, Kalorien = 850 },
                new Pizza { Id = 2, Name = "Veggie",          IsGlutenFree = true,  Kalorien = 620 }
            };

                _nextId = 3;
            }

            public List<Pizza> GetAll() => _pizzas;

            public Pizza? Get(int id) => _pizzas.FirstOrDefault(p => p.Id == id);

            public void Add(Pizza pizza)
            {
                pizza.Id = _nextId++;
                _pizzas.Add(pizza);
            }

            public void Delete(int id)
            {
                var pizza = Get(id);
                if (pizza is null)
                    return;

                _pizzas.Remove(pizza);
            }

            public void Update(Pizza pizza)
            {
                var index = _pizzas.FindIndex(p => p.Id == pizza.Id);
                if (index == -1)
                    return;

                _pizzas[index] = pizza;
            }

        public void Suche()
        {
            _pizzas.Where(p => p.Kalorien < 700).ToList();
        }
        }
    }
