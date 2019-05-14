using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Nombre del Producto")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Precio del Producto")]
        public decimal Price { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }



    }
}