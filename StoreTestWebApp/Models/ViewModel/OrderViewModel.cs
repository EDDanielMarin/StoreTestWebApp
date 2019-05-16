using StoreTestWebApp.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace StoreTestWebApp.Models
{
    public class OrderViewModel
    {

        #region Cabecera
        public int ClientId { get; set; }
        public string ClienteName { get; set; }
        public int ProductIdSel { get; set; }
        public string ProductNameSel { get; set; }
        public int ProductQuanty { get; set; }
        public decimal ProductPrice { get; set; }
        #endregion

        #region Contenido
        public List<ProductOrderViewModel> OrderDetails { get; set; }
        #endregion

        #region Pie
        public decimal Total()
        {
            return OrderDetails.Sum(x => (x.UnitPrice * x.Quanty));
        }
        public DateTime CreationTime { get; set; }
        #endregion

        public OrderViewModel()
        {
            OrderDetails = new List<ProductOrderViewModel>();
            Refresh();
        }

        public void Refresh()
        {
            ProductIdSel = 0;
            ProductNameSel = null;
            ProductQuanty = 1;
            ProductPrice = 0;
        }

        public bool IsValidProduct()
        {
            return !(ProductIdSel == 0 || string.IsNullOrEmpty(ProductNameSel) || ProductQuanty == 0 || ProductPrice == 0);
        }

        public bool ExistInDetail(int ProductId)
        {
            return OrderDetails.Any(x => x.ProductId == ProductId);
        }

        public void RemoveDetailItem()
        {
            if (OrderDetails.Count > 0)
            {
                var detailToRemove = OrderDetails.Where(x => x.Remove)
                                                        .SingleOrDefault();
                OrderDetails.Remove(detailToRemove);
            }
        }

        public void AddDetailItem()
        {
            OrderDetails.Add(new ProductOrderViewModel
            {
                ProductId = ProductIdSel,
                ProductName = ProductNameSel,
                UnitPrice = ProductPrice,
                Quanty = ProductQuanty,
            });

            Refresh();
        }

        public Order ToModel()
        {
            var order = new Order();

            order.Client = (new ClientDaoImpl()).FindObject(ClientId.ToString());
            order.Date = DateTime.Now;
            order.TotalOrder = this.Total();
            order.Details = new List<ProductOrders>();

            foreach (var i in OrderDetails)
            {
                order.Details.Add(new ProductOrders
                {
                    Product = new ProductDaoImpl().FindObject(i.ProductId.ToString()),
                    Quantity = i.Quanty,
                    Price = i.UnitPrice,
                    Total = i.Total(),


                });

            }

            return order;
        }
    }    
}
