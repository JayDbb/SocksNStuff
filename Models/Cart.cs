using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocksNStuff.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal totalPrice { get; set; }

        public Product product { get; set; }

    }
}