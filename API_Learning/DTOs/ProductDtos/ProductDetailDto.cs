using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.DTOs.ProductDtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
