using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models.Dao
{
    public class OrderDaoImpl : Dao<Order>
    {
        public List<Order> FindList(string contains)
        {
            using (var context = new DataContext())
            {


                List<Order> list = new List<Order>();

                list = contains == "" ?
                    context.orders
                    .Include(x => x.Client)
                    .Include(x => x.Details.Select(y => y.Product)).ToList()
                :
                   context.orders
                    .Include(x => x.Client)
                    .Include(x => x.Details.Select(y => y.Product))
                    .Where(x => x.Client.Fullname.Contains(contains)).ToList();

                return list;


            }
        }

        public  Order FindObject(string id)
        {
            using (var context = new DataContext())
            {
                return context.orders
                    .Include(x => x.Client)
                    .Include(x => x.Details.Select(y => y.Product))
                    .Where(x => x.OrderID.ToString() == id).SingleOrDefault();

            }
        }

        public bool Create(Order order)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.clients.Attach(order.Client);
                    foreach (ProductOrders x in order.Details)
                        context.products.Attach(x.Product);
                   context.Entry(order).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var ord = context.orders.Single(a => a.OrderID == id);
                    foreach (ProductOrders x in ord.Details)
                        context.ProductOrders.Attach(x);
                    context.orders.Remove(ord);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}