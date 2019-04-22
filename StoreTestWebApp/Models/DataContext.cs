using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public class DataContext: DbContext
    {

        public DataContext() : base("MyConnectionString")
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Client> clients { get; set; }

    }
}