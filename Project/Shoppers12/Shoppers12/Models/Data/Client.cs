﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppers12.Models.Data
{
    public class Client
    {
        [Key]
        [Required]
        public int ClientId { get; set; }
        public int GebruikerId { get; set; }
        [ForeignKey("GebruikerId")]
        [ValidateNever]
        public Gebruiker Gebruiker { get; set; }
    }
}
