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
        public int ProductId { get; set; }
        public string ProductName { get; set; }
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
            ProductId = 0;
            ProductName = null;
            ProductQuanty = 1;
            ProductPrice = 0;
        }

        public bool AddValidProduct()
        {
            return !(ProductId == 0 || string.IsNullOrEmpty(ProductName) || ProductQuanty == 0 || ProductPrice == 0);
        }

        public bool ExistInDetail(int ProductId)
        {
            return OrderDetails.Any(x => x.ProductId == ProductId);
        }

        public void RetirarItemDeDetalle()
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
                ProductId = this.ProductId,
                ProductName = this.ProductName,
                UnitPrice = this.ProductPrice,
                Quanty = this.ProductQuanty,
            });

            Refresh();
        }

        public Order ToModel()
        {
            var order = new Order();

            order.Client = (new ClientDaoImpl()).FindObject(ClientId.ToString());
            order.Date = DateTime.Now;
            order.TotalOrder = this.Total();

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
