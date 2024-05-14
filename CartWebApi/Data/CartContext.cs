using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CartWebApi.Data
{
    public class CartContext:DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
