using Microsoft.EntityFrameworkCore;
using Marchandises.Models;

namespace Marchandises.Data
{
    public class ProductDbContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Products> Produits { get; set;}
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options){ }

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Products>(entity =>{
        //         entity.HasKey(e => e.Id);
        //         entity.ToTable("produit");}
        //     );
        }
        
    
}
