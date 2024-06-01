using Marchandises.Components.Pages;
using Marchandises.Models;

namespace Marchandises.Service
{
    public interface IProduitService
    {
        Task<List<Products>> GetProduitsAsync();
        Task<Products> GetProduitByIdAsync(int id);
        Task AddProduitAsync(Products produit);
        Task UpdateProduitAsync(Products produit);
        Task DeleteProduitAsync(int id);
    }
}
