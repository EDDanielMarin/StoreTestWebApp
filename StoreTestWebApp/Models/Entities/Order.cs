using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models

{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Fecha de la orden")]
        public DateTime Date { get; set; }
        [Display(Name = "Monto")]
        public decimal TotalOrder { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<ProductOrders> Details { get; set; }

    }
}