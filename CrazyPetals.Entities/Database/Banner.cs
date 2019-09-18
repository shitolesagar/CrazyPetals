﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Banner
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string RedirectClick { get; set; }
        public string AppId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
