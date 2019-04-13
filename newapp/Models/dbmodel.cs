using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace newapp.Models
{
    public class dbmodel:DbContext
    {
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    public class Catagory
    {[Key]
       
        public int CatagoryId { get; set; }
      
        public string CName { get; set; }
        public ICollection<Product> Product { get; set; }
    }
    public class Product
    {
        [Key]
      
        public int ProductId { get; set; }
       
        public string PName { get; set; }
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}