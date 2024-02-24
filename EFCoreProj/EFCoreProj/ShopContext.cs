using EFCoreProj.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProj
{
	public class ShopContext : DbContext
	{
        public DbSet<Product> Products{ get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }
    }
}
