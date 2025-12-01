using FHCampus02WebServices2025.Models;

namespace FHCampus02WebServices2025.Services
{
    public interface IPizzaService
    {
        List<Pizza> GetAll();
        Pizza? Get(int id);
        void Add(Pizza pizza);
        void Delete(int id);
        void Update(Pizza pizza);
    }
}
