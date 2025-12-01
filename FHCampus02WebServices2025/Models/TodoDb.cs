using Microsoft.EntityFrameworkCore;

namespace FHCampus02WebServices2025.Models
{

    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
