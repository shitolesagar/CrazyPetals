using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Filters
{
    public class BannerFilter: FilterBase
    {
        public bool showExpired { get; set; }
    }
}
