using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models.Dao
{
    public class ProductDaoImpl : Dao<Product>
    {
        public bool Create(Product obj)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindList(string contains)
        {
            using (var context = new DataContext())
            {
                List<Product> list = new List<Product>();
                list = contains==""?context.products.ToList():context.products.Where(x=>x.Name==contains).ToList();
                return list;
            }
        }

        public  Product FindObject(string id)
        {
            using (var context = new DataContext())
            {
                var product = context.products.Where(x => x.ProductId.ToString() == id).SingleOrDefault();
                return product;
                
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}