using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newapp.Models
{
    public class Vm
    {
        public int CatagoryId { get; set; }

        public string CName { get; set; }


        public int ProductId { get; set; }

        public string PName { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}