using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Learning.DAL.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
    }
}
