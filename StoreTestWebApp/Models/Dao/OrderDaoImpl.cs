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
                list = contains == "" ? context.orders.OrderByDescending(x => x.Date).ToList() :
                    context.orders
                    .Include(x =>x.Details.Select(y => y.Product))
                    .Include(x => x.Client)
                    .Where(x => x.Client.Fullname.Contains(contains)).ToList();
                return list;


            }
        }

        public Order FindObject(string id)
        {
            using (var context = new DataContext())
            {
                return context.orders.Include(x => x.Details.Select(y => y.Product)).Where(x => x.OrderID.ToString() == id).SingleOrDefault();

            }
        }

        public bool Create(Order order)
        {
            try
            {
                using (var context = new DataContext())
                {
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

    }
}