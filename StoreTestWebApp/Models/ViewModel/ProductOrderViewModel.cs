using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public class ProductOrderViewModel
    {

        #region ViewModels

            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quanty { get; set; }
            public decimal UnitPrice { get; set; }
            public bool Remove { get; set; }
            public decimal Total()
            {
                return Quanty * UnitPrice;
            }
        
        #endregion
    }
}