﻿using UPS.Application.Abstractions;
using UPS.Domain.Entities.Localization;
using Microsoft.EntityFrameworkCore;

namespace UPS.Infrastructure.Localization
{
    public class LocalizationDbContext : DbContext, ILocalizationDbContext
    {
        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }
    }
}
