﻿using Shoppers12.Models.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppers12.Models.Data
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }



        public int GebruikerId { get; set; }
        [ForeignKey("GebruikerId")]
        [ValidateNever]
        public Gebruiker Gebruiker { get; set; }
    }
}
