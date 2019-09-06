using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Redirect { get; set; }
        public string Platform { get; set; }
        public string AppId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
    }
}
