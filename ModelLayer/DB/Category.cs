using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DB
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }   
    }
}
