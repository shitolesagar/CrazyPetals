using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AppId { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
