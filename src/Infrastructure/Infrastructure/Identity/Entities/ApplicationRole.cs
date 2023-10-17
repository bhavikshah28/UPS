using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UPS.Infrastructure.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }

    }
}
