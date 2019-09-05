using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Colors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HashCode { get; set; }
        public string AppId { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
