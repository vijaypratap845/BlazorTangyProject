using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class ProductDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool ShopFavourites { get; set; }
        public bool CustomerFavourites { get; set; }
      //  public string Color { get; set; }
      public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
      
    }
}
