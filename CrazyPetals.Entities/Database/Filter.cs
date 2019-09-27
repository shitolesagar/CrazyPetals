using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

       // public ICollection<FilterProduct> FilterProducts { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
