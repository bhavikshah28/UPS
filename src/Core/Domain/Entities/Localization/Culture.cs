﻿using System.Collections.Generic;

namespace UPS.Domain.Entities.Localization
{
    public class Culture
    {
        public Culture()
        {
            Resources = new HashSet<Resource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
