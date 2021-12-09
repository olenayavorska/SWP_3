using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class CartLine
    {
        public int id { get; set; }
        public string bookName { get; set; }
        public double priceForOne { get; set; }
        public double generalPrice { get; set; }
        public int count { get; set; }
    }
}