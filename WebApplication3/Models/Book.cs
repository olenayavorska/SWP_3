using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}