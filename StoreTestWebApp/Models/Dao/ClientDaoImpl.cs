using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models.Dao
{
    public class ClientDaoImpl : Dao<Client>
    {
        public bool Create(Client obj)
        {
            throw new NotImplementedException();
        }

        public List<Client> FindList(string contains)
        {
            using (var context = new DataContext())
            {
                List<Client> list = new List<Client>();
                list = contains == "" ? context.clients.ToList() : context.clients.Where(x => x.FirstName.Contains(contains) || x.LastName.Contains(contains)).ToList();
                return list;
            }
        }

        public Client FindObject(string id)
        {
            using (var context = new DataContext())
            {
                var client = context.clients.Where(x => x.ClientId.ToString()==id).SingleOrDefault();
                return client;

            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}