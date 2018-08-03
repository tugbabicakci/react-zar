using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {
            
        }
        public DbSet<Costumer> costumers { get; set; }
    }
}
