using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Marchandises.Models
{
    public class Utilisateur:IdentityUser
    {
        [Required(ErrorMessage ="Le nom est obligatoire")]
        public string Nom { get; set; }
        public string? Genre { get; set; }

    }
}
