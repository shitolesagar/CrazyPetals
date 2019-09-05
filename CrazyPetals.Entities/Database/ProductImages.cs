using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public string AppId { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
