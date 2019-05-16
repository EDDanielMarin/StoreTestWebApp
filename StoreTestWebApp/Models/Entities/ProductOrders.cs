using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreTestWebApp.Models
{
    public class ProductOrders
    {
        [Key]
        public int ProductOrderId { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Precio Ordenado")]
        public decimal Price { get; set; }
        [Display(Name = "Monto")]
        public decimal Total { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }

    }
}
