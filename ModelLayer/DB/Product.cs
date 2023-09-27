using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DB
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        public double price100 { get; set; }

        public int category_Id { get; set; }
        [ForeignKey("category_Id")]
        public Category Category { get; set; }
        public string ImageUrl { get; set; }


    }
}
