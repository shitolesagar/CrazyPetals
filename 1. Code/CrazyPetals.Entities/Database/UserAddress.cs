using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string PINCode { get; set; }
        public bool IsDeleted { get; set; }
        public string AppId { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<OrderSummary> OrderSummaries { get; set; }
    }
}
