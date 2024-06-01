using Marchandises.Data;
using Marchandises.Models;
using Microsoft.EntityFrameworkCore;
namespace Marchandises.Service
{
    public class ProductService : IProduitService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<List<Products>> GetProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<Products> GetProduitByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        public async Task AddProduitAsync(Products produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduitAsync(Products produit)
        {
            _context.Entry(produit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduitAsync(int id)
        {
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
