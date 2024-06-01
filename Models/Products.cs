using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Marchandises.Models
{
    [Table("produit")]
    public class Products
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Le nom produit est trop long")]
        public string Nom { get; set; }
        [Required]
        public decimal Prix { get; set; } 
    // ... autres propriétés du produit
    public Products() { }
    public Products(int id, string nom, decimal prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}