﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocksNStuff.Models
{
    public class Customer
    {

        public int Id { get; set; }   

        public string Fname { get; set; }       

        public string Lname { get; set; }       

        public DateTime CreatedAt { get; set; } 

        public string Address { get; set; }   

        public string Email { get; set; }       
        

    }
}