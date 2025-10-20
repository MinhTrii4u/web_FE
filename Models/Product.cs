using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_FE.Models 
{
    public class Product
    {
        public int Id { get; set; }         
        public string Name { get; set; }       
        public decimal Price { get; set; }    
        public string ImageUrl { get; set; }   
        public string Brand { get; set; }      
       
    }
}