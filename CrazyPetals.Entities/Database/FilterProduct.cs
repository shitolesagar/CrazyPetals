using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class FilterProduct
    {
        public int Id { get; set; }

        public int FilterId { get; set; }
        public Subcategory Filter { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
