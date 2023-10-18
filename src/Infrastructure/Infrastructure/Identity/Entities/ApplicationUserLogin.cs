using System;
using Microsoft.AspNetCore.Identity;

namespace UPS.Infrastructure.Identity.Entities
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser User { get; set; }
    }
}