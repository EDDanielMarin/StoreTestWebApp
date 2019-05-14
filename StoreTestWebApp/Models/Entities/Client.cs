using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreTestWebApp.Models
{

    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [Display(Name ="Nombre del Cliente")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Apellido del Cliente")]
        public string LastName { get; set; }

        public string NameFull
        {
            get { return FirstName + " " + LastName; }
        }
        [Display(Name = "Cliente")]
        public string Fullname => string.Format("{0} {1}", FirstName, LastName);



        public static implicit operator Client(List<Client> v)
        {
            throw new NotImplementedException();
        }
    }
}