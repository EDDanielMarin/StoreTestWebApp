using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [Display(Name ="Nombre del Cliente")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Apellido del Cliente")]
        public string LastName { get; set; }

    }
}