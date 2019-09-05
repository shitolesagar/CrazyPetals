using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string AppId { get; set; }

        public ICollection<Filter> Filters { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
