﻿using System;
using Microsoft.AspNetCore.Identity;

namespace UPS.Infrastructure.Identity.Entities
{
    public class ApplicationUserRole: IdentityUserRole<Guid>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
