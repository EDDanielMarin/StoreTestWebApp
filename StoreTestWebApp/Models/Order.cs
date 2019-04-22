using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; set; }
        public Client Client { get; set; } 
    }
}