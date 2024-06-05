using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Marchandises.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom est requis")]
        [StringLength(100, ErrorMessage = "Nom trop long")]
        public string Nom {get;set;}
        [Required(ErrorMessage ="Le numéro de téléphone est requis")]
        public string Telephone {get;set;}

        public Client(){
            Nom = "";
            Telephone = "";
        }

        //public Client(string nom, string telephone)
        //{
        //    Nom = nom;
        //    Telephone = telephone;
        //}

        //public Client(int id, string nom, string telephone)
        //{
        //    Id = id;
        //    Nom = nom;
        //    Telephone = telephone;
        //}
    }
}