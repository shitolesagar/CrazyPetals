﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Database
{
    public class DeliveryCharge
    {
        public int Id { get; set; }
        public string AppId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Charge { get; set; }
        public string CreatedDate { get; set; }
    }
}
