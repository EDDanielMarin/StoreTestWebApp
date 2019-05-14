using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{
    public interface Dao<T>
    {
        T FindObject(string id);
        List<T> FindList(string contains);

    }
}