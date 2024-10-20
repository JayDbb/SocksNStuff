using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocksNStuff.Models
{
    public class CartItemWithDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get { return Quantity * Price; } }
    }

}