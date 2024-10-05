using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocksNStuff.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

}