﻿using System;
using System.Threading.Tasks;
using UPS.Infrastructure.Identity.Entities;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UPS.Infrastructure.Identity
{

    public class IdentityServerDbContext :
        IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
            ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
            ApplicationRoleClaim, ApplicationUserToken>, IPersistedGrantDbContext
    {
        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

        public IdentityServerDbContext(
            DbContextOptions<IdentityServerDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options)
        {
            _operationalStoreOptions = operationalStoreOptions;
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
        Task<int> IPersistedGrantDbContext.SaveChangesAsync() => base.SaveChangesAsync();
        public DbSet<Client> Clients { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<Key> Keys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
        }
    }
}
