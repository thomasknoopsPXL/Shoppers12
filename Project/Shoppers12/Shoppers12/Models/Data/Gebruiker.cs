using System.ComponentModel.DataAnnotations;

namespace Shoppers12.Models.Data
{
    public class Gebruiker
    {
        [Key]
        public int GebruikerId { get; set; }
        
        public string Naam { get; set; }
        
        public string Voornaam { get; set; }
        
        public string Email { get; set; }
        
    }
}
